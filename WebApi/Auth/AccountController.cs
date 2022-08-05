﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Claims;
using WebApi.Base.Request;
using WebApi.Base.Response;
using WebApi.Controllers;
using WebApi.Data.Model;
using WebApi.Dto;
using WebApi.Service.Abstract;

namespace WebApi.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseController<AccountDto, Account>
    {
        private readonly IAccountService _accountService;


        public AccountController(IAccountService accountService, IMapper mapper) : base(accountService, mapper)
        {
            this._accountService = accountService;
        }


        [HttpPost]
        public new async Task<IActionResult> CreateAsync([FromBody] AccountDto resource)
        {
            var result = await _accountService.InsertAsync(resource);

            if (!result.Success)
                return BadRequest(result);

            return StatusCode(201, result);
        }

        [HttpGet("GetUserDetail")]
        [Authorize]
        public async Task<IActionResult> GetUserDetail()
        {
            var userId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            return await base.GetByIdAsync(int.Parse(userId));
        }

        [HttpPut("self-update/{id:int}")]
        [Authorize]
        public async Task<IActionResult> SelfUpdateAsync(int id, [FromBody] AccountDto resource)
        {
            Log.Information($"{User.Identity?.Name}: self-update account with Id is {id}.");

            var identifier = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!identifier.Equals(id.ToString()))
                return BadRequest(new BaseResponse<AccountDto>("Account_Not_Permitted"));

            var result = await _accountService.SelfUpdateAsync(id, resource);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("change-password/{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdatePasswordAsync(int id, [FromBody] UpdatePasswordRequest resource)
        {
            // Check if the id belongs to me
            var identifier = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!identifier.Equals(id.ToString()))
                return BadRequest(new BaseResponse<AccountDto>("Account_Not_Permitted"));

            // Checking duplicate password
            if (resource.OldPassword.Equals(resource.NewPassword))
                return BadRequest(new BaseResponse<AccountDto>("Account_Not_Permitted"));

            var result = await _accountService.UpdatePasswordAsync(id, resource);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public new async Task<IActionResult> DeleteAsync(int id)
        {
            return await base.DeleteAsync(id);
        }
    }

}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Base.Attribute;

namespace WebApi.Base.Request
{
    public class UpdatePasswordRequest
    {
        [Required]
        [PasswordAttribute]
        public string OldPassword { get; set; }

        [Required]
        [PasswordAttribute]
        public string NewPassword { get; set; }
    }
}

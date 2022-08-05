using Microsoft.AspNetCore.Mvc;
using WebApi.Base.Filters;

namespace WebApi.Attribute
{
    [ApiController]
    [Route("[controller]")]
    public class AttributeController : ControllerBase
    {

        public AttributeController()
        {
        }

        [ResponseHeader("Author-Code", "Deny Sellen")]
        [HttpGet]
        public string Get()
        {
            return "Patika";
        }


        [TypeFilter(typeof(ConsoledAuthorizationFilter))]
        [TypeFilter(typeof(ConsoledResourceFilter))]
        [TypeFilter(typeof(ConsoledActionFilter))]
        [TypeFilter(typeof(ConsoledResultFilter))]
        [HttpDelete]
        public string Delete()
        {
            return "Exception while fetching all the students from the storage.";
        }



    }
}

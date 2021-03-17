using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Viags.Simple;
namespace Viags.WebApp.Controllers
{
    public class APIController : ApiController
    {
        public class UserClass
        {
            public string username { get; set; }
            public string password { get; set; }
        }
        [HttpGet]
        [Route("api/categories")]
        public IHttpActionResult GetLoginInfo(string username,string password)
        {
            var categoriesList = new TransitItem()
            {
                ID = 12345,
                Ten = "Hello World"
            };
            return Ok(categoriesList);
        }

    }
}

using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Linq;
using System;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http.Headers;

namespace API
{

    public class APIVerify : ActionFilterAttribute
    {

        public class Message
        {

            public Message()
            {
            }

            public Message(string msg)
            {
                this.msg = msg;
            }

            public string msg { get; set; }
        }

        public override void OnActionExecuting(HttpActionContext context)
        {
            try
            {
                if (!checkAPIKey(context))
                {
                    var response = context.Request.CreateResponse(HttpStatusCode.Forbidden);
                    response.Content = new StringContent(JsonConvert.SerializeObject(new Message("Forbidden")));
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    context.Response = response;
                    return;
                }
            }
            catch
            {
                var response = context.Request.CreateResponse(HttpStatusCode.Forbidden);
                response.Content = new StringContent(JsonConvert.SerializeObject(new Message("Forbidden")));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                context.Response = response;
                return;
            }
        }


        private bool checkAPIKey(HttpActionContext context)
        {
            try
            {
                IEnumerable<string> values;
                context.Request.Headers.TryGetValues("X-API-KEY", out values);
                string apikey = values?.FirstOrDefault();
                if (String.IsNullOrEmpty(apikey))
                {
                    return false;
                }
                string apiKeys = "3EB76D87D97C427943957C555AB0B60847582D38CB1688ED86C59251206305E3";

                bool result = apiKeys == apikey;

                if (result)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}

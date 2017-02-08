using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace TestGAP
{
    class BasicAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var headers = actionContext.Request.Headers;
            if (headers.Authorization != null && headers.Authorization.Scheme == "Basic")
            {
                try
                {
                    var userPwd = Encoding.UTF8.GetString(Convert.FromBase64String(headers.Authorization.Parameter));
                    var user = userPwd.Substring(0, userPwd.IndexOf(':'));
                    var password = userPwd.Substring(userPwd.IndexOf(':') + 1);
                    // Validamos user y password (aquí asumimos que siempre son ok)
                    if (!user.Equals("my_user") || !password.Equals("my_password"))
                    {
                        PutUnauthorizedResult(actionContext, "Invalid Authorization header");
                    }
                }
                catch (Exception)
                {
                    PutUnauthorizedResult(actionContext, "Invalid Authorization header");
                }
            }
            else
            {
                // No hay el header Authorization
                PutUnauthorizedResult(actionContext, "Auhtorization needed");
            }
        }

        private void PutUnauthorizedResult(HttpActionContext actionContext, string msg)
        {
            Object resp = new { error_msg = "Not authorized", error_code = HttpStatusCode.Unauthorized, success = false };
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
              {
                  Content = new StringContent(JsonConvert.SerializeObject(resp), Encoding.UTF8, "application/json")
              };

        }
    }
}
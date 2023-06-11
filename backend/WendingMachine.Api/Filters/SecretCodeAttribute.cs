using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Web.Http.Filters;

namespace WendingMachine.Api.Filters
{
    public class SecretCodeAttribute : FilterAttribute, Microsoft.AspNetCore.Mvc.Filters.IActionFilter
    {
        public string secretKey;
        public IConfiguration configuration { get; set; }
        public SecretCodeAttribute(IConfiguration configuration/* ,string key="MySuperSecretKey"*/)
        {
            /*secretKey = key;*/
            this.configuration = configuration;
            secretKey = configuration.GetValue<string>("SecretKey");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string key;
            if (context.HttpContext.Request.Query.ContainsKey("Key"))
            {
                key = context.HttpContext.Request.Query["Key"];
                if (key != secretKey)
                    context.Result = new UnauthorizedResult();
            }
            else
                context.Result = new UnauthorizedResult();
        }
    }
}

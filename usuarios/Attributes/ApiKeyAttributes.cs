using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using usuarios.Helpers;

namespace usuarios.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    internal class ApiKeyAttributes : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyName = "x-api-key";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyName, out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key não informada."
                };
                return;
            }

            var apiKeys = Constants.xKeysApi;

            if (!apiKeys.Contains(extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key não é valida"
                };
                return;
            }
            await next();
        }
    }
}

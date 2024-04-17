namespace DSAEx.Authentication
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {

            _next = next;
            _configuration = configuration;
        }


        public async Task InvokeAsync(HttpContext context)
        {

            var providedApiKey = context.Request.Headers[AuthConfig.ApiKeyHeader].FirstOrDefault();
            var isValid = IsValidApiKey(providedApiKey);

            if (!isValid)
            {
                await GenerateResponse(context, 401, "Invalid Authentication");
                return;
            }

            await _next(context);
        }
        private bool IsValidApiKey(string? providedApiKey)
        {
            if(string.IsNullOrEmpty(providedApiKey))
            {
                return false;
            }
            var validApiKey = _configuration.GetValue<string>(AuthConfig.AuthSection);

            return string.Equals(validApiKey,providedApiKey, StringComparison.Ordinal);
        }

        private async Task GenerateResponse(HttpContext context, int v1, string v2)
        {
            context.Response.StatusCode= v1;
            await context.Response.WriteAsync(v2);

        }
    }
}

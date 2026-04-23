namespace KoeretoejsManager.Api.CustomMiddleWares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api"))
            {
                if (!context.Request.Headers.TryGetValue("X-Api-Key", out var extractedKey))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("API Key missing");
                    return;
                }

                var validKey = _config["ApiKey"];

                if (!validKey.Equals(extractedKey))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Invalid API Key");
                    return;
                }
            }

            await _next(context);
        }
    }
}

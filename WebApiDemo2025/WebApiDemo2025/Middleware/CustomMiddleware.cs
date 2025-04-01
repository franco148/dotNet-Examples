
namespace WebApiDemo2025.Middleware
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My Custom Middleware - Starts");
            await next(context);
            await context.Response.WriteAsync("My Custom Middleware - Ends");
        }
    }

    // Instead of using app.UserMiddleware, here we have another approach.
    public static class CustomMiddlewareExtension 
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware>();
        }
    }
}

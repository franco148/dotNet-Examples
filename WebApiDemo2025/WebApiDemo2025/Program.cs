using WebApiDemo2025.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<CustomMiddleware>();
var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

//app.Run(async (HttpContext context) => {
//    await context.Response.WriteAsync("Hello test");
//});


// Middleware Chain 
// Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("From middleware 1");
    await next(context);
});

// Middleware 2
// app.UseMiddleware<CustomMiddleware>();
app.UseCustomMiddleware();

app.UseWhen(
    context => context.Request.Query.ContainsKey("username"),
    app => {
        app.Use(async (context, next) => {
            await context.Response.WriteAsync("Hello from Middleware branch");
            await next();
        });
    }
);

// Middleware 3
app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("From middleware 3");
});

app.Run();

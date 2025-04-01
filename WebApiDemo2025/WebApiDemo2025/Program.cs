var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

//app.Run(async (HttpContext context) => {
//    await context.Response.WriteAsync("Hello test");
//});


// Middleware Chain 
// Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Hello test");
    await next(context);
});

// Middleware 2
app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("Hello test again");
});

app.Run();

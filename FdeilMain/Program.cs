using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/", context =>
{
    var isSpanish = context.Request.Headers["Accept-Language"].ToString().StartsWith("es", StringComparison.OrdinalIgnoreCase);
    var host = context.Request.Host.Host;

    var redirectTo = $"https://blog{(isSpanish ? "-es" : string.Empty)}.{host}";
    context.Response.Redirect(redirectTo);    

    return Task.CompletedTask;
});

app.Run();


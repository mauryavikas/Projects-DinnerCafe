using DinnerCafe.Application.Services.Authentication;
using DinnerCafe.Application;
using DinnerCafe.infrastructure;
using Microsoft.Extensions.Configuration;
using DinnerCafe.Api.Middleware;
using Microsoft.Extensions.Options;
using DinnerCafe.Api.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();//options => options.Filters.Add<ErrorHandlingFilterAttribute>()

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
{
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services
             .AddApplication()
             .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ErrorHandlingMiddleware>(); // Global Error Handeling using middleware

app.UseExceptionHandler("/error"); // Global Error Handeling using End point 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
}
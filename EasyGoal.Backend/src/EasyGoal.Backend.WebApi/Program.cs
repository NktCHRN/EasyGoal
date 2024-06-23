using EasyGoal.Backend.Application;
using EasyGoal.Backend.Domain;
using EasyGoal.Backend.Infrastructure;
using EasyGoal.Backend.WebApi;
using EasyGoal.Backend.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDomainServices()
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddWebApiServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("DEV_CORS");
}
else
{
    app.UseCors("PROD_CORS");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();

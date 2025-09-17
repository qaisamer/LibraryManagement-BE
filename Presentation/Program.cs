using Application;
using Infrastructure;
using Presentation;
using Presentation.Middlewares;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
                .AddApplication()
                .AddInfrastructure(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS
var crossOrigin = builder.Configuration.GetSection("CrossOrigin").Get<string[]>();
builder.Services.AddCors(options =>
    options.AddPolicy("_myAllowSpecificOrigins", builder =>
        builder.WithOrigins(crossOrigin!)
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseCors("_myAllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();

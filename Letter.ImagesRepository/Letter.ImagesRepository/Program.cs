using System.Text.Json.Serialization;
using Letter.Infrastructure.Application;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

string _specificCorsName = "CustomCorsPolicy";

var Configuration = builder.Configuration;

builder.Services.AddCors(options =>
{
    options.AddPolicy(name:_specificCorsName, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddApplication();

builder.Services.AddControllers().AddJsonOptions( o =>o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Letter.ImagesRepository",
        Description = "Micro-service for images"
    }); 
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(_specificCorsName);
app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
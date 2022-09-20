using System.Text.Json.Serialization;
using Letter.Infrastructure.Application;
using Letter.Infrastructure.Database;
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
builder.Services.AddInfrastructureDataBase(Configuration);
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
app.UseEndpoints(endpoints => { endpoints.MapControllers();} );
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Letter.ImagesRepository");
    c.RoutePrefix = string.Empty;
});
app.MapControllers();

app.Run();
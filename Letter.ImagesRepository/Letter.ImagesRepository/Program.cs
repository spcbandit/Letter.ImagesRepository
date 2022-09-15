using System.Text.Json.Serialization;
using Letter.Infrastructure.Application;

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
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
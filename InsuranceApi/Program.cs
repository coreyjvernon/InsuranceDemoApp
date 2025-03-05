var builder = WebApplication.CreateBuilder(args);

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
var app = builder.Build();

// Use the CORS policy
app.UseCors("AllowReactApp");
app.UseAuthorization();
app.MapControllers();
app.Run();

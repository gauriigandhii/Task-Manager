using TaskManagerBackend.Services;
var builder = WebApplication.CreateBuilder(args);

// ✅ Add services
builder.Services.AddControllers();

// ✅ Add CORS only ONCE (before Build)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins("http://localhost:3000", "https://your-frontend.vercel.app")
              .AllowAnyMethod()
              .AllowAnyHeader());
});

builder.Services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Use Swagger (optional)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ Use CORS BEFORE authorization and mapping controllers
app.UseCors("AllowFrontend");

app.UseAuthorization();
app.MapControllers();

app.Run();

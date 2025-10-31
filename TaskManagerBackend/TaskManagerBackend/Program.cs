using TaskManagerBackend.Services;
var builder = WebApplication.CreateBuilder(args);

// ✅ Add services
builder.Services.AddControllers();

// ✅ CORS setup
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins(
            "http://localhost:3000", // for local dev
            "https://task-manager-jmgk.vercel.app/" // your actual Vercel app
        )
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


// ✅ Important: CORS before Authorization
app.UseCors("AllowFrontend");

app.UseAuthorization();
app.MapControllers();
app.Run();

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HttpClient (Foundry)
builder.Services.AddHttpClient<FoundryLLMService>(client =>
{
    client.Timeout = TimeSpan.FromMinutes(10);
});

// Custom Services
builder.Services.AddSingleton<SkillService>();
builder.Services.AddScoped<AgentService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
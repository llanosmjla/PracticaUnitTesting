using StudentControl.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<StudentService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapControllers();
app.Run();


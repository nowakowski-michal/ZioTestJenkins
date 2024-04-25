using ProjektZiotest.BLL;
using ProjektZiotest.IService;
using ProjektZiotest.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<QuizDB>();
builder.Services.AddCors(options =>
options.AddPolicy("quizPolicy", policy =>
policy.AllowAnyOrigin().AllowAnyMethod()
.AllowAnyHeader().Build()));
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<ITestService, TestService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("quizPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();

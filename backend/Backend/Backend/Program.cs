using DataLayer.context;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

//Dependency Injection
builder.Services.AddTransient<IQuestionService, QuestionService>();
builder.Services.AddTransient<IQuestionRepository, QuestionRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IOptionRepository, OptionRepository>();

//Db Context
#region Context

builder.Services.AddDbContext<BackendGameContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbString"));
});

#endregion

//Allow any origin (CORS)
builder.Services.AddCors(option => option.AddPolicy("AllowCorsPolicy", builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

// Add services to the container.

builder.Services.AddControllers();
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

app.UseCors("AllowCorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();

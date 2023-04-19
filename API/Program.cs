using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Implementations;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SWAContext>(option =>
{
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IKursRepository, KursRepository>();
builder.Services.AddScoped<IStudentKursRepository, StudentKursRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IKursService, KursService>();
builder.Services.AddScoped<IStudentKursService, StudentKursService>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<SWAContext>();
DbInitializer.Initialize(context);

app.Run();

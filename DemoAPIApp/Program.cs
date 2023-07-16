global using DemoAPIApp.Data;
global using Microsoft.EntityFrameworkCore;
using DemoAPIApp.Controllers;
using DemoAPIApp.Data.Model;
using DemoAPIApp.Services.AcademicYearService;
using DemoAPIApp.Services.AuthService;
using DemoAPIApp.Services.DepartmentService;
using DemoAPIApp.Services.FalcutyService;
using DemoAPIApp.Services.StudentService;
using DemoAPIApp.Services.TeacherService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IFalcutyService, FalcutyService>();
builder.Services.AddScoped<IAcademicYearService, AcademicYearService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

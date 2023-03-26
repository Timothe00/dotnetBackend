using Backend.business.DataAccess.Data;
using Backend.business.Logic.Services.MatersServices;
using Backend.business.Logic.Services.RoleServices;
using Backend.business.Logic.Services.StudentServices;
using Backend.business.Logic.Services.TeachersServices;
using Backend.business.Logic.Services.UsersServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


string? corsOrigin = builder.Configuration.GetSection("CorsOrigin").Get<string>();

builder.Services.AddCors(o =>
{
    o.AddPolicy(
        name: "MarkerApi",
        p => p.WithOrigins(corsOrigin)
        .AllowAnyHeader()
        .AllowAnyMethod());
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<presenceManagementDbContext>(Option => {
    Option.UseSqlServer(builder.Configuration.GetConnectionString("LinkCs"));
});

builder.Services.AddScoped<UsersService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<MatersService>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<TeachersService>();
//builder.Services.AddScoped<IUsersService>();

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

app.Run();

using Backend.business.DataAccess.Data;
using Backend.business.Logic.Services.AdminServices;
using Backend.business.Logic.Services.AuthServices;
using Backend.business.Logic.Services.MatersServices;
using Backend.business.Logic.Services.MattersServices;
using Backend.business.Logic.Services.RoleServices;
using Backend.business.Logic.Services.StudentServices;
using Backend.business.Logic.Services.TeachersServices;
using Backend.business.Logic.Services.UsersServices;
using Backend.bussiness.webApi.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<presenceManagementDbContext>(Option => {
    Option.UseSqlServer(builder.Configuration.GetConnectionString("LinkCs"));
});


//Gesttion des erreurs d'entête CORS
string? corsOrigin = builder.Configuration.GetSection("CorsOrigin").Get<string>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IUsersService,UsersService>();
builder.Services.AddScoped<IRoleServices,RoleService>();
builder.Services.AddScoped<ITeachersServices, TeachersService>();
builder.Services.AddScoped<IMattersServices,MatersService>();
builder.Services.AddScoped<IStudentServices,StudentService>();
builder.Services.AddScoped<IAdminServices,AdminService>();


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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

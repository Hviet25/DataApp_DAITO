using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using data_app.api.Data;
using data_app.api.Entities;
using data_app.api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("Lakebase") ?? throw new InvalidOperationException("Connection string 'Lakebase' was not found.");
builder.Services.AddDbContext<AppDbContext>(options =>{options.UseNpgsql(connectionString);});
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IPasswordHasher<UserOtp>, PasswordHasher<UserOtp>>();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<OtpService>();
builder.Services.AddScoped<LogService>();
builder.Services.AddScoped<EmailService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

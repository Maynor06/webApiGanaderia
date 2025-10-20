using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Text;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;
using WebapiProyect.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("connectionDB")));


builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<IAuthService, AuthService>();

var jwt = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwt.GetValue<string>("Key"));

builder.Services.AddAuthentication( JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime =  true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwt.GetValue<string>("Issuer"),
            ValidAudience = jwt.GetValue<string>("Audience"),
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key)
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

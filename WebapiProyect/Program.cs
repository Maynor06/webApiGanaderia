using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Text;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;
using WebapiProyect.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        // 1. Pasa tu cadena de conexión como primer argumento
        builder.Configuration.GetConnectionString("connectionDB"),

        // 2. Define las opciones específicas de SQL Server
        sqlServerOptionsAction: sqlOptions =>
        {
            // 🎉 ¡Aquí se agrega la resiliencia!
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5, // Número máximo de reintentos
                maxRetryDelay: TimeSpan.FromSeconds(30), // Tiempo de espera total
                errorNumbersToAdd: null // Utiliza los errores transitorios predeterminados de EF Core
            );
        }
    ));


builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<ICargo, CargoService>();
builder.Services.AddScoped<IDashboard, DashboardService>();
builder.Services.AddScoped<IEspecie, EspecieService>();
builder.Services.AddScoped<IRaza, RazaService>();
builder.Services.AddScoped<Ipotrero, PotreroService>();
builder.Services.AddScoped<Isuplementos, SuplementoService>();
builder.Services.AddScoped<ICompra, CompraService>();
builder.Services.AddScoped<IProduccion, ProduccionService>();
builder.Services.AddScoped<ICorral, CorralService>();
builder.Services.AddScoped<IEstablo, EstabloService>();
builder.Services.AddScoped<IInfraestructura, InfraestructuraService>();
builder.Services.AddScoped<IMedicamento, MedicamentoService>();
builder.Services.AddScoped<IHerramienta, HerramientaService>();
builder.Services.AddScoped<IMaquinaria, MaquinariaService>();
builder.Services.AddScoped<IVentas , VentaService>();
builder.Services.AddScoped<IFacturas, FacturaService>();

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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNextJs",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
        }
    );
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
app.UseCors("AllowNextJs");
app.UseAuthentication();
app.UseAuthorization();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

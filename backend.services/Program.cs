using backend.services;
using System.Text;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

// Implementacion JWT
var secretKey = builder.Configuration["JWTConfig:secretKey"];
var keyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer(config => { 
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

// Agregar acceso de FrontEnd
var CorsConfiguration = "corspolicy";
builder.Services.AddCors(options => {
    options.AddPolicy(
        name: CorsConfiguration,
        builder =>
        {
            builder.WithOrigins(
                "http://localhost:4200"
                , "http://localhost:4201"
                , "http://10.48.0.10"
                , "https://inmobisoft.inmobitec.pe"
                , "http://inmobisoft.inmobitec.pe"
                , "http://miportal2.inmobitec.pe"
                , "https://miportal2.inmobitec.pe"
                , "http://localhost:5500"
                )
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Asignacion de Interfaces/Entidades y BD Conexion
builder.Services.ConfigureRepositoryManager(builder.Configuration["ConnectionStrings:cnInmobisoft"]);
builder.Services.ConfigureServicesManager();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(CorsConfiguration);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

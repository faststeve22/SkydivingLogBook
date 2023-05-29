using Logbook.Background_Services;
using Logbook.DataAccessLayer;
using Logbook.DataAccessLayer.DAO;
using Logbook.DataAccessLayer.Interfaces;
using Logbook.DataAccessLayer.Utilities;
using Logbook.ServiceLayer.Interfaces;
using Logbook.ServiceLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BlueSkiesDb");
// Add services to the container.
builder.Services.AddTransient<IDbConnectionFactory>(sp => new SqlConnectionFactory(connectionString));
builder.Services.AddTransient<IAircraftDAO, AircraftDAO>();
builder.Services.AddTransient<IDbUserDAO, DbUserDAO>();
builder.Services.AddTransient<IDropzoneDAO, DropzoneDAO>();
builder.Services.AddTransient<IEquipmentDAO, EquipmentDAO>();
builder.Services.AddTransient<IJumpDAO, JumpDAO>();
builder.Services.AddTransient<IWeatherDAO, WeatherDAO>();
builder.Services.AddHostedService<RabbitMQConsumer>();
builder.Services.AddTransient<IJumpLogService, JumpLogService>();
builder.Services.AddTransient<IJumpService, JumpService>();
builder.Services.AddTransient<IAircraftService, AircraftService>();
builder.Services.AddTransient<IEquipmentService, EquipmentService>();
builder.Services.AddTransient<IWeatherService, WeatherService>();
builder.Services.AddTransient<IDropzoneService, DropzoneService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IDaoUtilities, DaoUtilities>();
builder.Services.AddHttpContextAccessor();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
            };
        });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
        policy.RequireClaim("Role", "Admin"));
    options.AddPolicy("User", policy =>
        policy.RequireClaim("Role", "User"));
});

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});


builder.Services.AddControllers();
builder.Services.AddMemoryCache();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

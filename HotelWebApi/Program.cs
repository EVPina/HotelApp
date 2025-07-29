using HotelWebApi.Interfaces;
using HotelWebApi.Models;
using HotelWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

    options.Filters.Add(new AuthorizeFilter(policy));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AppDBContext>(option=>option.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));
builder.Services.AddMemoryCache(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ISAdministrador,SAdministrador>();
builder.Services.AddScoped<SCaching>();
builder.Services.AddScoped<IUsuarios,SUsuarios>();
builder.Services.AddSingleton<SJWToken>();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Tu API con JWT",
        Version = "v1",
        Description = "API de ejemplo con autenticación JWT",
        Contact = new OpenApiContact
        {
            Name = "Enzo",
            Email = "tu@email.com"
        }
    });
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese el token como: Bearer {su token}"
    });

    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", option =>
{
    var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:key"]);
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidIssuer = "HotelWebApi",
        ValidAudience = "HotelWebApi"
    };
});


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

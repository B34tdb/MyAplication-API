using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyAplication_API.Models;
using MyAplication_API.Models.Helpers;
using MyAplication_API.Services;
using MyAplication_API.Services.Interface;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Jwt Authorization"

    });
    o.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference
                {
                    Type= ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

string conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AplicationContext>(options => options.UseMySql(conn, ServerVersion.AutoDetect(conn)));
string encondingKey = builder.Configuration["Security:CypherKey"];


builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(Token =>
    {
        Token.RequireHttpsMetadata = false;
        Token.SaveToken = true;
        Token.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(encondingKey)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddCors(Op =>
{
    Op.AddPolicy(name: "AllowAllOriginsPlicy", builder =>
    {
        builder
        .SetIsOriginAllowed(a => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .WithExposedHeaders("www-authenticate")
        .WithExposedHeaders("Content-Disposition");

    });
});

builder.Services.AddTransient<TokenService, TokenService>();
builder.Services.AddTransient<ILoginServices, LoginServices>();
builder.Services.AddTransient<IUsuariosServices, UsuariosServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowOriginsPlicy");

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

using GAS_LATIHAN_ASP.Models;
using GAS_LATIHAN_ASP.Models.DTO;
using GAS_LATIHAN_ASP.Repositories.RoleRepository;
using GAS_LATIHAN_ASP.Repositories.UserRepository;
using GAS_LATIHAN_ASP.Services.PasswordService;
using GAS_LATIHAN_ASP.Services.RoleService;
using GAS_LATIHAN_ASP.Services.TokenService;
using GAS_LATIHAN_ASP.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

// Add services to the container.

// Config option
services.Configure<TokenOptions>(options => configuration.GetSection("TokenOptions").Bind(options));

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddDbContext<BEDBContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("connection")), ServiceLifetime.Transient);

// Services
services.AddTransient<IUserService, UserService>();
services.AddTransient<IPasswordService, PasswordService>();
services.AddTransient<ITokenService, TokenService>();
services.AddTransient<IRoleService, RoleService>();

// Repositories
services.AddTransient<IUserRepository, UserRepository>();
services.AddTransient<IRoleRepository, RoleRepository>();

// JWT
services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = configuration["TokenOptions:Issuer"],
        ValidAudience = configuration["TokenOptions:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(configuration["TokenOptions:SecretKey"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

services.AddAuthorization();

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

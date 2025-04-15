using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PizzApi.Data;
using PizzApi.Models;
using PizzApi.Models.Users;
using PizzApi.Reposiroties;
using PizzApi.Services;
using PizzApi.Services.Interfaces;
using System.Text;
using System.Text.Json.Serialization;

namespace PizzApi.Helpers
{
    public static class DependencyInjectionExtensions
    {
        public static void InjectDepencies(this WebApplicationBuilder builder)
        {

            builder.Services.AddControllers()
                            .AddJsonOptions(options => 
                                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.AddSwagger();

            builder.Services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")!));

            builder.AddRepositories();

            builder.AddServices();

            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

            builder.AddAuthentication();
        }

        private static void AddSwagger(this WebApplicationBuilder builder)
        {

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzAPI", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter your Bearer token in the format **Bearer {token}** to access this API."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
        }

        private static void AddRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRepository<Client, int>, ClientRepository>();
            builder.Services.AddScoped<IRepository<Pizzaiolo, int>, PizzaioloRepository>();
            builder.Services.AddScoped<IRepository<Pizza, int>, PizzaRepository>();
            builder.Services.AddScoped<IRepository<Ingredient, int>, IngredientRepository>();
        }

        private static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHostedService<FirstRunService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IPizzaioloService, PizzaioloService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IPizzaService, PizzaService>();
        }

        private static void AddAuthentication(this WebApplicationBuilder builder)
        {

            var appSettingsSection = builder.Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings!.SecretKey);

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}

using System.Text;
using ContactWithDtos.Data;
using ContactWithDtos.Models;
using ContactWithDtos.Repositories;
using ContactWithDtos.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ContactWithDtos.Helpers
{
    public static class DependencyInjectionExtensions
    {
        public static void InjectDepencies(this WebApplicationBuilder builder)
        {

            builder.Services.AddControllers();

            builder.AddSwagger();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.AddRepositories();

            builder.AddServices();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

            builder.AddAuthentication();
        }

        private static void AddSwagger(this WebApplicationBuilder builder)
        {

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ContactWithDtos API", Version = "v1" });

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
            builder.Services.AddScoped<IRepository<Contact, int>, ContactRepository>();
        }

        private static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHostedService<FirstRunService>();
            builder.Services.AddScoped<IContactService, ContactService>();
        }
        //private static void AddCors(this WebApplicationBuilder builder)
        //{
        //    //builder.Services.AddCors(options =>
        //    //{
        //    //    options.AddPolicy("allConnections", options =>
        //    //    {
        //    //        options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        //    //    });
        //    //    options.AddPolicy("angularApp", options =>
        //    //    {
        //    //        options.WithOrigins("https://angularadress:angularport").WithMethods("GET").WithHeaders("application/json");
        //    //    });
        //    //});
        //}
        private static void AddAuthentication(this WebApplicationBuilder builder)
        {

            var appSettingsSection = builder.Configuration.GetSection("AppSettings"); // récupérer la section
            var appSettings = appSettingsSection.Get<AppSettings>(); // la transformer en objet de type AppSettings
            var key = Encoding.ASCII.GetBytes(appSettings!.SecretKey); // récupérer la clé

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>                                                    // on définit des critères de validation d'un token
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key), // on valide avec la clé
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

    }
}

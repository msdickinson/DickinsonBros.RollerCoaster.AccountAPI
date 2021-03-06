using DickinsonBros.RollerCoaster.AccountAPII.Infrastructure.AccountDB;
using DickinsonBros.RollerCoaster.AccountAPII.Infrastructure.AccountDB.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Net.Mail;
using System;
using System.Net;
using DickinsonBros.RollerCoaster.AccountAPII.Logic.Account;
using DickinsonBros.RollerCoaster.AccountAPII.Infrastructure.EmailSender;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using DickinsonBros.RollerCoaster.AccountAPII.Infrastructure.PasswordEncryption;
using DickinsonBros.RollerCoaster.AccountAPII.Infrastructure.JWT.Models;
using DickinsonBros.RollerCoaster.AccountAPII.Infrastructure.JWT;
using DickinsonBros.Guid.Abstractions;
using DickinsonBros.Encryption;
using DickinsonBros.Logger.Abstractions;
using DickinsonBros.SQL;
using DickinsonBros.Redactor.Abstractions;
using DickinsonBros.Redactor;
using DickinsonBros.Redactor.Models;
using DickinsonBros.Logger;
using DickinsonBros.Middleware;
using DickinsonBros.DateTime.Abstractions;
using DickinsonBros.DateTime;
using DickinsonBros.SQL.Abstractions;
using DickinsonBros.Guid;
using DickinsonBros.Encryption.Models;
using DickinsonBros.Encryption.Abstractions;

namespace DickinsonBros.RollerCoaster.AccountAPII.View
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressMapClientErrors = true;
            });
            services.AddOptions();

            services.Configure<AccountDB>(_configuration.GetSection("DickinsonBrosDB"));
            services.Configure<JsonRedactorOptions>(_configuration.GetSection("JsonRedactorOptions"));
            services.Configure<EncryptionSettings>(_configuration.GetSection("EncryptionSettings"));
            services.Configure<JWTSettings>(_configuration.GetSection("JWTSettings"));
            
            services.AddSingleton<IAccountDBService, AccountDBService>();
            services.AddSingleton<IEncryptionService, EncryptionService>();
            services.AddSingleton<IPasswordEncryptionService, PasswordEncryptionService>();
            services.AddSingleton<IJWTService, JWTService>();
            services.AddSingleton<IDateTimeService, DateTimeService>();
            services.AddSingleton<IAccountManager, AccountManager>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddScoped<ICorrelationService, CorrelationService>();
            services.AddScoped(typeof(ILoggingService<>), typeof(LoggingService<>));
            services.AddSingleton<IRedactorService, RedactorService>();
            services.AddSingleton<IGuidService, GuidService>();
            services.AddSingleton<IMiddlewareService, MiddlewareService>();
            services.AddSingleton<ISQLService, SQLService>();
            services.AddSignalR();
            services.AddScoped<SmtpClient>((serviceProvider) =>
            {
                var config = serviceProvider.GetRequiredService<IConfiguration>();
                return new SmtpClient()
                {
                    Host = config.GetValue<String>("Email:Smtp:Host"),
                    Port = config.GetValue<int>("Email:Smtp:Port"),
                    Credentials = new NetworkCredential(
                            config.GetValue<String>("Email:Smtp:Username"),
                            config.GetValue<String>("Email:Smtp:Password")
                        )
                };
            });

            var JWTSettings = _configuration.GetSection("JWTSettings").Get<JWTSettings>();
            var key = Encoding.ASCII.GetBytes(JWTSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    LifetimeValidator = (System.DateTime? notBefore, System.DateTime? expires, SecurityToken securityToken,
                       TokenValidationParameters validationParameters) =>
                    {
                        return notBefore <= System.DateTime.UtcNow &&
                               expires >= System.DateTime.UtcNow;
                    }
                };
            });

            services.AddApiVersioning();
            services.AddApiVersioning(options => {
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Account API", Version = "1"});
                options.DocInclusionPredicate((version, apiDescription) =>
                {
                    var apiVersionAttribute =
                        (ApiVersionAttribute)
                        apiDescription.ActionDescriptor
                                      .EndpointMetadata
                                      .FirstOrDefault
                                      (
                                        metaData => metaData.GetType().Equals(typeof(ApiVersionAttribute))
                                      );

                    if (apiVersionAttribute != null && apiVersionAttribute.Versions.Any(e => "v" + e.MajorVersion == version))
                    {
                        ReplaceVersionDescriptions(apiDescription, version);
                        return true;
                    }

                    return false;
                });
            });          
        }

        private static void ReplaceVersionDescriptions(ApiDescription apiDescription, string version)
        {
            apiDescription.RelativePath = apiDescription.RelativePath.Replace("/v{version}", $"/{version}");
            var versionParameter =
                apiDescription.ParameterDescriptions.SingleOrDefault(p => p.Name == "version");

            if (versionParameter != null)
            {
                apiDescription.ParameterDescriptions.Remove(versionParameter);
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMiddleware<MiddlewareService>();
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void DepcytConfig()
        {
            //


            //


            //


            //


            //
        }
    }
}
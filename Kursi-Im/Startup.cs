using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KursiIm.Business;
using KursiIm.Domain.Administrations;
using KursiIm.Domain.Logs;
using KursiIm.Domain.SeedWork;
using KursiIm.Domain.Users;
using KursiIm.Infrastructure.Emails;
using KursiIm.Infrastructure.JwtAuthentication.Extensions;
using KursiIm.Infrastructure.KursiIm;
using KursiIm.Infrastructure.Logs;
using KursiIm.Infrastructure.Repositories;
using KursiIm.Infrastructure.SeedWork;
using KursiIm.Infrastructure.Users;
using KursiIm.SharedModel.General;
using KursiImSource.Extensions;
using KursiImSource.Interfaces;
using KursiImSource.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace KursiImSource
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<KursiImContext>(c =>
                     c.UseSqlServer(Configuration.GetConnectionString("KursiImConnection")));

            var validationParams = new TokenValidationParameters
            {
                ClockSkew = TimeSpan.Zero,

                ValidateAudience = true,
                ValidAudience = Configuration["Token:Audience"],

                ValidateIssuer = true,
                ValidIssuer = Configuration["Token:Issuer"],

                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Token:SigningKey"])),
                ValidateIssuerSigningKey = true,

                RequireExpirationTime = true,
                ValidateLifetime = true,

            };
            var validTime = int.Parse(Configuration["Token:ValidTimeInMinutes"]);

            services.AddJwtAuthenticationForAPI(validationParams, validTime);

            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EFRepository<>));
            services.AddScoped(typeof(IGeneralUpdateService<>), typeof(GeneralUpdateService<>));
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserRepoService, UserRepoService>();
        
            services.AddScoped<ILogService, LogService>();
      
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<ISaveLog, SaveLog>();
            services.AddScoped<ILogRepository, LogRepository>();
          

            services.Configure<ApiSettings>(Configuration.GetSection("ApiSettings"));
            services.Configure<WebSettings>(Configuration.GetSection("WebSettings"));
            services.Configure<Token>(Configuration.GetSection("Token"));
            services.Configure<PDFPresentation>(Configuration.GetSection("PDFPresentation"));

            services.AddAutoMapper(typeof(Startup));

            //services.Configure<ApiBehaviorOptions>(options =>
            //{
            //    options.SuppressModelStateInvalidFilter = true;
            //});


            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KursiImeAPI", Version = "v1" });

                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "bearer"
                                }
                            },
                            new string[] {}
                    }
                });
                c.AddFluentValidationRules();
            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TM API V1");
            });

            app.UseMiddleware<CustomUnauthorizeResponseMiddleware>();
            var localizationOption = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizationOption.Value);

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var feature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = feature.Error;

                logger.LogError(exception, "General Error");

                var result = JsonConvert.SerializeObject(new { status = (int)PublicResultStatusCodes.InternalServerError });
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }));



            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            NetworkHelper.SetHttpContextAccessor(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
        }
    }
}

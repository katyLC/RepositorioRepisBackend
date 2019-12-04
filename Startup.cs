using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Data.Repositorio;
using RespositorioREPIS.Domain.Repositories;
using RespositorioREPIS.Domain.UseCases.Alumno;
using RespositorioREPIS.Domain.UseCases.Autenticacion;
using RespositorioREPIS.Domain.UseCases.Autor;
using RespositorioREPIS.Domain.UseCases.Ciclo;
using RespositorioREPIS.Domain.UseCases.Curso;
using RespositorioREPIS.Domain.UseCases.Docente;
using RespositorioREPIS.Domain.UseCases.PalabrasClaves;
using RespositorioREPIS.Domain.UseCases.Paper;
using RespositorioREPIS.Domain.UseCases.Perfil;
using RespositorioREPIS.Domain.UseCases.Proyecto;
using RespositorioREPIS.Domain.UseCases.ProyectoAutor;
using RespositorioREPIS.Domain.UseCases.ProyectoKeyword;
using RespositorioREPIS.Domain.Validators;
using AppContext = RespositorioREPIS.Data.AppContext;

namespace RespositorioREPIS {
    public class Startup {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        private const string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH";

        private readonly SymmetricSecurityKey
            _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));


        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
//            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddFluentValidation();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

//            services.AddMvc(options => { options.Filters.Add(new ModelStateFilter()); }).AddFluentValidation(options =>
//            {
//                options.RegisterValidatorsFromAssemblyContaining<Startup>();
//            });

            services.Configure<MvcOptions>(options => {
                options.Filters.Add(new CorsAuthorizationFilterFactory(MyAllowSpecificOrigins));
            });

            services.AddDbContext<AppContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IAlumnoUseCase, AlumnoUseCase>();
            services.AddTransient<IAlumnoRepositorio, AlumnoRepositorio>();
            services.AddTransient<ICicloUseCase, CicloUseCase>();
            services.AddTransient<ICicloRepositorio, CicloRepositorio>();
            services.AddTransient<IPerfilUseCase, PerfilUseCase>();
            services.AddTransient<IPerfilRepositorio, PerfilRepositorio>();
            services.AddTransient<ICursoUseCase, CursoUseCaseUseCase>();
            services.AddTransient<ICursoRepositorio, CursoRepositorio>();
            services.AddTransient<IPalabrasClavesUseCase, PalabrasClavesUseCase>();
            services.AddTransient<IPalabrasClavesRepositorio, PalabarasClavesRepositorio>();
            services.AddTransient<IProyectoUseCase, ProyectoUseCase>();
            services.AddTransient<IProyectoRepositorio, ProyectoRepositortio>();
            services.AddTransient<IProyectoKeywordRepositorio, ProyectoKeywordRepositorio>();
            services.AddTransient<IProyectoKeywordUseCase, ProyectoKeywordUseCase>();
            services.AddTransient<IPaperRepositorio, PaperRepositorio>();
            services.AddTransient<IPaperUseCase, PaperUseCase>();
            services.AddTransient<IDocenteUseCase, DocenteUseCase>();
            services.AddTransient<IDocenteRepositorio, ProfesorRepositorio>();
            services.AddTransient<IAutenticacionRepositorio, AutenticationRepositorio>();
            services.AddTransient<IAutenticacionUseCase, AutenticacionUseCase>();
            services.AddTransient<IAutorRepositorio, AutorRepositorio>();
            services.AddTransient<IAutorUseCase, AutorUseCase>();
            services.AddTransient<IProyectoAutorRepositorio, ProyectoAutorRepositorio>();
            services.AddTransient<IProyectoAutorUseCase, ProyectoAutorUseCase>();

            services.AddAutoMapper();

            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("SecretKey"));
            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
//            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//                .AddJwtBearer(options => {
//                    options.TokenValidationParameters = new TokenValidationParameters() {
//                        ValidateIssuer = true,
//                        ValidateAudience = true,
//                        ValidateLifetime = true,
//                        ValidateIssuerSigningKey = true,
//                        ValidIssuer = Configuration["JWT:Issuer"],
//                        ValidAudience = Configuration["JWT:Audience"],
//                        IssuerSigningKey = new SymmetricSecurityKey(
//                            Encoding.UTF8.GetBytes(Configuration["JWT:ClaveSecreta"]))
//                    };
//                });


            /*services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppContext>()
                .AddDefaultTokenProviders();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["pepe"],
                    ValidateAudience = Convert.ToBoolean(Configuration["pepe"]),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["pepito"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
            */

            
            services.AddCors(options => {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder => {
                        builder.WithOrigins("http://localhost:3000")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .DisallowCredentials();
                        //.AllowCredentials();
                    });
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AppContext appContext) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                // IdentityModelEventSource.ShowPII = true;
            }

            else
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            
            
            app.UseCors(MyAllowSpecificOrigins);
            app.UseStaticFiles();
            //app.UseAuthentication();
            app.UseMvc();
            
            // appContext.Database.Migrate();

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
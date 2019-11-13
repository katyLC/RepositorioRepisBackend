using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RespositorioREPIS.Data;
using RespositorioREPIS.Data.DbModel;
using RespositorioREPIS.Data.Repositorio;
using RespositorioREPIS.Domain.Repositories;
using RespositorioREPIS.Domain.UseCases.Alumno;
using RespositorioREPIS.Domain.UseCases.Ciclo;
using RespositorioREPIS.Domain.UseCases.Curso;
using RespositorioREPIS.Domain.UseCases.PalabrasClaves;
using RespositorioREPIS.Domain.UseCases.Paper;
using RespositorioREPIS.Domain.UseCases.Perfil;
using RespositorioREPIS.Domain.UseCases.Proyecto;
using RespositorioREPIS.Domain.UseCases.ProyectoKeyword;
using RespositorioREPIS.Domain.Validators;

namespace RespositorioREPIS
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
//            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddFluentValidation();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

//            services.AddMvc(options => { options.Filters.Add(new ModelStateFilter()); }).AddFluentValidation(options =>
//            {
//                options.RegisterValidatorsFromAssemblyContaining<Startup>();
//            });

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory(MyAllowSpecificOrigins));
            });

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .DisallowCredentials();
                    });
            });


            services.AddDbContext<AppContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IRegistrarAlumno, RegistrarAlumno>();
            services.AddTransient<IAlumnoRepositorio, AlumnoRepositorio>();
            services.AddTransient<ICicloUseCase, CicloUseCase>();
            services.AddTransient<ICicloRepositorio, CicloRepositorio>();
            services.AddTransient<IPerfilUseCase, PerfilUseCase>();
            services.AddTransient<IPerfilRepositorio, PerfilRepositorio>();
            services.AddTransient<ICursoUseCase, CursoUseCaseUseCase>();
            services.AddTransient<ICursoRepositorio, CursoRepositorio>();
            services.AddTransient<IPalabrasClaves, PalabrasClaves>();
            services.AddTransient<IPalabrasClavesRepositorio, PalabarasClavesRepositorio>();
            services.AddTransient<IProyectoUseCase, ProyectoUseCase>();
            services.AddTransient<IProyectoRepositorio, ProyectoRepositortio>();
            services.AddTransient<IProyectoKeywordRepositorio, ProyectoKeywordRepositorio>();
            services.AddTransient<IProyectoKeywordUseCase, ProyectoKeywordUseCase>();
            services.AddTransient<IPaperRepositorio, PaperRepositorio>();
            services.AddTransient<IPaperUseCase, PaperUseCase>();
//            services.AddSingleton<IValidator<ProyectoKeyword>, ProyectoKeywordValidation>();


//            services.Configure<ApiBehaviorOptions>(options =>
//            {
//                options.InvalidModelStateResponseFactory = context =>
//                {
//                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage))
//                        .ToList();
//
//                    var result = new
//                    {
//                        Message = "Error de validación",
//                        Errors = errors
//                    };
//
//                    return new BadRequestObjectResult(result);
//                };
//            });

            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            //app.UseHttpsRedirection();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseMvc();
        }
    }
}
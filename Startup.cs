using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RespositorioREPIS.Data;
using RespositorioREPIS.Domain.Entities;
using RespositorioREPIS.Domain.Repositories;
using RespositorioREPIS.Domain.UseCases.Alumno;
using RespositorioREPIS.Domain.UseCases.Ciclo;
using RespositorioREPIS.Domain.UseCases.Curso;
using RespositorioREPIS.Domain.UseCases.PalabrasClaves;
using RespositorioREPIS.Domain.UseCases.PerfilProyecto;
using RespositorioREPIS.Domain.UseCases.Proyecto;
using AppContext = RespositorioREPIS.Data.AppContext;
using Curso = RespositorioREPIS.Domain.Entities.Curso;
using Proyecto = RespositorioREPIS.Domain.Entities.Proyecto;

namespace RespositorioREPIS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

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
            services.AddTransient<IAlumnoRepositorio, Alumno>();
            services.AddTransient<ICicloListar, CicloListar>();
            services.AddTransient<ICicloRepositorio, CicloRepositorio>();
            services.AddTransient<IListarPerfilProyecto, PerfilListar>();
            services.AddTransient<IPerfilesRepositorio, PerfilRepositorio>();
            services.AddTransient<ICurso, Domain.UseCases.Curso.Curso>();
            services.AddTransient<ICursoRepositorio, CursoRepositorio>();
            services.AddTransient<IPalabrasClaves, PalabrasClaves>();
            services.AddTransient<IPalabrasClavesRepositorio, PalabarasClavesRepositorio>();
            services.AddTransient<IProyecto, Domain.UseCases.Proyecto.Proyecto>();
            services.AddTransient<IProyectoRepositorio, ProyectoRepositortio>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseMvc();
        }
    }
}
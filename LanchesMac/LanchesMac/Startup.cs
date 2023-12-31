﻿using Microsoft.EntityFrameworkCore;
using LanchesMac.Context;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LanchesMac
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Este método é usado para configurar serviços (injeção de dependência)
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration
                 .GetConnectionString("DefaultConnection")));

            services.AddTransient<ILancheRepository, LancheRepository>();//Cria instancia por meio do conteiner DI/injeção de dep e inversão de controle
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddMemoryCache();
            services.AddSession();
        }

        // Este método é usado para configurar o pipeline de middleware HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
 }


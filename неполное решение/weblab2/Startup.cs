using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using weblab2.Domain;
using weblab2.Domain.Repositories.Abstract;
using weblab2.Domain.Repositories.EntityFramework;
using weblab2.Service;

namespace weblab2
{
    
    public class Startup
    {       
        public IConfiguration Configuration { get;  }
        public Startup(IConfiguration configuration) => Configuration = configuration;


        public void ConfigureServices(IServiceCollection services)
        {
            //подключаем конфиг из appsettigs.json
            Configuration.Bind("Project", new Config());
            //подключаем нужный функционал приложения в качестве сервисов
            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            services.AddTransient<IServiceItemRepository, EFServiceItemRepository>();
            services.AddTransient<DataManager>();

            //подключаем контекст БД
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            //настраиваем identity систему
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //настраиваем authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "MyCompanyAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });
            //настраиваем политику авторизации для admin area
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            //добавляем поддержку контроллеров и представления (mvc)
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAutorization("Admin", "AdminArea"));
            })
                // выставляем совместимость с asp.net core 3.0
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //отчет для дебага (разраба)
                app.UseDeveloperExceptionPage();
            }
            //подключаем систему марщрутизации
            app.UseRouting();

            //подключаем аунтификацию и авторизацию
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            //подключаем поддержку статичных файлов в приложении
            app.UseStaticFiles();
            
            //регистрируем нужные маршруты
            app.UseEndpoints(endpoints =>
            {
                //для админа
                endpoints.MapControllerRoute(
                    name:"admin", 
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                //если по url запрос не приходит 
                endpoints.MapControllerRoute(
                    name: "default", 
                    pattern:"{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository;
using ClassLibrary_RepositoryDLL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using ClassLibrary_RepositoryDLL.Mappings;
using ClassLibrary_RepositoryDLL.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookEcommerce_ASP.NETCore_MVC
{
    public class Startup
    {
        public IConfiguration _configuration1;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            this._configuration1 = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppDbConnection>(options =>
            {
                options.ConnectionString = _configuration1.GetConnectionString("GlobalConnectionString");
            });

            services.AddControllersWithViews();
            services.AddDbContext<BookEcommerceContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GlobalConnectionString")));
            //declare for AutoMapper
            services.AddAutoMapper
                (typeof(MappingProfile).Assembly);

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            
            //declare for Services
            services.AddMvc();
            services.AddOptions();
            services.AddTransient<IRepositoryCheckOut, RepositoryCheckOut>();


            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IProductService, ProductService>();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);//We set Time here 
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
    }
    
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            app.UseSession();//add this sesstion function here
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Report}/{action=Print}/{id?}");

               // endpoints.MapControllerRoute(
                //    name: "default",
                 //   pattern: "{controller=Home}/{action=Index}/{id?}");
               
               // endpoints.MapControllerRoute(
                    //  name: "areas",
                 //     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            //);
        });

        }
    }
}

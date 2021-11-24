using System;
using System.Threading.Tasks;
using TheBezitEstateApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheBezitEstateApp.Web.Interfaces;
using TheBezitEstateApp.Web.Services;
using TheBezitEstateApp.Data.DatabaseContexts.ApplicationDbContext;
using TheBezitEstateApp.Data.DatabaseContexts.AuthenticationDbContext;


namespace TheBezitEstateApp.Web
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
            services.AddDbContextPool<AuthenticationDatabase>(options => options.UseSqlServer (Configuration.GetConnectionString("AuthenticationConnection"),
                sqlServerOptions => {
                sqlServerOptions.MigrationsAssembly("TheBezitEstateApp.Data");
                }       
            ));

            services.AddDbContextPool<ApplicationDatabase>(options => options.UseSqlServer (Configuration.GetConnectionString("ApplicationConnection"),
                sqlServerOptions => {
                    sqlServerOptions.MigrationsAssembly("TheBezitEstateApp.Data");

                }
            ));

            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AuthenticationDatabase>()
            .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 7;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });
        

            services.AddControllersWithViews();
            services.AddTransient<IAccountService, AccountService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider svp)
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            MigrateDatabaseContexts(svp);
            CreateDefaultRolesandUsers(svp).GetAwaiter().GetResult();
        }

        public void MigrateDatabaseContexts(IServiceProvider svp)
        {
            var authenticationDbContext = svp.GetRequiredService<AuthenticationDatabase>();
            authenticationDbContext.Database.Migrate();

            var applicationDbContext = svp.GetRequiredService<ApplicationDatabase>();
            applicationDbContext.Database.Migrate();
        }

        public async Task CreateDefaultRolesandUsers(IServiceProvider svp)
        {
            string[] roles = new string[] {"SystemAdministrator", "Agent", "User"};
            var userEmail = "admin@estateapp.com";
            var userPassword = "kennyG099@2021";

            var roleManager = svp.GetRequiredService<RoleManager<IdentityRole>>();
            foreach (var role in roles)
            {
                var roleExists = await roleManager.RoleExistsAsync(role);
                if(!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole{Name = role});
                }
            }

            var userManager = svp.GetRequiredService<UserManager<ApplicationUser>>();
            var user = await userManager.FindByEmailAsync(userEmail);
            if(user is null)
            {
                user = new ApplicationUser
                {
                    Email = userEmail,
                    UserName = userEmail,
                    EmailConfirmed = true,
                    PhoneNumber = "+2348071187953",
                    PhoneNumberConfirmed = true
                };

                await userManager.CreateAsync(user, userPassword);
                await userManager.AddToRolesAsync(user, roles);

            }
           
        }
    }
}

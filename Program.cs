using GymApp.Repository.ModelsRepos;
using GymManagementSystem.Models;
using GymManagementSystem.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.4
            builder.Services.AddControllersWithViews();
            //builder.Services.AddRazorPages();


            builder.Services.AddDbContext<GymManagementContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("GymCon")));

            builder.Services.AddScoped<IClassRepository, ClassRepository>();
            builder.Services.AddScoped<ICoachRepository, CoachRepository>();
            builder.Services.AddScoped<IDietPlanRepository, DietPlanRepository>();
            builder.Services.AddScoped<IInBodyTestRepository, InBodyTestRepository>();
            builder.Services.AddScoped<IMembershipTypeRepository, MembershipTypeRepository>();
            builder.Services.AddScoped<IWorkOutProgramRepository, WorkOutProgramRepository>();
            builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(op =>
            {
                op.Password.RequiredLength = 4;
                op.Password.RequireNonAlphanumeric = false;
                op.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<GymManagementContext>();
            builder.Services.AddSession();
            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                //app.UseExceptionHandler("/Error");
                //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseSession();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
              name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}").WithStaticAssets();

            app.Run();
        }
    }
}

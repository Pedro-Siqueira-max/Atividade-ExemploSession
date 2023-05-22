using ExemploSession.Models;
using Microsoft.EntityFrameworkCore;


namespace ExemploSession
{
    public class Startup
    {
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
			services.AddDistributedMemoryCache();
			services.AddSession(options => {
				options.IdleTimeout = TimeSpan.FromMinutes(1);
			});
			services.AddDbContext<Context>(options => options.UseSqlServer(
				   Configuration["Data:ExemploSession:ConnectionString"]));
			services.AddMvc();
		}

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
					pattern: "{controller=Session}/{action=Create}/{id?}");
			});
			SeedData.EnsurePopulated(app);
		}
	}
}


using HotelCalifornia.OnlineStore.Infrastructure.Data.Basket;
using HotelCalifornia.OnlineStore.Infrastructure.Data.Order;
using HotelCalifornia.OnlineStore.Infrastructure.Data.Thingy;
using HotelCalifornia.OnlineStore.Infrastructure.DataProcessors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HotelCalifornia.OnlineStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddFeatureFolders();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IThingyRepository, ThingyRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPspProcessor, PspProcessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
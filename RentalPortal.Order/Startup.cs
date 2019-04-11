using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RentalPortal.Order.Data;
using RentalPortal.Order.Persistence.Repository;
using RentalPortal.Order.Persistence.Repository.Interfaces;
using RentalPortal.Order.Service;
using RentalPortal.Order.Service.Interfaces;

namespace RentalPortal.Order
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
            // Add framework services.
            services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OrderDbContext")));
           // services.AddScoped<ICartService, CartService>();
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            // services.AddScoped<IOrderService, OrderService>();
            //   services.AddScoped<IServiceHelper, ServiceHelper>();
            services.AddSingleton<IUnitOfWork, UnitOfWork<OrderDbContext>>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMemoryCache();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}

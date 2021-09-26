using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TopChoiceHardware.OrdersService.AccessData;
using Microsoft.EntityFrameworkCore;
using TopChoiceHardware.OrdersService.Application.Services;
using Microsoft.OpenApi.Models;
using TopChoiceHardware.OrdersService.Domain.Commands;
using TopChoiceHardware.OrdersService.AccessData.Commands;

namespace TopChoiceHardware.Orders.Service
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TopChoiceHardware.OrderService", Version = "v1" });
            });
            var connectionString = Configuration.GetSection("ConnectionString").Value;
            services.AddDbContext<OrdenesContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IGenericRepository, GenericRepository>();
            services.AddTransient<IOrdenesService, OrdenesService>();
            services.AddTransient<IFacturaService, FacturaService>();
            services.AddTransient<IMetodoPagoService, MetodoPagoService>();
            services.AddTransient<IOrdenProductoService, OrdenProductoService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TopChoiceHardware.UsersService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

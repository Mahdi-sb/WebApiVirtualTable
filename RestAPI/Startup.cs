using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Context;
using Service.AddNewTable;
using Service.Addvalue;
using Service.ShowInformation;
using Validation.AddNewTable;
using Validation.AddValueToDB;

namespace RestAPI
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
            services.AddDbContext<AppDbContext>(option =>
            option.UseSqlServer(Configuration.GetConnectionString("DBContextConnection")));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IAddTable, AddTable>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICheckTableInput, ValidationTable>();
            services.AddTransient<IAddValue, AddValueToDb>();
            services.AddTransient<ICheckValue, CheckValue>();
            services.AddTransient<IShowInfo, ShowInfo>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

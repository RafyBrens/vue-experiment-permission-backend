
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RequestPermission.Business.Entities.Mappers;
using RequestPermission.Contracts.Contract;
using RequestPermission.Database;
using RequestPermission.Repositores.Repository;

namespace RequestPermission.Api
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
            services.AddDbContext<RequestPermissionContext>(op =>
            {
                var conection = new SqlConnection("Data Source=DESKTOP-31A9CQK\\VBMSSQLSERVER;Initial Catalog=RequestPermission;Integrated Security=True");
                op.UseSqlServer(conection);
            });

            //repo:

            services.AddTransient<IPermissionRepository, PermissionRepository>();

            var mappinConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PermissionMappingProfile());
            });

            IMapper mapper = mappinConfig.CreateMapper();
            services.AddSingleton(mapper);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors("AllowAllOrigins");
            app.UseCors(op => op.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
        }
    }
}

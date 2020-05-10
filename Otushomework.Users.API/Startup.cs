using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Otushomework.Users.API.Configuration;
using Otushomework.Users.API.Stores;

namespace Otushomework.Users.API
{
    public class Startup
    {
        private const string DbServer = "DATABASE_URI";
        private const string DbBase = "POSTGRES_DB";
        private const string DbUser = "POSTGRES_USER";
        private const string DbPass = "POSTGRES_PASSWORD";
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperApiProfile));
            
            services.AddDbContext<UsersDbConext>(options =>
                options
                    //.UseNpgsql(BuildConnectionString(Configuration))//(Configuration.GetConnectionString("DefaultConnection"))
                    .UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
                    .UseSnakeCaseNamingConvention());
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseExceptionHandler(ErrorHandlingMiddleware.Action);

            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
           // }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        public static string BuildConnectionString(IConfiguration configuration)
        {
            var dbPort = "5432";
            var dbServer = configuration[DbServer];
            Debug.WriteLine("dbServer=" + dbServer);

            if (dbServer != null)
            {
                var parts = dbServer.Split(":");
                if (parts.Length == 2)
                {
                    dbServer = parts[0];
                    dbPort = parts[1];
                }
            }

            var dbBase = configuration[DbBase];
            Debug.WriteLine("dbBase=" + dbBase);
            
            var dbUser = configuration[DbUser];
            Debug.WriteLine("dbUser=" + dbUser);

            var dbPass = configuration[DbPass];
            Debug.WriteLine("dbPass=" + dbPass);

            var connStringTemplate =
                $"Server={dbServer};Port={dbPort};Database={dbBase};UserId={dbUser};Password={dbPass};";

            return connStringTemplate;
        }
    }
}

using MicroService.Api.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Api
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
            services.AddAuthentication("Bearer")//Scheme：就是指定读信息的方式Bearer- 
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://114.55.174.153:8001";//ids4的地址--专门获取公钥
                    options.ApiName = "user_api";
                    options.RequireHttpsMetadata = false;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();//鉴权--拆解信息，验证有没有用户

            app.UseAuthorization();//授权，检测有没有权限

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            this.Configuration.ConsulRegist();//注册服务到consul
        }
    }
}

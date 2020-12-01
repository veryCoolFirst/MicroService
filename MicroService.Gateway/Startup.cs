using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelot.Cache.CacheManager;
using Ocelot.Cache;
using MicroService.Gateway.Utility;

namespace MicroService.Gateway
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region Ids4
            var authenticationProviderKey = "UserGatewayKey";
            services.AddAuthentication("Bearer")
               .AddIdentityServerAuthentication(authenticationProviderKey, options =>
               {
                   options.Authority = "http://114.55.174.153:8001";
                   //options.Authority = "http://114.55.174.153:8001";
                   options.ApiName = "user_api";
                   options.RequireHttpsMetadata = false;
                   options.SupportedTokens = SupportedTokens.Both;
               });
            #endregion

            //services.AddControllers();
            services.AddOcelot()//Ocelot��δ���
                .AddConsul()//֧��Consul
                //.AddCacheManager(x =>
                //{
                //    x.WithDictionaryHandle();//Ĭ���ֵ�洢
                //})//֧�ֻ���
                .AddPolly()//֧���۶�
                ;
            //services.AddSingleton<IOcelotCache<CachedResponse>,CustomCache>();// �Զ���ʵ��ocelot����
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseOcelot().Wait();//���󽻸�Ocelot����
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}

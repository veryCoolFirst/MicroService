using MicroService.AuthenticationCenter.UserApiService;
using MicroService.AuthenticationCenter.Validator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.AuthenticationCenter
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            #region �ڴ淽ʽ
            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()
            //    .AddInMemoryApiResources(OAuthMemoryData.GetApiResources())
            //    .AddInMemoryClients(OAuthMemoryData.GetClients())
            //    .AddTestUsers(OAuthMemoryData.GetTestUsers());
            #endregion

            #region ���ݿ�洢��ʽ
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(OAuthMemoryData.GetApiResources())
                //.AddInMemoryClients(OAuthMemoryData.GetClients())
                .AddClientStore<ClientStore>()
                //.AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                .AddResourceOwnerValidator<RoleTestResourceOwnerPasswordValidator>()
                .AddExtensionGrantValidator<ApiOpenGrantValidator>()
                .AddProfileService<UserProfileService>();//���΢�Ŷ��Զ��巽ʽ����֤
            #endregion

            #region �����¼��ʽ Demo

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseCookiePolicy();
            app.UseIdentityServer();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

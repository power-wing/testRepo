using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
/// <summary>
/// AngularCli の SpaServices
/// </summary>
using Microsoft.AspNetCore.SpaServices.AngularCli;
/// <summary>
/// ヘルパー
/// </summary>
using Helpers;

namespace angularWithWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            // .netCore2.2 のバグ対応のヘルパー
            CurrentDirectoryHelpers.SetCurrentDirectory();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // services.AddSpaStaticFiles(configuration =>
            // {
            //    configuration.RootPath = "angularClient/dist";
            // });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSpa(spa =>
            {
                // angularClientのフォルダ名を設定
                spa.Options.SourcePath = "angularClient";
                
                if (env.IsDevelopment())
                {
                    // クライアント処理の開始
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}

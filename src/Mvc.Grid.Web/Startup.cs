using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Mvc.Grid.Web.Filters;
using NonFactors.Mvc.Grid;
using System;

namespace Mvc.Grid.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMvcGrid(filters => filters.Register(typeof(Boolean), "Is", typeof(BooleanIsNullFilter)));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseIISPlatformHandler();
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}

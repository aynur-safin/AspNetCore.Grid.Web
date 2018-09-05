using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NonFactors.Mvc.Grid.Web.Filters;
using System;

namespace NonFactors.Mvc.Grid.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMvcGrid(filters =>
            {
                filters.BooleanTrueOptionText = () => "True";
                filters.BooleanFalseOptionText = () => "False";
                filters.Register(typeof(Int32), "contains", typeof(NumberContainsFilter));
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
        }
    }
}

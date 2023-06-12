using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ANCEntry_EmptyWeb
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    context.Response.ContentType = "text/html";
                    await context.Response.WriteAsync("<html><head><title>Hello</title></head");
                    await context.Response.WriteAsync("  <body><h1>Hello World!</h1>");
                    await context.Response.WriteAsync("    <p>This is sample asp.net core page.</p>");
                    await context.Response.WriteAsync("</body></html>");
                });
            });
        }
    }
}

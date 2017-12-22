using GitHubFeaturesCore2.Helpers;
using GitHubFeaturesCore2.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GitHubFeaturesCore2
{
    public class GitHubOptions
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }

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
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.AddMvc();
            //Add user's services
            services.AddTransient<IUrlGenerator, UrlGenerator>();
            services.AddTransient<IGithubService, GitHubService>();
            services.AddTransient<ICSharpCompile, CSharpCompileService>();
            services.AddTransient<IResultChecker, ResultChecker>();
            services.Configure<GitHubOptions>(Configuration.GetSection("GitHubOptions"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IUrlGenerator urlGenerator, IGithubService githubService,
            ICSharpCompile sharpCompile, IResultChecker resultChecker)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

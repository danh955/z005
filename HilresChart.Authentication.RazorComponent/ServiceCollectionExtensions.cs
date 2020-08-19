// <copyright file="ServiceCollectionExtensions.cs" company="Hilres">
// Copyright (c) Hilres. All rights reserved.
// </copyright>

namespace HilresChart.Authentication.RazorComponent
{
    using HilresChart.Authentication.RazorComponent.Areas.Identity;
    using HilresChart.Authentication.RazorComponent.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    // Make sure to add MapControllers to Startup.cs
    //        app.UseEndpoints(endpoints =>
    //        {
    //            endpoints.MapControllers();
    //        }

    /// <summary>
    /// Service collection extensions class.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add authentication razor component.
        /// </summary>
        /// <param name="services">IServiceCollection.</param>
        /// <param name="connectionString">Connection string.</param>
        /// <returns>Updated IServiceCollection.</returns>
        public static IServiceCollection AddAuthenticationRazorComponent(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AuthenticationDbContext>(options =>
                        options.UseSqlite(connectionString));

            services.AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<AuthenticationDbContext>();

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

            return services;
        }

        /// <summary>
        /// Use authentication razor component.
        /// </summary>
        /// <param name="app">IApplicationBuilder.</param>
        /// <returns>Updated IApplicationBuilder.</returns>
        public static IApplicationBuilder UseAuthenticationRazorComponent(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
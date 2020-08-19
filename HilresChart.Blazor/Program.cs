// <copyright file="Program.cs" company="Hilres">
// Copyright (c) Hilres. All rights reserved.
// </copyright>

namespace HilresChart.Blazor
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Main program class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main program starts here.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Create host builder.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        /// <returns>IHostBuilder.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
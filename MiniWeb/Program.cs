using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MiniWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
           new WebHostBuilder()
            .UseKestrel()
            .UseIISIntegration()
            .Configure(app =>
            {
                app.Run(async context =>
                {
                    var path = context.Request.Path;
                    await context.Response.WriteAsync($"Hello! You asked {path}");
                });
            });
    }
}

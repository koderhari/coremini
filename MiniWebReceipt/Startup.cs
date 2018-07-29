using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MiniWebReceipt.Insfrastructure;
using MiniWebReceipt.Insfrastructure.Core;
using Newtonsoft.Json;

namespace MiniWebReceipt
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IReceiptItemsRepository>(new ReceiptItemsRepository());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IReceiptItemsRepository repository )
        {

            app.Run(async (context) =>
            {
                var productName = context.Request.Query["q"];
                var result = repository.FindBy(productName).ToList();
                var resultJson = JsonConvert.SerializeObject(result);
                await context.Response.WriteAsync(resultJson);
            });
        }
    }
}

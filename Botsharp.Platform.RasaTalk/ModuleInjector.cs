using BotSharp.Core;
using BotSharp.Core.AgentStorage;
using BotSharp.Core.Modules;
using BotSharp.Platform.Abstraction;
using Botsharp.Platform.RasaTalk.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using Microsoft.AspNetCore.Hosting;

namespace BotSharp.Platform.RasaTalk
{
    public class ModuleInjector : IModule
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<RasaTalkAi<AgentModel>>();
            AgentStorageServiceRegister.Register<AgentModel>(services);
            PlatformConfigServiceRegister.Register<PlatformSettings>("RasaTalkAi", services, config);
        }

        public void Configure(IApplicationBuilder app)
        {

        }

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			
		}
	}
}

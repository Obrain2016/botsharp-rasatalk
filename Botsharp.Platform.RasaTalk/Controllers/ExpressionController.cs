using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Botsharp.Platform.RasaTalk.Models;
using BotSharp.Platform.RasaTalk;
using BotSharp.Platform.RasaTalk.ViewModels;
using DotNetToolkit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace Botsharp.Platform.RasaTalk.Controllers
{
	[Route("api/[controller]")]
	public class ExpressionController : ControllerBase
	{
		private RasaTalkAi<AgentModel> builder;

		public ExpressionController(RasaTalkAi<AgentModel> platform)
		{
			builder = platform;
		}

		[HttpGet("{agentName}/intent/{intentName}")]
		public async Task<List<ExpressionModel>> GetExpressionsByIntent([FromRoute] string agentName, [FromRoute] string intentName)
		{
			var agent = await builder.GetAgentByName(agentName);

			return agent.Intents.First(x => x.Name == intentName).Expressions;
		}
	}
}

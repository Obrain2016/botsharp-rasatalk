using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Botsharp.Platform.RasaTalk.Models;
using BotSharp.Platform.RasaTalk;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Botsharp.Platform.RasaTalk.Controllers
{
	[Route("api/[controller]")]
	public class AgentsController : ControllerBase
    {
		private RasaTalkAi<AgentModel> builder;

		/// <summary>
		/// Initialize agent controller and get a platform instance
		/// </summary>
		/// <param name="platform"></param>
		public AgentsController(RasaTalkAi<AgentModel> platform)
		{
			builder = platform;
		}

		[HttpPut]
		public async Task<AgentModel> PutAgent()
		{
			AgentModel agent = null;

			using (var reader = new StreamReader(Request.Body))
			{
				string body = reader.ReadToEnd();
				agent = JsonConvert.DeserializeObject<AgentModel>(body);
			}

			// convert to standard Agent structure
			agent.Name = agent.Agent;
			await builder.SaveAgent(agent);

			return agent;
		}

		[HttpGet]
		public async Task<List<AgentModel>> GetAgent()
		{
			var results = await builder.GetAllAgents();
			var agents = results.ToList();

			return agents;
		}

		[HttpPost]
		public async Task<AgentModel> PostAgent()
		{
			AgentModel agent = null;

			using (var reader = new StreamReader(Request.Body))
			{
				string body = reader.ReadToEnd();
				agent = JsonConvert.DeserializeObject<AgentModel>(body);
			}

			// convert to standard Agent structure
			agent.Name = agent.Agent;
			await builder.SaveAgent(agent);

			return agent;
		}
		/*
		[HttpGet("/api/intents/{Agent}")]
		public async Task<AgentModel> GetIntentsByAgent([FromRoute] string agent)
		{
			var intents = await builder.GetIntentsByAgent(agent);

			return intents;
		}*/
	}
}

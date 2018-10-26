using Botsharp.Platform.RasaTalk;
using Botsharp.Platform.RasaTalk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotSharp.Platform.RasaTalk.Controllers
{
    [Route("api/[controller]")]
    public class EntitiesController : ControllerBase
    {
        private RasaTalkAi<AgentModel> builder;

        public EntitiesController(RasaTalkAi<AgentModel> platform)
        {
            builder = platform;
        }

        [HttpGet("{entityId}")]
        public async Task<EntityModel> GetEntity([FromRoute] string entityId)
        {
            string dataDir = Path.Combine(AppDomain.CurrentDomain.GetData("DataPath").ToString(), "Articulate");

            string dataPath = Directory.GetFiles(dataDir).FirstOrDefault(x => x.EndsWith($"-entity-{entityId}.json"));

            string json = System.IO.File.ReadAllText(dataPath);

            var entity = JsonConvert.DeserializeObject<EntityModel>(json);

            return entity;
        }

        [HttpGet("/agent/{agentId}/entity")]
        public async Task<EntityPageViewModel> GetAgentEntities([FromRoute] string agentId, [FromQuery] int start, [FromQuery] int limit)
        {
            var agent = await builder.GetAgentById(agentId);
            return new EntityPageViewModel { Entities = agent.Entities.Select(x => x as EntityModel).ToList(), Total = agent.Entities.Count };
        }

        [HttpPost]
        public async Task<EntityModel> PostEntity()
        {
            EntityModel entity = null;

            using (var reader = new StreamReader(Request.Body))
            {
                string body = reader.ReadToEnd();
                entity = JsonConvert.DeserializeObject<EntityModel>(body);
            }

            var agent = await builder.GetAgentByName(entity.Agent);
            entity.Id = Guid.NewGuid().ToString();
            agent.Entities.Add(entity);

            await builder.SaveAgent(agent);

            return entity;
        }
    }
}

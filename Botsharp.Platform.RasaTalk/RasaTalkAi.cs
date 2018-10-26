using BotSharp.Core;
using BotSharp.Core.Engines;
using BotSharp.Platform.Abstraction;
using BotSharp.Platform.Models;
using BotSharp.Platform.Models.AiRequest;
using BotSharp.Platform.Models.AiResponse;
using BotSharp.Platform.Models.MachineLearning;
using Botsharp.Platform.RasaTalk.Models;
using DotNetToolkit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BotSharp.Platform.RasaTalk
{
	/// <summary>
	/// A platform for building conversational interfaces with intelligent agents (chatbots) 
	/// This implementation takes over APIs of RasaTalk's 7500 port.
	/// </summary>
	public class RasaTalkAi<TAgent> :
		PlatformBuilderBase<TAgent>,
		IPlatformBuilder<TAgent>
		where TAgent : AgentModel
	{
		IAgentStorage<TAgent> IPlatformBuilder<TAgent>.Storage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public RasaTalkAi(IAgentStorageFactory<TAgent> agentStorageFactory, IPlatformSettings settings)
			: base(agentStorageFactory, settings)
		{

		}

		public Task<TrainingCorpus> ExtractorCorpus(TAgent agent)
		{
			throw new NotImplementedException();
		}

		public Task<TResult> TextRequest<TResult>(AiRequest request)
		{
			throw new NotImplementedException();
		}

		/*public async Task<Tuple<TAgent, DomainModel>> GetAgentByDomainId(String domainId)
		{
			var results = await GetAllAgents();

			foreach (TAgent agent in results)
			{
				var domain = agent.Domains.FirstOrDefault(x => x.Id == domainId);

				if (domain != null)
				{
					return new Tuple<TAgent, DomainModel>(agent, domain);
				}
			}

			return null;
		}

		public async Task<Tuple<TAgent, DomainModel, IntentModel>> GetAgentByIntentId(String intentId)
		{
			var results = await GetAllAgents();

			foreach (TAgent agent in results)
			{
				foreach (DomainModel domain in agent.Domains)
				{
					var intent = domain.Intents.FirstOrDefault(x => x.Id == intentId);
					if (intent != null)
					{
						return new Tuple<TAgent, DomainModel, IntentModel>(agent, domain, intent);
					}
				}
			}

			return null;
		}

		public async Task<List<IntentModel>> GetReferencedIntentsByEntity(string entityId)
		{
			var intents = new List<IntentModel>();
			var allAgents = await GetAllAgents();
			foreach (TAgent agent in allAgents)
			{
				foreach (DomainModel domain in agent.Domains)
				{
					foreach (IntentModel intent in domain.Intents)
					{
						if (intent.Examples.Exists(x => x.Entities.Exists(y => y.EntityId == entityId)))
						{
							intents.Add(intent);
						}
					}
				}
			}

			return intents;
		}

		public async Task<TrainingCorpus> ExtractorCorpus(TAgent agent)
		{
			var corpus = new TrainingCorpus();
			corpus.Entities = agent.Entities.Select(x => new TrainingEntity
			{
				Entity = x.EntityName,
				Values = x.Examples.Select(y => new TrainingEntitySynonym
				{
					Value = y.Value,
					Synonyms = y.Synonyms
				}).ToList()
			}).ToList();

			corpus.UserSays = new List<TrainingIntentExpression<TrainingIntentExpressionPart>>();

			foreach (DomainModel domain in agent.Domains)
			{
				foreach (IntentModel intent in domain.Intents)
				{
					foreach (IntentExampleModel example in intent.Examples)
					{
						var say = new TrainingIntentExpression<TrainingIntentExpressionPart>()
						{
							Intent = intent.IntentName,
							Text = example.UserSays,
							Entities = example.Entities.Select(x => new TrainingIntentExpressionPart
							{
								Entity = x.Entity,
								Start = x.Start,
								Value = x.Value
							}).ToList()
						};

						corpus.UserSays.Add(say);
					}
				}
			}

			return corpus;
		}

		public override async Task<bool> SaveAgent(TAgent agent)
		{
			agent.Status = "Changed";
			agent.LastTraining = DateTime.UtcNow;
			return await base.SaveAgent(agent);
		}

		public async Task<AiResponse> TextRequest(AiRequest request)
		{
			var aiResponse = new AiResponse();

			// Load agent
			var projectPath = Path.Combine(AppDomain.CurrentDomain.GetData("DataPath").ToString(), "Projects", request.AgentId);
			var model = Directory.GetDirectories(projectPath).Where(x => x.Contains("model_")).Last().Split(Path.DirectorySeparatorChar).Last();
			var modelPath = Path.Combine(projectPath, model);
			request.AgentDir = projectPath;
			request.Model = model;

			var agent = await GetAgentById(request.AgentId);

			var preditor = new BotPredictor();
			var doc = await preditor.Predict(agent, request);

			var parameters = new Dictionary<String, Object>();
			if (doc.Sentences[0].Entities == null)
			{
				doc.Sentences[0].Entities = new List<NlpEntity>();
			}
			doc.Sentences[0].Entities.ForEach(x => parameters[x.Entity] = x.Value);

			aiResponse.Intent = doc.Sentences[0].Intent.Label;
			aiResponse.Speech = $"intent is {aiResponse.Intent}";
			agent.Domains.ForEach(domain => domain.Intents.ForEach(intent =>
			{
				if (intent.IntentName == aiResponse.Intent)
				{
					aiResponse.Speech = intent.Scenario.IntentResponses.Random();
				}
			}));

			return aiResponse;
		}

		Task<TrainingCorpus> IPlatformBuilder<TAgent>.ExtractorCorpus(TAgent agent)
		{
			throw new NotImplementedException();
		}

		Task<TAgent> IPlatformBuilder<TAgent>.LoadAgentFromFile<TImporter>(string dataDir)
		{
			throw new NotImplementedException();
		}

		Task<bool> IPlatformBuilder<TAgent>.SaveAgent(TAgent agent)
		{
			throw new NotImplementedException();
		}

		Task<ModelMetaData> IPlatformBuilder<TAgent>.Train(TAgent agent, TrainingCorpus corpus, BotTrainOptions options)
		{
			throw new NotImplementedException();
		}

		Task<TResult> IPlatformBuilder<TAgent>.TextRequest<TResult>(AiRequest request)
		{
			throw new NotImplementedException();
		}*/
	}
}

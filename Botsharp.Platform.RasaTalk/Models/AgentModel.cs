using System;
using System.Collections.Generic;
using System.Text;
using BotSharp.Platform.Models;
using BotSharp.Platform.RasaTalk.Models;

namespace Botsharp.Platform.RasaTalk.Models
{
	public class AgentModel : AgentBase

	{
		public string Agent { get; set; }

		public string Avater { get; set; }

		public string Subtitle { get; set; }

		public List<IntentModel> Intents { get; set; }

		public AgentModel()
		{
			Intents = new List<IntentModel>();

		}
	}
}

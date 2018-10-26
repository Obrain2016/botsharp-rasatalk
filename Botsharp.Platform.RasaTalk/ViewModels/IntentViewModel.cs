using BotSharp.Platform.RasaTalk.Models;
using BotSharp.Platform.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotSharp.Platform.RasaTalk.ViewModels
{
    public class IntentViewModel : IntentBase
    {
        public string Agent { get; set; }

		public string Subtitle { get; set; }

		public List<IntentModel> Intents { get; set; }

    }
}

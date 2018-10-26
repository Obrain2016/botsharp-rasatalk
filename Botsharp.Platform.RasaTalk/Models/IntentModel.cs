using Botsharp.Platform.RasaTalk.Models;
using BotSharp.Platform.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotSharp.Platform.RasaTalk.Models
{
    public class IntentModel : IntentBase
    {
        public string Name { get; set; }


        /// <summary>
        /// User says
        /// </summary>
        public List<ExpressionModel> Expressions { get; set; }

        /// <summary>
        /// Intent responses
        /// </summary>
        /// public ScenarioModel Scenario { get; set; }
    }
}

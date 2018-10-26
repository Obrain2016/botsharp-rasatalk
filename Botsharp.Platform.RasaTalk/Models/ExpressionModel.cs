using System;
using System.Collections.Generic;
using System.Text;
using BotSharp.Platform.Models;

namespace Botsharp.Platform.RasaTalk.Models
{
    public class ExpressionModel
    {
		public string Id { get; set; }
		public string Intent { get; set; }
		public string Value { get; set; }
		public List<RasaTalkTrainingIntentExpressionPart> Entities { get; set; }

	}
	public class RasaTalkTrainingIntentExpressionPart : TrainingIntentExpressionPart
	{
		public string EntityId { get; set; }
	}
	
}

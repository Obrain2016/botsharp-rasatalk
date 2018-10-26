using BotSharp.Platform.Abstraction;
using BotSharp.Platform.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotSharp.Platform.RasaTalk.Models
{
    public class EntityModel : EntityBase
    {
        public string Date { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        //public List<EntitySynonymModel> Examples { get; set; }
    }
}

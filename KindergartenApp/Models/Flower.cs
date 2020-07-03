using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace KindergartenApp.Models
{
    public enum FlowerUpkeepDifficulty
    {
        Easy,
        Medium, 
        Hard      
    }
    public class Flower
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public long MarketPrice { get;set; }
        public FlowerUpkeepDifficulty FlowerUpkeepDificulty { get; set; }

    }
}

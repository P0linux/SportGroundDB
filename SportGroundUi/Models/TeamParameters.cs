using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportGroundUI.Models
{
    public class TeamParameters
    {
        public string Name { get; set; }
        public decimal PlayersNumber { get; set; }
        public DateTime DateOfCreation { get; set; }
        public decimal RewardNumber { get; set; }
        public string SectionName { get; set; }
    }
}

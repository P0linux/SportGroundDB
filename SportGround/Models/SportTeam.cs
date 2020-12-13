using System;
using System.Collections.Generic;

#nullable disable

namespace SportGround.Models
{
    public partial class SportTeam
    {
        public SportTeam()
        {
            CompTeamParticipants = new HashSet<CompTeamParticipant>();
            TeamPlayers = new HashSet<TeamPlayer>();
            TeamTrainings = new HashSet<TeamTraining>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PlayersNumber { get; set; }
        public DateTime DateOfCreation { get; set; }
        public decimal RewardNumber { get; set; }
        public int? SportSectionId { get; set; }

        public virtual SportSection SportSection { get; set; }
        public virtual ICollection<CompTeamParticipant> CompTeamParticipants { get; set; }
        public virtual ICollection<TeamPlayer> TeamPlayers { get; set; }
        public virtual ICollection<TeamTraining> TeamTrainings { get; set; }
    }
}

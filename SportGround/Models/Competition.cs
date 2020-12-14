using System;
using System.Collections.Generic;

#nullable disable

namespace SportGround.Models
{
    public partial class Competition: IBaseModel
    {
        public Competition()
        {
            CompParticipants = new HashSet<CompParticipant>();
            CompTeamParticipants = new HashSet<CompTeamParticipant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Reward { get; set; }
        public DateTime? CompetitionDateTime { get; set; }
        public decimal ParticipantsMaxNumber { get; set; }
        public decimal? ParticipantsNumber { get; set; }
        public string CompetitionType { get; set; }
        public int? SportTypeId { get; set; }

        public virtual SportType SportType { get; set; }
        public virtual ICollection<CompParticipant> CompParticipants { get; set; }
        public virtual ICollection<CompTeamParticipant> CompTeamParticipants { get; set; }
    }
}

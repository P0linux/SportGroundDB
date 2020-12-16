using System;
using System.Collections.Generic;

#nullable disable

namespace SportGroundView.Models
{
    public partial class Visitor
    {
        public Visitor()
        {
            CompParticipants = new HashSet<CompParticipant>();
            IndividualTrainings = new HashSet<IndividualTraining>();
            SectionVisitors = new HashSet<SectionVisitor>();
            TeamPlayers = new HashSet<TeamPlayer>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Age { get; set; }
        public string Sex { get; set; }

        public virtual ICollection<CompParticipant> CompParticipants { get; set; }
        public virtual ICollection<IndividualTraining> IndividualTrainings { get; set; }
        public virtual ICollection<SectionVisitor> SectionVisitors { get; set; }
        public virtual ICollection<TeamPlayer> TeamPlayers { get; set; }
    }
}

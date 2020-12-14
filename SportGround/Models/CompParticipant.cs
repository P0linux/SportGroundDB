using System;
using System.Collections.Generic;

#nullable disable

namespace SportGround.Models
{
    public partial class CompParticipant: IBaseModel
    {
        public int Id { get; set; }
        public decimal? Result { get; set; }
        public decimal? ParticipantNumber { get; set; }
        public string ParticipantCategory { get; set; }
        public int? CompetitionId { get; set; }
        public int? VisitorId { get; set; }

        public virtual Competition Competition { get; set; }
        public virtual Visitor Visitor { get; set; }
    }
}

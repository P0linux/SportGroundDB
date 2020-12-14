using System;
using System.Collections.Generic;

#nullable disable

namespace SportGround.Models
{
    public partial class CompTeamParticipant: IBaseModel
    {
        public int Id { get; set; }
        public decimal? Result { get; set; }
        public decimal? ParticipantNumber { get; set; }
        public string ParticipantCategory { get; set; }
        public int? CompetitionId { get; set; }
        public int? SportTeamId { get; set; }

        public virtual Competition Competition { get; set; }
        public virtual SportTeam SportTeam { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace SportGround.Models
{
    public partial class TeamTraining
    {
        public int Id { get; set; }
        public DateTime? TrainingDateTime { get; set; }
        public string TrainingType { get; set; }
        public decimal? TrainingDuration { get; set; }
        public decimal IsCanseled { get; set; }
        public int? SportTeamId { get; set; }
        public int? CoachId { get; set; }

        public virtual Coach Coach { get; set; }
        public virtual SportTeam SportTeam { get; set; }
    }
}

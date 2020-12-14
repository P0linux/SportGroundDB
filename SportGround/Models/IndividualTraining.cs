using System;
using System.Collections.Generic;

#nullable disable

namespace SportGround.Models
{
    public partial class IndividualTraining: IBaseModel
    {
        public int Id { get; set; }
        public DateTime? TrainingDateTime { get; set; }
        public string TrainingType { get; set; }
        public decimal? TrainingDuration { get; set; }
        public decimal IsCanseled { get; set; }
        public int? VisitorId { get; set; }
        public int? CoachId { get; set; }

        public virtual Coach Coach { get; set; }
        public virtual Visitor Visitor { get; set; }
    }
}

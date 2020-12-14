using System;
using System.Collections.Generic;

#nullable disable

namespace SportGround.Models
{
    public partial class TeamPlayer: IBaseModel
    {
        public int Id { get; set; }
        public string PlayerRole { get; set; }
        public decimal TeamNumber { get; set; }
        public int? SportTeamId { get; set; }
        public int? VisitorId { get; set; }

        public virtual SportTeam SportTeam { get; set; }
        public virtual Visitor Visitor { get; set; }
    }
}

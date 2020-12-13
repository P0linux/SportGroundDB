using System;
using System.Collections.Generic;

#nullable disable

namespace SportGround.Models
{
    public partial class SportSection
    {
        public SportSection()
        {
            Coaches = new HashSet<Coach>();
            SectionVisitors = new HashSet<SectionVisitor>();
            SportTeams = new HashSet<SportTeam>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal VisitorsNumber { get; set; }
        public decimal CoachesNumber { get; set; }
        public decimal VisitorsMaxNumber { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int? SportTypeId { get; set; }

        public virtual SportType SportType { get; set; }
        public virtual ICollection<Coach> Coaches { get; set; }
        public virtual ICollection<SectionVisitor> SectionVisitors { get; set; }
        public virtual ICollection<SportTeam> SportTeams { get; set; }
    }
}

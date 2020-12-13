using System;
using System.Collections.Generic;

#nullable disable

namespace SportGround.Models
{
    public partial class SportType
    {
        public SportType()
        {
            Competitions = new HashSet<Competition>();
            EquipmentTypes = new HashSet<EquipmentType>();
            SportSections = new HashSet<SportSection>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? IsTeamplay { get; set; }

        public virtual ICollection<Competition> Competitions { get; set; }
        public virtual ICollection<EquipmentType> EquipmentTypes { get; set; }
        public virtual ICollection<SportSection> SportSections { get; set; }
    }
}

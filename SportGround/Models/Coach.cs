using System;
using System.Collections.Generic;

#nullable disable

namespace SportGround.Models
{
    public partial class Coach
    {
        public Coach()
        {
            IndividualTrainings = new HashSet<IndividualTraining>();
            TeamTrainings = new HashSet<TeamTraining>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public decimal Age { get; set; }
        public string Sex { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Salary { get; set; }
        public decimal Experience { get; set; }
        public int? SportSectionId { get; set; }

        public virtual SportSection SportSection { get; set; }
        public virtual ICollection<IndividualTraining> IndividualTrainings { get; set; }
        public virtual ICollection<TeamTraining> TeamTrainings { get; set; }
    }
}

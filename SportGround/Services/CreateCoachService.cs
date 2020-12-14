using SportGround.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportGround.Services
{
    class CreateCoachService
    {
        Sport_ground_DBContext context;
        public CreateCoachService(Sport_ground_DBContext context)
        {
            this.context = context;
        }

        public void CreateCoach(Coach coach, string sectionName)
        {
            var section = context.SportSections.Where(s => s.Name == sectionName).FirstOrDefault();
            coach.SportSectionId = section.Id;
            context.Coaches.Add(coach);
            context.SaveChanges();
        }
    }
}

using SportGround.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportGround.Services
{
    public class CreateTeamService
    {
        Sport_ground_DBContext context;
        public CreateTeamService(Sport_ground_DBContext context)
        {
            this.context = context;
        }

        public void CreateTeam(SportTeam team, string sectionName)
        {
            var section = context.SportSections.Where(s => s.Name == sectionName).FirstOrDefault();
            team.SportSectionId = section.Id;
            context.SportTeams.Add(team);
            context.SaveChanges();
        }
    }
}

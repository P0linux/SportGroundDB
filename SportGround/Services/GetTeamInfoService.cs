using Microsoft.EntityFrameworkCore;
using SportGround.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportGround.Services
{
    public class GetTeamInfoService
    {
        Sport_ground_DBContext context;
        public GetTeamInfoService(Sport_ground_DBContext context)
        {
            this.context = context;
        }

        public List<string> GetGeneralInfo(string name)
        {
            var teams = context.SportTeams
                               .Include(t => t.SportSection)
                               .Where(t => t.Name == name);
            var teamsInfo = new List<string>();
            foreach (SportTeam t in teams) teamsInfo.Add(String.Format("Name: {0}, Players number: {1}, Date of creation: {2}, Rewards number: {3}, Sport section: {4}",
                                     t.Name, t.PlayersNumber, t.DateOfCreation, t.RewardNumber, t.SportSection.Name));
            return teamsInfo;
        }

        public List<string> GetTeamPlayers(string name)
        {
            var team = context.SportTeams
                               .Include(t => t.TeamPlayers)
                               .ThenInclude(p => p.Visitor)
                               .Where(t => t.Name == name)
                               .FirstOrDefault();
            var teamsInfo = new List<string>();
            var players = team.TeamPlayers.Select(t => t.Visitor);
            foreach (Visitor v in players) teamsInfo.Add(String.Format("First name: {0}, Second name: {1}, Gender: {2}, Age: {3}",
                                                         v.FirstName, v.SecondName, v.Sex, v.Age));
            return teamsInfo;
        }

        public List<string> GetTeamCoaches(string name)
        {
            var team = context.SportTeams
                               .Include(t => t.TeamTrainings)
                               .ThenInclude(p => p.Coach)
                               .Where(t => t.Name == name)
                               .FirstOrDefault();
            var teamsInfo = new List<string>();
            var coaches = team.TeamTrainings.Select(t => t.Coach);
            foreach (Coach c in coaches) teamsInfo.Add(String.Format("First name: {0}, Second name: {1}, Gender: {2}, Age: {3}",
                                                         c.FirstName, c.SecondName, c.Sex, c.Age));
            return teamsInfo;
        }
    }
}

using SportGround.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SportGround.Services
{
    public class GetVisitorInfoService
    {
        Sport_ground_DBContext context;
        public GetVisitorInfoService(Sport_ground_DBContext context)
        {
            this.context = context;
        }

        public List<string> GetVisitorGeneralInfo(string firstName, string secondName)
        {
            var visitors = context.Visitors.Where(v => v.FirstName == firstName && v.SecondName == secondName);
            List<string> visitorsInfo = new List<string>();
            foreach (Visitor v in visitors)
            {
                visitorsInfo.Add(String.Format("First name: {0}, Second name: {1}, Phone number: {2}, Sex: {3}, Age: {4}", 
                                 v.FirstName, v.SecondName, v.PhoneNumber, v.Sex, v.Age));
            }
            return visitorsInfo;
        }
        public List<string> GetVisitorSections(string firstName, string secondName)
        {
            var sections = from section in context.SportSections.Include(s => s.SportType)
                           join section_visitor in context.SectionVisitors on section.Id equals section_visitor.SportSectionId
                           join visitor in context.Visitors on section_visitor.VisitorId equals visitor.Id
                           where visitor.FirstName == firstName && visitor.SecondName == secondName
                           select section;
            List<string> sectionsInfo = new List<string>();
            foreach (SportSection s in sections)
            {
                sectionsInfo.Add(String.Format("Name: {0}, Visitors number: {1}, Sport type: {2}",
                                 s.Name, s.VisitorsNumber, s.SportType.Name));
            }
            return sectionsInfo;
        }

        public List<string> GetVisitorTeams(string firstName, string secondName)
        {
            var teams = from team in context.SportTeams.Include(t => t.SportSection)
                        join team_player in context.TeamPlayers on team.Id equals team_player.SportTeamId
                        join visitor in context.Visitors on team_player.VisitorId equals visitor.Id
                        where visitor.FirstName == firstName && visitor.SecondName == secondName
                        select team;
            List<string> teamsInfo = new List<string>();
            foreach (SportTeam t in teams)
            {
                teamsInfo.Add(String.Format("Name: {0}, Reward number: {1}, Sport section: {2}",
                              t.Name, t.RewardNumber, t.SportSection.Name));
            }
            return teamsInfo;
        }

        public List<string> GetVisitorCoaches(string firstName, string secondName)
        {
            var visitor = context.Visitors.Where(v => v.FirstName == firstName && v.SecondName == secondName).FirstOrDefault();
            var coaches = visitor.IndividualTrainings.Select(t => t.Coach);
            List<string> coachesInfo = new List<string>();
            foreach (Coach c in coaches)
            {
                coachesInfo.Add(string.Format("First name: {0}, Second name: {1}, Age: {2}, Sex: {3}",
                                c.FirstName, c.SecondName, c.Age, c.Salary));
            }
            return coachesInfo;
        }
    }
}

using SportGround.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportGround.Services
{
    public class GetVisitorsService
    {
        Sport_ground_DBContext context;
        public GetVisitorsService(Sport_ground_DBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Visitor> GetAllVisitors()
        {
            return context.Visitors;
        }

        public IEnumerable<Visitor> GetVisitorsBySection(string sectionName)
        {
            var visitors = from visitor in context.Visitors
                           join section_visitor in context.SectionVisitors on visitor.Id equals section_visitor.VisitorId
                           join section in context.SportSections on section_visitor.SportSectionId equals section.Id
                           where section.Name == sectionName
                           select visitor;
            return visitors;
        }

        public IEnumerable<Visitor> GetVisitorsByTeam(string teamName)
        {
            var visitors = from visitor in context.Visitors
                           join team_player in context.TeamPlayers on visitor.Id equals team_player.VisitorId
                           join team in context.SportTeams on team_player.SportTeamId equals team.Id
                           where team.Name == teamName
                           select visitor;
            return visitors;
        }

        public IEnumerable<Visitor> GetVisitorsByCoach(string coachName)
        {
            var visitors = from visitor in context.Visitors
                           join training in context.IndividualTrainings on visitor.Id equals training.VisitorId
                           join coach in context.Coaches on training.CoachId equals coach.Id
                           where coach.SecondName == coachName
                           select visitor;
            return visitors;
        }
    }
}

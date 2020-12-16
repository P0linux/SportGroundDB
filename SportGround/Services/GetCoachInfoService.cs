using Microsoft.EntityFrameworkCore;
using SportGround.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportGround.Services
{
    public class GetCoachInfoService
    {
        Sport_ground_DBContext context;
        public GetCoachInfoService(Sport_ground_DBContext context)
        {
            this.context = context;
        }

        public List<string> GetCoachGeneralInfo(string firstName, string secondName)
        {
            var coaches = context.Coaches.Include(c => c.SportSection)
                                         .Where(c => c.FirstName == firstName && c.SecondName == secondName);
            
            List<string> coachesInfo = new List<string>();
            foreach (Coach c in coaches)
            {
                coachesInfo.Add(String.Format("First name: {0}, SecondName: {1}, Age: {2}, Sex: {3}, Section: {4}",
                                              c.FirstName, c.SecondName, c.Age, c.Sex, c.SportSection.Name));
            }
            return coachesInfo;
        }

        public List<string> GetCoachIndividualTrainings(string firstName, string secondName)
        {
            var coaches = context.Coaches.Include(c => c.IndividualTrainings)
                                         .ThenInclude(c => c.Visitor)
                                         .Where(c => c.FirstName == firstName && c.SecondName == secondName)
                                         .FirstOrDefault();
            var trainings = coaches.IndividualTrainings;
            List<string> trainingsInfo = new List<string>();
            foreach (IndividualTraining t in trainings)
            {
                trainingsInfo.Add(String.Format("Date and time: {0}, Type: {1}, Duration: {2}h, Visitor name: {3}",
                                  t.TrainingDateTime, t.TrainingType, t.TrainingDuration, t.Visitor.SecondName));
            }
            return trainingsInfo;
        }

        public List<string> GetCoachTeamTrainings(string firstName, string secondName)
        {
            var coaches = context.Coaches.Include(c => c.TeamTrainings)
                                         .ThenInclude(c => c.SportTeam)
                                         .Where(c => c.FirstName == firstName && c.SecondName == secondName)
                                         .FirstOrDefault();
            var trainings = coaches.TeamTrainings;
            List<string> trainingsInfo = new List<string>();
            if (trainings == null) return trainingsInfo;
            foreach (TeamTraining t in trainings)
            {
                trainingsInfo.Add(String.Format("Date and time: {0}, Type: {1}, Duration: {2}h, Team name: {3}",
                                  t.TrainingDateTime, t.TrainingType, t.TrainingDuration, t.SportTeam.Name));
            }
            return trainingsInfo;
        }
    }
}

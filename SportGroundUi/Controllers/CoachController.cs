using Microsoft.AspNetCore.Mvc;
using SportGround.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportGroundUI.Controllers
{
    public class CoachController : Controller
    {
        GetCoachInfoService service;
        public CoachController(GetCoachInfoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Coach()
        {
            return View("Coach");
        }

        [HttpGet]
        public ActionResult GetCoachInfo()
        {
            return View("GetCoachInfo", new List<string>());
        }

        [HttpPost]
        public ActionResult GetCoachInfo(string firstName, string secondName, string option)
        {
            var coachInfo = GetByOption(firstName, secondName, option);
            return View("GetCoachInfo", coachInfo);
        }

        private List<string> GetByOption(string firstName, string secondName, string option)
        {
            switch (option)
            {
                case "General":
                    return service.GetCoachGeneralInfo(firstName, secondName);
                case "Ind":
                    return service.GetCoachIndividualTrainings(firstName, secondName);
                case "Team":
                    return service.GetCoachTeamTrainings(firstName, secondName);
            }
            return null;
        }
    }
}

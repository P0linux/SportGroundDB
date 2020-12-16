using Microsoft.AspNetCore.Mvc;
using SportGround.Models;
using SportGround.Services;
using SportGroundUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportGroundUI.Controllers
{
    public class CreateTeamController : Controller
    {
        CreateTeamService service;
        public CreateTeamController(CreateTeamService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult CreateTeam()
        {
            return View("CreateTeam");
        }

        [HttpPost]
        public ActionResult CreateTeam(TeamParameters parameters)
        {
            var team = new SportTeam()
            {
                Name = parameters.Name,
                PlayersNumber = parameters.PlayersNumber,
                RewardNumber = parameters.RewardNumber,
                DateOfCreation = parameters.DateOfCreation,
            };
            service.CreateTeam(team, parameters.SectionName);
            return RedirectToAction("CreateTeam");
        }
    }
}

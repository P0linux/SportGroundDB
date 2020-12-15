using Microsoft.AspNetCore.Mvc;
using SportGround.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportGroundUI.Controllers
{
    public class TeamController : Controller
    {
        GetTeamInfoService service;
        public TeamController(GetTeamInfoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Team()
        {
            return View("Team");
        }

        [HttpGet]
        public ActionResult GetTeamInfo()
        {
            return View("GetTeamInfo", new List<string>());
        } 

        [HttpPost]
        public ActionResult GetTeamInfo(string name, string option)
        {
            var info = GetByOption(name, option);
            return View("GetTeamInfo", info);
        }

        private List<string> GetByOption(string name, string option)
        {
            switch (option)
            {
                case "General":
                    return service.GetGeneralInfo(name);
                case "Coach":
                    return service.GetTeamCoaches(name);
                case "Player":
                    return service.GetTeamPlayers(name);
            }
            return null;
        }
    }
}

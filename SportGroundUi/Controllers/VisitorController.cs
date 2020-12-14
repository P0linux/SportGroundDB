using Microsoft.AspNetCore.Mvc;
using SportGround.Models;
using SportGround.Repositories;
using SportGround.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportGroundUI.Controllers
{
    public class VisitorController : Controller
    {
        GetVisitorInfoService service;
        public VisitorController(GetVisitorInfoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Visitor()
        {
            return View("Visitor");
        }

        [HttpGet]
        public ActionResult GetVisitors()
        {
            return View("GetVisitors", new List<string>());
        }

        [HttpPost]
        public ActionResult GetVisitors(string firstName, string secondName, string option)
        {
            List<string> info = GetByOption(firstName, secondName, option);
            return View("GetVisitors", info);
        }

        private List<string> GetByOption(string firstName, string secondName, string option)
        {
            switch (option)
            {
                case "General":
                    return service.GetVisitorGeneralInfo(firstName, secondName);
                case "Section":
                    return service.GetVisitorSections(firstName, secondName);
                case "Team":
                    return service.GetVisitorTeams(firstName, secondName);
                case "Coach":
                    return service.GetVisitorCoaches(firstName, secondName);
            }
            return null;
        }
    }
}

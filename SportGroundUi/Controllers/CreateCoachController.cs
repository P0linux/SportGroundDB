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
    public class CreateCoachController : Controller
    {
        CreateCoachService service;
        public CreateCoachController(CreateCoachService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult CreateCoach()
        {
            return View("CreateCoach");
        }

        [HttpPost]
        public ActionResult CreateCoach(CoachParameters parameters)
        {
            var coach = new Coach()
            {
                FirstName = parameters.FirstName,
                SecondName = parameters.SecondName,
                Age = parameters.Age,
                Sex = parameters.Sex,
                PhoneNumber = parameters.PhoneNumber,
                Salary = parameters.Salary,
                Experience = parameters.Experience
            };
            service.CreateCoach(coach, parameters.SectionName);
            return RedirectToAction("CreateCoach");
        }
    }
}

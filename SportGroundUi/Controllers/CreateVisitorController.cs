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
    public class CreateVisitorController : Controller
    {
        CreateVisitorService service;
        public CreateVisitorController(CreateVisitorService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult CreateVisitor()
        {
            return View("CreateVisitor");
        }

        [HttpPost]
        public ActionResult CreateVisitor(VisitorParameters parameters)
        {
            var visitor = new Visitor()
            {
                FirstName = parameters.FirstName,
                SecondName = parameters.SecondName,
                PhoneNumber = parameters.PhoneNumber,
                Age = parameters.Age,
                Sex = parameters.Sex,
            };
            service.CreateVisitor(visitor);
            return RedirectToAction("CreateVisitor");
        }
    }
}

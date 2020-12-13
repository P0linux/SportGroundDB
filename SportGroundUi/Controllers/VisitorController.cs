using Microsoft.AspNetCore.Mvc;
using SportGround.Models;
using SportGround.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportGroundUI.Controllers
{
    public class VisitorController : Controller
    {
        IRepository<Visitor> visitorRepository;
        public VisitorController(IRepository<Visitor> repository)
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

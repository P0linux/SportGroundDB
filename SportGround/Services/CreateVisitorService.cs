using SportGround.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportGround.Services
{
    public class CreateVisitorService
    {
        Sport_ground_DBContext context;
        public CreateVisitorService(Sport_ground_DBContext context)
        {
            this.context = context;
        }
        public void CreateVisitor(Visitor visitor)
        {
            context.Visitors.Add(visitor);
            context.SaveChanges();
        }
    }
}

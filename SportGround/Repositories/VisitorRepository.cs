using Microsoft.EntityFrameworkCore;
using SportGround.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportGround.Repositories
{
    class VisitorRepository : IRepository<Visitor>
    {
        DbSet<Visitor> visitors;

        public VisitorRepository(Sport_ground_DBContext context)
        {
            visitors = context.Set<Visitor>();
        }

        public void DeleteById(int Id)
        {
            Visitor visitor = visitors.Find(Id);
            visitors.Remove(visitor);
        }

        public IEnumerable<Visitor> GetAll()
        {
            return visitors;
        }

        public Visitor GetById(int Id)
        {
            return visitors.Find(Id);
        }

        public void Insert(Visitor entity)
        {
            visitors.Add(entity);
        }

        public void Update(Visitor entity)
        {
            visitors.Update(entity);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SportGround.Repositories
{
    public interface IRepository<ClassType>
    {
        IEnumerable<ClassType> GetAll();
        void Insert(ClassType entity);
        void Update(ClassType entity);
        ClassType GetById(int Id);
        void DeleteById(int Id);
    }
}

using MyHomeTechnicalTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeTechnicalTest.Models
{
    public interface IUnitOfWork
    {
        IRepository<Property> Property { get; }
        IRepository<Photo> Photo { get; }
        void Commit();
    }
}

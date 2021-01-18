using MyHomeTechnicalTest.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeTechnicalTest.Models
{
    public class UnitOfWork : IUnitOfWork
    {

        private MyHomeContext _dbContext;
        private BaseRepository<Property> _property;
        private BaseRepository<Photo> _photos;

        public UnitOfWork()
        {
        }

        public UnitOfWork(MyHomeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<Property> Property
        {
            get
            {
                return _property ??
                    (_property = new BaseRepository<Property>(_dbContext));
            }
        }

        public IRepository<Photo> Photo
        {
            get
            {
                return _photos ??
                    (_photos = new BaseRepository<Photo>(_dbContext));
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }

}




using MyHomeTechnicalTest.Models;
using MyHomeTechnicalTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeTechnicalTest.Data.Repositories
{
    public interface IPhotoRepository
    {
        List<Photo> GetByPropertyId(int id);
        void Insert(List<string> urls, int propertId);
    }

    public class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(MyHomeContext context) : base(context)
        {

        }

        public List<Photo> GetByPropertyId(int id)
        {
            return context.Photos.Where(p => p.PropertyId == id).ToList();
        }

        public void Insert(List<string> urls, int propertId)
        {
            foreach (var url in urls) {
                context.Photos.Add(new Photo() {
                    Url = url,
                    PropertyId = propertId
                });
            }
        }
    }
}

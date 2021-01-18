using Microsoft.EntityFrameworkCore;
using MyHomeTechnicalTest.BizObjects;
using MyHomeTechnicalTest.Models;
using MyHomeTechnicalTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeTechnicalTest.Data.Repositories
{
    public interface IPropertyRepository : IRepository<Models.Property>
    {
        SearchResponse Search(SearchRequest request);
    }

    public class PropertyRepository : BaseRepository<Models.Property>, IPropertyRepository
    {
        public PropertyRepository(MyHomeContext context) : base(context)
        {
        }

        public SearchResponse Search(SearchRequest request)
        {
            //var response = context.Properties.Where(p => p.Price == null ? p.Price == request.Price : p.Price > 0
            //                                        && p.BedsString == null ? p.BedsString = request.BedsString : p.BedsString != null);
            return null;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyHomeTechnicalTest.BizObjects;
using MyHomeTechnicalTest.Models;
using MyHomeTechnicalTest.Repositories;
using MyHomeTechnicalTest.Services;

namespace MyHomeTechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly ILogger<PropertyController> _logger;
        //private UnitOfWork unitOfWork = new UnitOfWork();
        IPropertyService _propertyService;

        public PropertyController(ILogger<PropertyController> logger, IPropertyService propertyService)
        {
            _logger = logger;
            _propertyService = propertyService;
        }

        [HttpGet("/GetAll")]

        public IEnumerable<BizObjects.Property> GetAll()
        {
            return _propertyService.GetAll();
        }

        [HttpGet("/GetAllProperties")]

        public SearchResponse GetAllProperties()
        {
            return _propertyService.GetAllProperties();
        }

        [HttpGet("{id}")]
        public Models.Property Get(int id)
        {
            var temp = _propertyService.GetById(id);
            return temp;
        }

        [HttpPut]
        public void Put(BizObjects.Property property)
        {
            _propertyService.Insert(property);
            //unitOfWork.Property.Insert(CopyToEntity(property));
            //unitOfWork.Commit();
        }

        [HttpPost("/Add")]
        public void Post(BizObjects.Property property)
        {
            //_propertyService.Insert(property);
            //unitOfWork.Property.Insert(CopyToEntity(property));
            //unitOfWork.Commit();
        }

        [HttpDelete]
        public void Delete(BizObjects.Property property)
        {
            _propertyService.Delete(property);
        }

        private Models.Property CopyToEntity(BizObjects.Property property)
        {
            return new Models.Property()
            {
                DisplayAddress = property.DisplayAddress,
                Bath = property.Bath,
                BedsString = property.BedsString,
                BerRating = property.BerRating,
                GroupLogoUrl = property.GroupLogoUrl,
                Price = property.Price,
                PropertyType = property.PropertyType,
                SizeStringMeters = property.SizeStringMeters,
                Photos = GetPhotos(property.Photos, property.Id)
            };
        }

        private List<Photo> GetPhotos(ICollection<string> photos, int id)
        {
            List<Photo> images = new List<Photo>();
            foreach (var image in photos)
            {
                images.Add(new Photo()
                {
                    Url = image,
                    PropertyId = id
                });
            }
            return images;
        }
    }
}

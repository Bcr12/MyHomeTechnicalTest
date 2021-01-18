using MyHomeTechnicalTest.BizObjects;
using MyHomeTechnicalTest.Data.Repositories;
using MyHomeTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeTechnicalTest.Services
{
    public interface IPropertyService
    {
        public List<BizObjects.Property> GetAll();
        public SearchResponse GetAllProperties();
        public Models.Property GetById(int id);
        public void Insert(BizObjects.Property property);
        public Models.Property Update(Models.Property property);
        public void Delete(BizObjects.Property property);
    }


    public class PropertyService : IPropertyService
    {
        IPropertyRepository _propertyRepositoy;
        IPhotoRepository _photoRepositoy;
        //nitOfWork _unitOfWork;


        public PropertyService(
            //UnitOfWork unitOfWork, 
            IPropertyRepository properyRepositoy, 
            IPhotoRepository photoRepositoy) {
            _propertyRepositoy = properyRepositoy;
            _photoRepositoy = photoRepositoy;
            //_unitOfWork = unitOfWork;
        }

        public List<BizObjects.Property> GetAll()
        {
            var properties =  (List<Models.Property>)_propertyRepositoy.Get();
            List<BizObjects.Property> result = new List<BizObjects.Property>();

            foreach (var prop in properties) {
                result.Add(CopyToBizObject(prop));
            }
            return result;
        }

        public SearchResponse GetAllProperties()
        {
            var properties = (List<Models.Property>)_propertyRepositoy.Get();
            List<BizObjects.Property> result = new List<BizObjects.Property>();

            foreach (var prop in properties)
            {
                result.Add(CopyToBizObject(prop));
            }

            SearchResponse searchResponse = new SearchResponse()
            {
                SearchResults = result
            };

            return searchResponse;
        }

        public Models.Property GetById(int id)
        {
            return _propertyRepositoy.GetByID(id);
        }

        public void Insert(BizObjects.Property property)
        {
            _propertyRepositoy.Insert(CopyToEntity(property));
            //_unitOfWork.Commit();
        }
        public Models.Property Update(Models.Property property)
        {
            _propertyRepositoy.Update(property);
            return _propertyRepositoy.GetByID(property.Id);
        }

        public void Delete(BizObjects.Property property)
        {
            _propertyRepositoy.Delete(CopyToEntity(property));
        }

        private List<string> GetPropertyPhotos(int id)
        {
            var photos = _photoRepositoy.GetByPropertyId(id);
            List<string> urls = new List<string>();
            foreach (var i in photos)
            {
                urls.Add(i.Url);
            }
            return urls;
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

        private BizObjects.Property CopyToBizObject(Models.Property prop)
        { 
            return new BizObjects.Property()
            {
                Id = prop.Id,
                DisplayAddress = prop.DisplayAddress,
                Bath = prop.Bath,
                BedsString = prop.BedsString,
                BerRating = prop.BerRating,
                GroupLogoUrl = prop.GroupLogoUrl,
                Price = prop.Price,
                PropertyType = prop.PropertyType,
                SizeStringMeters = prop.SizeStringMeters,
                Photos = GetPropertyPhotos(prop.Id)
            };
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

    }
}

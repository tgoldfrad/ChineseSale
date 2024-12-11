using ChineseSale.Core.Entities;
using ChineseSale.Core.IRepositories;
using ChineseSale.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseSale.Service
{
    public class CityService:ICityService
    {
        readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public List<City> GetAll()
        {
            var dataCity = _cityRepository.GetAll();
            if (dataCity == null)
                return null;
            return dataCity.ToList();
        }
        public City GetById(int id)
        {
            return _cityRepository.GetById(id);
        }
        public City Add(City city)
        {
            if (city == null)
                return null;
            return _cityRepository.Add(city);
        }
        public bool Update(int id, City city)
        {
            if (city == null)
                return false;
            return _cityRepository.Update(id, city);
        }
        public bool Delete(int id)
        {
            return _cityRepository.Delete(id);
        }
    }
}

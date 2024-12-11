using ChineseSale.Core.Entities;
using ChineseSale.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseSale.Data.Repositories
{
    public class CityRepository:ICityRepository
    {
        readonly DataContext _dataContext;
        public CityRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<City> GetAll()
        {
            return _dataContext.CitiesList.ToList();
        }
        public City GetById(int id)
        {
            return _dataContext.CitiesList.Where(c => c.Id == id).FirstOrDefault();
        }
        public City Add(City city)
        {
            try
            {
                _dataContext.CitiesList.Add(city);
                _dataContext.SaveChanges();
                return city;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Update(int id, City city)
        {
            var cityToUpdate = _dataContext.CitiesList.Find(id);//find by primary key
            if (cityToUpdate == null)
                return false;
            cityToUpdate.CityName = !String.IsNullOrEmpty(city.CityName) ? city.CityName : cityToUpdate.CityName;
            _dataContext.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var cityToDelete = GetById(id);//find by id
            if(cityToDelete == null)
                return false;
            _dataContext.CitiesList.Remove(cityToDelete);
            _dataContext.SaveChanges();
            return true;
            //List<City> dataCity = _dataContext.CitiesList.ToList();
            //City city = GetById(id);
            //if (city == null)
            //    return false;
            //dataCity.Remove(city);
            ////return _dataContext.SaveChange(dataCity);
            //return true;
        }
    }
}

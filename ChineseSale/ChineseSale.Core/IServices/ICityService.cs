using ChineseSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseSale.Core.IServices
{
    public interface ICityService
    {
        List<City> GetAll();
        City GetById(int id);
        City Add(City city);
        bool Update(int id, City city);
        bool Delete(int id);
    }
}

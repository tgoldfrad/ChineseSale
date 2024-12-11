using ChineseSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseSale.Core.IRepositories
{
    public interface IDonorRepository
    {
        List<Donor> GetAll();
        Donor GetById(string id);
        Donor Add(Donor donor);
        bool Update(string id, Donor donor);
        bool Delete(string id);
    }
}

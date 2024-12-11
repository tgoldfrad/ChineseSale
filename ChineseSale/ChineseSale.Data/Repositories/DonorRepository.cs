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
    public class DonorRepository:IDonorRepository
    {
        readonly DataContext _dataContext;
        public DonorRepository(DataContext dataContext)
        {
            _dataContext=dataContext;
        }
       public List<Donor> GetAll()
        {
            return _dataContext.DonorsList.ToList();
        }
       public Donor GetById(string id)
        {
            return _dataContext.DonorsList.Where(d => d.Identity.Equals(id)).FirstOrDefault();
        }
       public Donor Add(Donor donor)
        {
            try
            {
                _dataContext.DonorsList.Add(donor);
                _dataContext.SaveChanges();
                return donor;
            }
            catch (Exception ex)
            {
                return null;
            }
            //List<Donor> dataDonor = _dataContext.DonorsList.ToList();
            //dataDonor.Add(donor);
            //return _dataContext.SaveChange(dataDonor);
        }
       public bool Update(string id, Donor donor)
        {
            var donorToUpdate = _dataContext.DonorsList.Find(id);//find by primary key
            if (donorToUpdate == null)
                return false;
            donorToUpdate.DonorFirstName = !String.IsNullOrEmpty(donor.DonorFirstName) ? donor.DonorFirstName : donorToUpdate.DonorFirstName;
            donorToUpdate.DonorLastName = !String.IsNullOrEmpty(donor.DonorLastName) ? donor.DonorLastName : donorToUpdate.DonorLastName;
            donorToUpdate.DonorAdress = !String.IsNullOrEmpty(donor.DonorAdress) ? donor.DonorAdress : donorToUpdate.DonorAdress;
            donorToUpdate.DonorTelephone = !String.IsNullOrEmpty(donor.DonorTelephone) ? donor.DonorTelephone : donorToUpdate.DonorTelephone;
            donorToUpdate.DonorPhone = !String.IsNullOrEmpty(donor.DonorPhone) ? donor.DonorPhone : donorToUpdate.DonorPhone;
            _dataContext.SaveChanges();
            return true;
            
            //List<Donor> dataDonor = _dataContext.DonorsList.ToList();
            //int index = dataDonor.FindIndex(d => d.Identity.Equals(id));
            //if (index == -1)
            //    return false;

            //dataDonor[index].DonorFirstName = !String.IsNullOrEmpty(donor.DonorFirstName) ? donor.DonorFirstName : dataDonor[index].DonorFirstName;
            //dataDonor[index].DonorLastName = !String.IsNullOrEmpty(donor.DonorLastName) ? donor.DonorLastName : dataDonor[index].DonorLastName;
            //dataDonor[index].DonorAdress = !String.IsNullOrEmpty(donor.DonorAdress) ? donor.DonorAdress : dataDonor[index].DonorAdress;
            //dataDonor[index].DonorTelephone = !String.IsNullOrEmpty(donor.DonorTelephone) ? donor.DonorTelephone : dataDonor[index].DonorTelephone;
            //dataDonor[index].DonorPhone = !String.IsNullOrEmpty(donor.DonorPhone) ? donor.DonorPhone : dataDonor[index].DonorPhone;

            //_dataContext.SaveChanges();
            //return true;

        }
        public bool Delete(string id)
        {
            var donorToDelete = GetById(id);//find by id
            if (donorToDelete == null)
                return false;
            _dataContext.DonorsList.Remove(donorToDelete);
            _dataContext.SaveChanges();
            return true;
            //List<Donor> dataDonor = _dataContext.DonorsList.ToList(;
            //Donor donor = GetById(id);
            //if(donor == null)
            //    return false;
            //dataDonor.Remove(donor);
            //return _dataContext.SaveChange(dataDonor);

        }
    }
}

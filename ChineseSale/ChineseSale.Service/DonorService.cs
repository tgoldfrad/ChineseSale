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

    [Flags]
    public enum ErrorType { LengthNotValid = 1, Notdigits = 2, NotStart_05 = 4, OK = 8 }
    public class DonorService:IDonorService
    {
        readonly IDonorRepository _donorRepository;

        public DonorService(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }
        //public DonorService() { }
        public List<Donor> GetAll()
        {
            //return DataContextManager.DataContext.DonorsList;
            var dataDonor = _donorRepository.GetAll();
            if (dataDonor == null)
                return null;
            return dataDonor.ToList();
        }
        public Donor GetById(string id)
        {
            
            return _donorRepository.GetById(id);
        }
        public Donor Add(Donor donor)
        {
            if (donor == null)
                return null;
            ErrorType error;
            bool isValid = IsValidPhone(donor.DonorPhone, out error);
            if (isValid)
            {
                return _donorRepository.Add(donor);
            }
            return null;
        }
        public bool Update(string id, Donor donor)
        {
            if (donor == null)
                 return false;
                ErrorType error;
            bool isValid = IsValidPhone(donor.DonorPhone, out error);
            if (!isValid && !String.IsNullOrEmpty(donor.DonorPhone))
                return false;
           return _donorRepository.Update(id, donor);
            //var dataDonor = _orderRepository.GetAll();
            ////if (dataDonor == null)
            ////    return false;
            //int index = dataDonor.FindIndex(d => d.Identity == id);
            //if (index != -1)
            //{
            //    dataDonor[index] = donor;
            //    return _orderRepository.Update(id, dataDonor);
            //}
            //return false;
        }
        public bool Delete(string id)
        {
            //Donor donor = GetById(id);
            //if (donor != null)
            //{
                //DataContextManager.DataContext.DonorsList.Remove(donor);
                //var dataDonor = _orderRepository.LoadData();

                //dataDonor.Remove(donor);
                //return _orderRepository.SaveData(dataDonor);
                return _donorRepository.Delete(id);
            //}
            //return false;
        }
        public bool IsValidPhone(string phone, out ErrorType errorType)
        {
            errorType = 0;
            int phoneNumber;
            bool isNumber = int.TryParse(phone, out phoneNumber);
            if (!isNumber)
                errorType = ErrorType.Notdigits;
            else
            {
                if (phone.Length != 10)
                    errorType |= ErrorType.LengthNotValid;
                if (phone[0] != '0' || phone[1] != '5')
                    errorType |= ErrorType.NotStart_05;
            }

            if (errorType == 0)
            {
                errorType = ErrorType.OK;
                return true;
            }
            return false;
        }
    }
}

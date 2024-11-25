using ChineseSale;
using ChineseSale.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    internal class FakeContext:IDataContext
    {
        public List<Donors> LoadData()

        {
            List<Donors> data = new List<Donors>();
            data.Add(new Donors() { DonorId = 1, DonorFirstName = "Tamar", DonorLastName = "Levi", DonorAdress = "Bloi", DonorCity = 3, DonorTelephone = "03-5703050", DonorPhone = "0504177668" });
            data.Add(new Donors() { DonorId = 2, DonorFirstName = "Miri", DonorLastName = "Choen", DonorAdress = "Daniel", DonorCity = 3, DonorTelephone = "03-5703990", DonorPhone = "0504100668" });

            return data;
        }

        public bool SaveData(List<Donors> data)
        {
            return true;
        }
    }
}

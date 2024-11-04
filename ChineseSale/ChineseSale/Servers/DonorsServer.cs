using ChineseSale.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChineseSale.Servers
{
    public class DonorsServer
    {
        public List<Donors> donors = new List<Donors>()
        {
        new Donors() {DonorId=1,DonorFirstName="Tamar",DonorLastName="Levi",DonorAdress="Bloi",DonorCity=3,DonorTelephone="03-5703050",DonorCellular="0504177668"},
        new Donors() {DonorId=1,DonorFirstName="Miri",DonorLastName="Choen",DonorAdress="Daniel",DonorCity=3,DonorTelephone="03-5703990",DonorCellular="0504100668"}
        };

        public List<Donors> GetDonors()
        {
            return donors;
        }
        public Donors GetDonorsById(int id)
        {
            return donors.Find(x => x.DonorId == id);
        }
        public bool PostDonors(Donors d)
        {
            donors.Add(d);
            return true;
        }
        public bool PutDonors(int id,Donors d)
        {
            int index = donors.FindIndex(x=> x.DonorId == id);
            if(index != -1)
            {
                donors[index] = d;
                return true;
            }
            return false;
        }
        public bool DeleteDonors(int id)
        {
            Donors donor=donors.Find(x=>x.DonorId == id);
            if(donor != null)
            {
                donors.Remove(donor);
                return true;
            }
            return false;
        }
    }
}

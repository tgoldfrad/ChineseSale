using ChineseSale.Entities;
using Microsoft.AspNetCore.Mvc;


namespace ChineseSale.Servers
{
    [Flags]
    public enum ErrorType { LengthNotValid = 1,Notdigits = 2,NotStart_05 = 4,OK = 8}
    public class DonorsServer
    {
        //public List<Donors> donors = new List<Donors>()
        //{
        //new Donors() {DonorId=1,DonorFirstName="Tamar",DonorLastName="Levi",DonorAdress="Bloi",DonorCity=3,DonorTelephone="03-5703050",DonorPhone="0504177668"},
        //new Donors() {DonorId=1,DonorFirstName="Miri",DonorLastName="Choen",DonorAdress="Daniel",DonorCity=3,DonorTelephone="03-5703990",DonorPhone="0504100668"}
        //};
        readonly IDataContext _dataContext;

        public DonorsServer(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public DonorsServer() { }
        public List<Donors> GetDonors()
        {
            //return DataContextManager.DataContext.DonorsList;
            var dataDonor = _dataContext.LoadData();
            if (dataDonor == null)
                return null;
            return dataDonor.ToList();
        }
        public Donors GetDonorsById(int id)
        {
            //return DataContextManager.DataContext.DonorsList.Find(x => x.DonorId == id);
            var dataDonor = _dataContext.LoadData();
            if (dataDonor == null)
                return null;
            return dataDonor.Where(d=>d.DonorId==id).FirstOrDefault();
        }
        public bool AddDonors(Donors d)
        {
            ErrorType error;
            bool isValid = IsValidPhone(d.DonorPhone,out error);
            if(isValid)
            {
                //DataContextManager.DataContext.DonorsList.Add(d);
                //return true;
                var dataDonor = _dataContext.LoadData();
                if (dataDonor == null)
                    return false;
                dataDonor.Add(d);
                return _dataContext.SaveData(dataDonor);
            }
            return false;
        }
        public bool UpdateDonors(int id,Donors d)
        {
            ErrorType error;
            bool isValid = IsValidPhone(d.DonorPhone, out error);
            if (!isValid)
                return false;
            //int index = DataContextManager.DataContext.DonorsList.FindIndex(x=> x.DonorId == id);
            //if(index != -1)
            //{
            //    DataContextManager.DataContext.DonorsList[index] = d;
            //    return true;
            //}
            //return false;
            var dataDonor = _dataContext.LoadData();
            if (dataDonor == null)
                return false;
            int index = dataDonor.FindIndex(d => d.DonorId == id);
            if(index!=-1)
            {
                dataDonor[index] = d;
                return _dataContext.SaveData(dataDonor);
            }
            return false;
        }
        public bool DeleteDonors(int id)
        {
            Donors donor=GetDonorsById(id);
            if(donor != null)
            {
                //DataContextManager.DataContext.DonorsList.Remove(donor);
                var dataDonor = _dataContext.LoadData();
                if (dataDonor == null)
                    return false;
                dataDonor.Remove(donor);
                return _dataContext.SaveData(dataDonor);
            }
            return false;
        }
        public bool IsValidPhone(string phone,out ErrorType errorType)
        {
            errorType = 0;  
            int phoneNumber;
            bool isNumber = int.TryParse(phone, out phoneNumber);
            if(!isNumber)
                errorType=ErrorType.Notdigits;
            else
            {
                if (phone.Length != 10)
                    errorType |= ErrorType.LengthNotValid;
                if (phone[0] != '0' || phone[1] != '5')
                    errorType |= ErrorType.NotStart_05;
            }
            
            if(errorType == 0)
            {
                errorType = ErrorType.OK;
                return true;
            }
            return false;
        }
    }
}

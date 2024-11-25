using ChineseSale.Entities;

namespace ChineseSale
{
    public interface IDataContext
    {
        public List<Donors> LoadData();
        public bool SaveData(List<Donors> data);
    }
}

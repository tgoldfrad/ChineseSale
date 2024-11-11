using ChineseSale.Entities;

namespace ChineseSale.Servers
{
    public class CitiesServer
    {
        //public List<Cities> cities=new List<Cities>()
        //{
        //    new Cities(){CityId=1,CityName="Yerushalaim"},
        //    new Cities(){CityId=2,CityName="Bnei Brak"},
        //    new Cities(){CityId=3,CityName="Beit Shemesh"}
        //};
        public List<Cities> GetCities()
        {
            return DataContextManager.DataContext.CitiesList;
        }
        public Cities GetCitiesById(int id)
        {
            return DataContextManager.DataContext.CitiesList.Find(x => x.CityId == id);
        }
        public bool AddCities(Cities city)
        {
            DataContextManager.DataContext.CitiesList.Add(city);
            return true;
        }
        public bool UpdateCities(int id,Cities city)
        {
            int index = DataContextManager.DataContext.CitiesList.FindIndex(x => x.CityId == id);
            if (index != -1)
            {
                DataContextManager.DataContext.CitiesList[index] = city;
                return true;
            }
            return false;
        }
        public bool DeleteCities(int id)
        {
            Cities city = GetCitiesById(id);
            if(city != null)
            {
                DataContextManager.DataContext.CitiesList.Remove(city);
                return true;
            }
            return false;
        }
    }
}

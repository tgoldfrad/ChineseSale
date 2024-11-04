using ChineseSale.Entities;

namespace ChineseSale.Servers
{
    public class CitiesServer
    {
        public List<Cities> cities=new List<Cities>()
        {
            new Cities(){CityId=1,CityName="Yerushalaim"},
            new Cities(){CityId=2,CityName="Bnei Brak"},
            new Cities(){CityId=3,CityName="Beit Shemesh"}
        };
        public List<Cities> GetCities()
        {
            return cities;
        }
        public Cities GetCitiesById(int id)
        {
            return cities.Find(x => x.CityId == id);
        }
        public bool PostCities(Cities city)
        {
            cities.Add(city);
            return true;
        }
        public bool PutCities(int id,Cities city)
        {
            int index = cities.FindIndex(x => x.CityId == id);
            if (index != -1)
            {
                cities[index] = city;
                return true;
            }
            return false;
        }
        public bool DeleteCities(int id)
        {
            Cities city = cities.Find(x => x.CityId == id);
            if(city != null)
            {
                cities.Remove(city);
                return true;
            }
            return false;
        }
    }
}

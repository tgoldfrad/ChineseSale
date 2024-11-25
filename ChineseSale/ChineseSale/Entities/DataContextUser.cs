using System.Text.Json;

namespace ChineseSale.Entities
{
    public class DataContextUser:IDataContext
    {
        public List<Donors> LoadData()
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");
                string jsonString = File.ReadAllText(path);
                var AllDonors = JsonSerializer.Deserialize<List<Donors>>(jsonString);

                if (AllDonors == null) { return null; }

                return AllDonors;
            }
            catch
            {
                return null;
            }
        }

        public bool SaveData(List<Donors> data)
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");

                string jsonString = JsonSerializer.Serialize<List<Donors>>(data);

                File.WriteAllText(path, jsonString);
                return true;
            }
            catch 
            {
                return false;
            }
        }


    }
}

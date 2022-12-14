using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Heaton_Final6
{
    public class DataManager
    {
        private DataManager() { }

        private static DataManager instance = new DataManager();

        public static DataManager GetInstance()
        {
            return instance;
        }

        public PlayerSettings LoadData(string path = "c:/temp/player.json")
        {
            StreamReader reader = new StreamReader(path);
            string data = reader.ReadToEnd();
            reader.Close();
            return JsonConvert.DeserializeObject<PlayerSettings>(data);
        }

        public void SaveData(PlayerSettings obj, string path = "c:/temp/player.json")
        {
            string data = JsonConvert.SerializeObject(obj);
            StreamWriter writer = new StreamWriter(path);
            writer.Write(data);
            writer.Close();
        }

    }

    public class PlayerSettings
    {
        public string player_name;
        public int level;
        public int hp;
        public string[] inventory;
        public string liscense_key;

        public PlayerSettings()
        {
            this.player_name = "dschuh";
            this.level = 4;
            this.hp = 99;
            this.inventory = new string[]
            {
                "spear",
                "water bottle",
                "hammer",
                "sonic screwdriver",
                "cannonball",
                "wood",
                "Scooby snack",
                "Hydra",
                "poisonous potato",
                "dead bush",
                "repair powder"
            };
            this.liscense_key = "DFGU99-1454";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // create data
            PlayerSettings player = new PlayerSettings();
            DataManager myManager = DataManager.GetInstance();
            myManager.SaveData(player);

            PlayerSettings loadedSettings = myManager.LoadData();
            Console.WriteLine(loadedSettings.player_name); // should say "dschuh" if saved and loaded correctly

        }
    }
}

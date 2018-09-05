using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Newtonsoft.Json;

namespace Settings
{
    internal class JsonReader
    {
        internal const string Site = "SITE";
        internal const string Menu = "MENU";


        private static Dictionary<string, string> dicDataFilePath = new Dictionary<string, string>()
        {
            { JsonReader.Site,"F:\\PersonalProjects\\ASPNETMVCPractice\\ASPNETMVCPractice\\MVC3\\APP_Data\\Site.json" },
            { JsonReader.Menu,"F:\\PersonalProjects\\ASPNETMVCPractice\\ASPNETMVCPractice\\MVC3\\APP_Data\\Menu.json" }
        };


        internal static T ReadFromFile<T>(string SettingFileName)
        {
            //<<<<< 檢查字典是否存在 >>>>>
            if (!dicDataFilePath.ContainsKey(SettingFileName))
                throw new Exception(SettingFileName + "doesn't exist.");
            //<<<<< 檢查字典是否存在 >>>>>



            string FilePath = dicDataFilePath[SettingFileName];
            return JsonConvert.DeserializeObject<T>(FilePath);
        }
    }
}

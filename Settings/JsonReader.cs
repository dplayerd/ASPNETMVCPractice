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


        private static Dictionary<string, string> dicDataFilePath = null;

        private static void Init()
        {
            if (dicDataFilePath != null)
                return;


            dicDataFilePath = new Dictionary<string, string>()
            {
                { JsonReader.Site,System.Web.HttpContext.Current.Server.MapPath("~/APP_Data/Site.json") },
                { JsonReader.Menu,System.Web.HttpContext.Current.Server.MapPath("~/APP_Data/Menu.json") }
            };
        }



        internal static T ReadFromFile<T>(string SettingFileName)
        {
            Init();


            //<<<<< 檢查字典是否存在 >>>>>
            if (!dicDataFilePath.ContainsKey(SettingFileName))
                throw new Exception(SettingFileName + "doesn't exist.");
            //<<<<< 檢查字典是否存在 >>>>>



            string FilePath = dicDataFilePath[SettingFileName];
            string FileContent = File.ReadAllText(FilePath);

            return JsonConvert.DeserializeObject<T>(FileContent);
        }
    }
}

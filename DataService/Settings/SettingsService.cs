using System.IO;
using D.Common;

namespace AntViewer.DataService.Settings
{
    public static class SettingsService
    {
        public static API.Settings.Settings GetSettings()
        {
            var settings = new API.Settings.Settings();
            using (var sr = new StreamReader("settings.config"))
            {
                var xml = sr.ReadToEnd();
                if (!string.IsNullOrEmpty(xml))
                    settings = Utilities.Deserialize<API.Settings.Settings>(xml);
            }

            return settings;
        }

        public static void SaveSettings(API.Settings.Settings s)
        {
            using (var sr = new StreamWriter("settings.config"))
            {
                sr.Write(Utilities.Serialize(s));
            }
        }
    }
}

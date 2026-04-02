using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AvaloniaApplication2.ViewModels
{
    internal class SettingsViewModel : ViewModelBase
    {
        private string _userName = "";
        private bool _isDarkTheme = false;

        public string UserName 
        {
            get { return _userName; }
            set =>this.RaiseAndSetIfChanged(ref _userName, value);
        }
        public bool IsDarkTheme 
        {
            get { return _isDarkTheme; }
            set =>this.RaiseAndSetIfChanged(ref _isDarkTheme, value);
        }

        private static string SettingPath =>
            Path.Combine(
                System.Environment.GetFolderPath
                (System.Environment.SpecialFolder.ApplicationData),
                "AvaloniaApplication2",
                "settings.json"
                );
        public void Save() 
        {
            var dir = Path.GetDirectoryName( SettingPath );
            Directory.CreateDirectory( dir );

            var data = new { UserName, IsDarkTheme };
            File.WriteAllText(SettingPath, JsonSerializer.Serialize(data));
        }
        public void Load() 
        {
            if (!File.Exists(SettingPath)) return;

            var json = File.ReadAllText(SettingPath);
            var data = JsonSerializer.Deserialize<SettingData>(json);
            if (data == null) return;

            UserName = data.UserName ?? "";
            IsDarkTheme = data.IsDarkTheme;
        }
        private record SettingData(string? UserName, bool IsDarkTheme);
        public SettingsViewModel()
        {
            Load();
        }
    }
}

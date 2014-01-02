using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegeDoos.LDM
{
    public delegate void SettingsChangedEventHandler();

    public class GlobalSettings
    {
        public string SourcePath { get; set; }
        public string DestPath {  get;  set; }
        public string LastStaticDate {  get;  set; }
        private const string SettingsFolderRelative = "LDMSettings";
        public string SettingsFolder
        {
            get
            {
                return Path.Combine(DestPath, SettingsFolderRelative);
            }
        }
        private static GlobalSettings m_globalSettings =  null;

        public GlobalSettings()
        {
            ReloadSettings();
        }

        public static GlobalSettings theSettings
        {
            get 
            {
                if (m_globalSettings == null)
                    m_globalSettings = new GlobalSettings();
                return m_globalSettings;
            }
        }

        public void ReloadSettings()
        {
#if DEBUG
            SourcePath = @"d:\a";
            DestPath = @"d:\b";
#else
            SourcePath = Properties.Settings.Default.SourcePath;
            DestPath = Properties.Settings.Default.DestinationPath;
#endif
            LastStaticDate = Properties.Settings.Default.LastStaticDate;

            if (!Directory.Exists(SettingsFolder))
            {
                DirectoryInfo di = Directory.CreateDirectory(SettingsFolder);
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.Save();
            this.ReloadSettings();
        }
    }
}

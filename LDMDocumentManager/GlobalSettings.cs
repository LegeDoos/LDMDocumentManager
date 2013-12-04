using System;
using System.Collections.Generic;
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
            SourcePath = Properties.Settings.Default.SourcePath;
            DestPath = Properties.Settings.Default.DestinationPath;
            LastStaticDate = Properties.Settings.Default.LastStaticDate;
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.Save();
            this.ReloadSettings();
        }
    }
}

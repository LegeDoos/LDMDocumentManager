using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public string DestPath { get; set; }
        public string LastStaticDate { get; set; }
        public bool DisableImageCache { get; set; }
        private const string SettingsFolderRelative = "LDMSettings";
        public string SettingsFolder
        {
            get
            {
                return Path.Combine(DestPath, SettingsFolderRelative);
            }
        }

        public readonly Dictionary<string, string> SupportedFileTypes = new Dictionary<string, string>
        {
            { "pdf", "PDF" },
            { "jpg", "Images jpg" },
            { "jpeg", "Images jpeg" },
            { "gif", "Images gif" },
            { "png", "Images png" }
        };
        public readonly List<string> SupportedImageFileTypes = new List<string>
        {
            {"jpg"}, {"jpeg"}, {"gif"}, {"png"}
        };
        public string OpenDialogFilterSupportedFiles
        {
            get
            {
                string retVal = string.Empty;
                string allSupported = string.Empty;
                foreach (KeyValuePair<string, string> fileType in GlobalSettings.theSettings.SupportedFileTypes.OrderBy(f => f.Key))
                {
                    allSupported = string.Format("{0}*.{1};", allSupported, fileType.Key);
                    retVal = string.Format("{0}{1}|*.{2}|", retVal, fileType.Value, fileType.Key);
                }
                retVal = string.Format("{0}All supported files|{1}", retVal, allSupported.Substring(0, allSupported.Length-1));
                return retVal;
            }
        }

        private static GlobalSettings m_globalSettings = null;
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
            DisableImageCache = Properties.Settings.Default.DisableImageCache;

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

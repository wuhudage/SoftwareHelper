﻿using System;
using System.Configuration;

namespace SoftwareHelper.Helpers
{
    /// <summary>
    /// Config帮助类
    /// </summary>
    public partial class ConfigHelper
    {
        public static bool EdgeHide { get; set; }
        public static double Opacity { get; set; }
        public static bool CustomJson { get;private set; }
        public static bool Startup { get; set; }
        public static void GetConfigHelper()
        {
            double opacity = 80;
            if (!double.TryParse(string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Opacity"]) ? "80" : ConfigurationManager.AppSettings["Opacity"], out opacity))
                Opacity = 80;
            else
                Opacity = Convert.ToDouble(string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Opacity"]) ? "80" : ConfigurationManager.AppSettings["Opacity"]);
            bool edgeHide;
            if (!bool.TryParse(string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EdgeHide"]) ? "false" : ConfigurationManager.AppSettings["EdgeHide"], out edgeHide))
                EdgeHide = false;
            else
                EdgeHide = Convert.ToBoolean(string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EdgeHide"]) ? "false" : ConfigurationManager.AppSettings["EdgeHide"]);
            bool customJson;
            if (!bool.TryParse(string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["CustomJson"]) ? "false" : ConfigurationManager.AppSettings["CustomJson"], out customJson))
                CustomJson = false;
            else
                CustomJson = Convert.ToBoolean(string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["CustomJson"]) ? "false" : ConfigurationManager.AppSettings["CustomJson"]);

            bool startup;
            if (!bool.TryParse(string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Startup"]) ? "false" : ConfigurationManager.AppSettings["Startup"], out startup))
                startup = false;
            else
                startup = Convert.ToBoolean(string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Startup"]) ? "false" : ConfigurationManager.AppSettings["Startup"]);
        }
        double GetOpacity()
        {
            double opacity = 80;
            if (!double.TryParse(string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Opacity"]) ? "80" : ConfigurationManager.AppSettings["Opacity"], out opacity))
                opacity = 80;
            else
                opacity = Convert.ToDouble(string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Opacity"]) ? "80" : ConfigurationManager.AppSettings["Opacity"]);
            return opacity;
        }
        public static void SaveOpacity(double opacity)
        {
            SaveConfig("Opacity", opacity.ToString());
        }

        bool GetEdgeHide()
        {
            bool edgeHide;
            if (!bool.TryParse(string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EdgeHide"]) ? "false" : ConfigurationManager.AppSettings["EdgeHide"], out edgeHide))
                edgeHide = false;
            else
                edgeHide = Convert.ToBoolean(string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EdgeHide"]) ? "false" : ConfigurationManager.AppSettings["EdgeHide"]);
            return edgeHide;
        }
        public static void SaveEdgeHide(bool edgeHide)
        {
            SaveConfig("EdgeHide", edgeHide.ToString());
        }

        public static void SaveStartup(bool startUp)
        {
            SaveConfig("Startup", startUp.ToString());
        }
        static void SaveConfig(string key,string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}

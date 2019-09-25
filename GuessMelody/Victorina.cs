using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace GuessMelody
{
    static class Victorina
    {
        static public List<string> list = new List<string>();
        static public int gameDuration = 60;
        static public int musicDuration = 10;
        static public bool randomStart = false;
        static public string lastFolder = "";
        static public bool allDirectories = false;
        static public string answer = "";

        static public void ReadMusic()
        {
            try
            {
                string[] musicFiles = Directory.GetFiles(lastFolder, "*.mp3", allDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                list.Clear();
                list.AddRange(musicFiles);
            }
            catch
            {
            }
        }

        static string regKeyName = "Software\\MyCompanyName\\GuessMelody";

        public static void WriteParam()
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.CurrentUser.CreateSubKey(regKeyName);
                if (rk == null) return;
                rk.SetValue("LastFolder", lastFolder);
                rk.SetValue("randomStart", randomStart);
                rk.SetValue("gameDuration", gameDuration);
                rk.SetValue("musicDuration", musicDuration);
                rk.SetValue("allDirectories", allDirectories);
            }
            finally
            {
                if (rk != null) rk.Close();
            }
        }

        public static void ReadParam()
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.CurrentUser.OpenSubKey(regKeyName);
                if (rk != null)
                {
                    lastFolder = (string)rk.GetValue("LastFolder");
                    randomStart = Convert.ToBoolean(rk.GetValue("randomStart", false));
                    gameDuration = (int)rk.GetValue("gameDuration");
                    musicDuration = (int)rk.GetValue("musicDuration");
                    allDirectories = Convert.ToBoolean(rk.GetValue("allDirectories", false));
                }
            }
            finally
            {
                if (rk != null) rk.Close();
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UotanToolBox
{
    public class ADBHelper
    {
        public static string ADB(string adb)
        {
            string cmd = @"bin\adb\adb.exe";
            ProcessStartInfo adbshell = null;
            adbshell = new ProcessStartInfo(cmd, adb);
            adbshell.CreateNoWindow = true;
            adbshell.UseShellExecute = false;
            adbshell.RedirectStandardOutput = true;
            adbshell.RedirectStandardError = true;
            Process a = Process.Start(adbshell);
            StreamReader reader = a.StandardOutput;
            StreamReader readererror = a.StandardError;
            string output = reader.ReadToEnd();
            if (output == "")
            {
                output = readererror.ReadToEnd();
            }
            a.Close();
            return output;
        }

        public static string Fastboot(string fb)
        {
            string cmd = @"bin\adb\fastboot.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, fb);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardOutput = true;
            fastboot.RedirectStandardError = true;
            Process f = Process.Start(fastboot);
            StreamReader readererror = f.StandardError;
            StreamReader reader = f.StandardOutput;
            string output = readererror.ReadToEnd();
            if (output == "")
            {
                output = reader.ReadToEnd();
            }
            f.Close();
            return output;
        }
    }
}

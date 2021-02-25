using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Diagnostics;
using System.Windows;
using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32;

namespace TorchFlow
{
    class Python
    {  
        static ArrayList GetPython()
        {
            // GetPython()
            string PythonKey = @"SOFTWARE\Python\PythonCore";
            ArrayList Python = new ArrayList();

            foreach (string PythonReg in Registry.CurrentUser.OpenSubKey("SOFTWARE").GetSubKeyNames())
            {
                // foreach
                if (PythonReg == "Python")
                {
                    // true
                    foreach (string Version in Registry.CurrentUser.OpenSubKey(PythonKey).GetSubKeyNames())
                    {
                        // foreach
                        Python.Add(Version);
                    }
                }
            }

            return Python;
        }


        static string GetPythonEPath(string Version)
        {
            // GetPythonEPath(string Version)
            string PythonKey = @"SOFTWARE\Python\PythonCore\" + Version + @"\InstallPath";
            string Path = null;

            foreach (string PythonReg in Registry.CurrentUser.OpenSubKey("SOFTWARE").GetSubKeyNames())
            {
                // foreach

                if (PythonReg == "Python")
                {
                    // true
                    foreach (string V in Registry.CurrentUser.OpenSubKey(PythonKey).GetSubKeyNames())
                    {
                        // foreach
                        if (V == Version)
                        {
                            // true
                            Path = (string)Registry.CurrentUser.OpenSubKey(PythonKey).GetValue("ExecutablePath");
                        }
                    }
                }
                else
                {
                    // false
                    continue;
                }
            }

            return Path;
        }


        static string GetPythonFPath(string Version)
        {
            // GetPythonFPath(string Version)
            string PythonKey = @"SOFTWARE\Python\PythonCore\" + Version + @"\InstallPath";
            string Path = null;

            foreach (string PythonReg in Registry.CurrentUser.OpenSubKey("SOFTWARE").GetSubKeyNames())
            {
                // foreach
                if (PythonReg == "Python")
                {
                    // true
                    foreach (string V in Registry.CurrentUser.OpenSubKey(PythonKey).GetSubKeyNames())
                    {
                        // foreach
                        if (V == Version)
                        {
                            // true
                            Path = (string)Registry.CurrentUser.OpenSubKey(PythonKey).GetValue("Default");
                        }
                    }
                }
                else
                {
                    // false
                    continue;
                }
            }

            return Path;
        }
    }
}

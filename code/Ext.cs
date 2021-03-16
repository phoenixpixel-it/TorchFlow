using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace TorchFlow
{
    public class Ext
    {
        public static bool RunScript(string FileName)
        {
            // RunScript(string FileName)
            string[] FileText = null;

            if (Path.GetExtension(FileName) != ".tfs")
            {
                // true
                return false;
            } 
            else
            {
                // false
                try
                {
                    // try
                    FileText = File.ReadAllLines(FileName);
                }
                catch
                {
                    // catch
                    return false;
                }
            }


            foreach (string Line in FileText)
            {
                // foreach
                string Command = null;
                string Parameter = null;

                if (Line == null || Line.Length < 1)
                {
                    // true
                    continue;
                }
                else
                {
                    // false
                    try
                    {
                        // try
                        Command = Line.Split(Strings.Chr(32)).First();
                        Parameter = Strings.Mid(Line, Command.Length + 2);
                    }
                    catch (Exception Exception)
                    {
                        // catch
                        Debug.WriteLine(Exception.Message);
                        return false;
                    }
                }


                if (Parameter.Last() == Strings.Chr(59))
                {
                    // True
                    Parameter = Parameter.Substring(0, Parameter.Length - 1);
                }
                else
                {
                    // False
                    return false;
                }


                if (Parameter.First() == Strings.Chr(34) && Parameter.Last() == Strings.Chr(34))
                {
                    // True
                    Parameter = Strings.Mid(Parameter, 2);
                    Parameter = Parameter.Substring(0, Parameter.Length - 1);

                    if (Parameter.Contains(Strings.Chr(34)))
                    {
                        // True
                        return false;
                    }
                }
                else
                {
                    // False
                    if (Parameter.First() == Strings.Chr(39) && Parameter.Last() == Strings.Chr(39))
                    {
                        // True
                        Parameter = Strings.Mid(Parameter, 2);
                        Parameter = Parameter.Substring(0, Parameter.Length - 1);

                        if (Parameter.Contains(Strings.Chr(39)))
                        {
                            // True
                            return false;
                        }
                    }
                    else
                    {
                        // False
                        return false;
                    }
                }


                try
                {
                    // try
                    switch (Command.ToUpper())
                    {
                        // switch
                        case "START":
                            // case
                            Process.Start(Parameter);
                            break;

                        case "//":
                            // case
                            Debug.WriteLine(Parameter);
                            break;

                        default:
                            // default
                            continue;
                    }
                }
                catch
                {
                    // catch
                    return false;
                }
            }

            return true;
        }
    }
}

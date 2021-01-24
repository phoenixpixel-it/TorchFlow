using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows;
using TorchFlow.Properties;
using System.Diagnostics;

namespace TorchFlow
{
    public class Command
    {
        public string ID = "-1";
        public string Cmd;
        public string Args;
    }

    public class Commands
    {
        public static List<Command> CommandsList = new List<Command>();
        public static XmlDocument CommandsXML = new XmlDocument();
        public static char CommandsPrefix;

        public static void LoadCommands()
        {
            // LoadCommands()
            try
            {
                // try
                CommandsXML.Load("Commands.xml");
                CommandsPrefix = Convert.ToChar( CommandsXML.SelectSingleNode("//*/Prefix").InnerText);

                foreach (XmlNode GetInfo in CommandsXML.SelectNodes("//*/Command"))
                {
                    // foreach
                    Command AddCommand = new Command();

                    AddCommand.ID = GetInfo.SelectSingleNode("ID").InnerText;
                    AddCommand.Cmd = GetInfo.SelectSingleNode("Name").InnerText;
                    AddCommand.Args = null;

                    CommandsList.Add(AddCommand);
                }
            }
            catch (Exception Ex)
            {
                // catch
                MessageBox.Show(Ex.Message);
                System.Environment.Exit(0);
            }
        }


        internal void ReloadCommands()
        {
            // ReloadCommands()
            CommandsList.Clear();
            LoadCommands();
        }


        public static void FixCommands()
        {
            // FixCommands()
            if (File.Exists("Commands.xml") == false)
            {
                // true
                try
                {
                    // try
                    File.WriteAllText("Commands.xml", Resources.Commands);
                }
                catch (Exception Ex)
                {
                    // catch
                    MessageBox.Show(Ex.Message);
                    System.Environment.Exit(0);
                }
            }
        }


        public static Command analysis_input(List<Command> list_command, string input_search_box)                                           // ############## Luke_Screwdriver ##############                                                        
        {                                                                                                                                   // RETURN ==> the value to send at the block
            Command result = new Command();                                                                                                 // Create the result container
            String[] words = input_search_box.Split(' ');                                                                                   // make an array of string splitted by space char
            for (int a = 0; a < list_command.Count; a++)                                                                                    // 
            {
                if (words[0].Length == 0)
                    return result;                                                                                                          // output null
                if (words[0] == list_command[a].Cmd)                                                                                        // if the word correspond to the first arg
                {
                    result.ID = list_command[a].ID;                                                                                        // set num block
					result.Cmd = words[0];                                                                                                  // set the cmd
                    if(input_search_box.Contains(words[0] + " "))
                        result.Args = input_search_box.Replace(words[0] + " ", "");                                                         // set the arguments
                    else
                        result.Args = input_search_box.Replace(words[0], "");                                                               // set the arguments
                }
            }
            return result;                                                                                                                  // output is a block that contain info(block_num,args);                                                                                                                                           // return -1 if didn't find the block 
        }                                                                                                                                   // ############## END FUNCTION ##############

        string Clean_str (string input)                                                                                                     // ############## Luke_Screwdriver ##############
        {                                                                                                                                   // RETURN ==> remove double space
            String[] word = input.Split(' ');                                                                                               // make an array of string splitted by space char
            string cleanstring = "";                                                                                                        // declare output string

            for (int i = 0; i < word.Length; i++)                                                                                           // every word is checked
            {
                if (word[i] != "" && word[i] != null)                                                                                       // if the word is null skip
                    if (cleanstring == "")                                                                                                  // if the output string is empty overwrite it
                        cleanstring = word[i];
                    else                                                                                                                    // else add space char + the next word
                        cleanstring += " " + word[i];
            }
            return cleanstring;                                                                                                             // output is a clear string without doublespace
        }                                                                                                                                   // ############## END FUNCTION ##############


        public static string SearchOnGoogle (Command comando, bool exec = false)                                                            // ############## Luke_Screwdriver ##############
        {
            if (exec == true)
                Process.Start("https://www.google.com/search?q=" + comando.Args.Replace("\n", "").Replace(" ", "+"));                       // start default browser with the link

            if (comando.Args != "")
                return "Search on Google: " + comando.Args.Replace("\n", "");
            else
                return "";

        }                                                                                                                                    // ############## END FUNCTION ##############

        public static string SearchOnYoutube (Command comando, bool exec = false)                                                           // ############## Luke_Screwdriver ##############
        {
            if (exec == true)
                Process.Start("https://www.youtube.com/search?q=" + comando.Args.Replace("\n", "").Replace(" ", "+"));                      // start default browser with the link
            if (comando.Args != "")
                return "Search on Youtube: " + comando.Args.Replace("\n", "");
            else
                return "";

        }                                                                                                                                    // ############## END FUNCTION ##############

        public static string SearchOnYoutubeMusic (Command comando, bool exec = false)                                                      // ############## Luke_Screwdriver ##############
        {
            if (exec == true)
                Process.Start("https://music.youtube.com/search?q=" + comando.Args.Replace("\n", "").Replace(" ", "+"));                    // start default browser with the link

            if (comando.Args != "")
                return "Search on Youtube Music: " + comando.Args.Replace("\n", "");
            else
                return "";

        }                                                                                                                                   // ############## END FUNCTION ##############

        public static string SearchOnMaps (Command comando, bool exec = false)                                                              // ############## Luke_Screwdriver ##############
        {
            if (exec == true)
                Process.Start("https://www.google.com/maps/place/" + comando.Args.Replace("\n", "").Replace(" ", "+"));                     // start default browser with the link
            if (comando.Args != "")
                return "Search on Maps: " + comando.Args.Replace("\n", "");
            else
                return "";

        }
    }
}

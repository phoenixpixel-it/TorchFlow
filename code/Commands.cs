using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows;
using TorchFlow.Properties;

namespace TorchFlow
{
    public class Command
    {
        public string ID;
        public string Cmd;
        public string Args;
    }

    class Commands
    {
        /*
         *  LoadCommands()      -> Carica i comandi
         *  ReloadCommands()    -> Ricarica i comandi
         *  FixCommands()       -> Ripristina "Commands.xml"
         */

        public static List<Command> CommandsList = new List<Command>();
        public static XmlDocument CommandsXML = new XmlDocument();
        public static char CommandsPrefix;

        public static void LoadCommands()
        {
            // LoadCommands()
            try
            {
                // try
                CommandsXML.Load(@"xml\Commands.xml");
                CommandsPrefix = Convert.ToChar( CommandsXML.SelectSingleNode("//*/Prefix").InnerText);

                foreach (XmlNode GetInfo in CommandsXML.SelectNodes("//*/Command"))
                {
                    // foreach
                    Command AddCommand = new Command();

                    AddCommand.ID = GetInfo.SelectSingleNode("ID").InnerText;
                    AddCommand.Cmd = GetInfo.SelectSingleNode("Name").InnerText;
                    AddCommand.Args = null;

                    CommandsList.Add(AddCommand);

                    MessageBox.Show(AddCommand.ID + " " + AddCommand.Cmd);
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


        internal void FixCommands()
        {
            // FixCommands()

        }

        Command analysis_input (List<string> list_command, string input_search_box)                                                         // ############## Luke_Screwdriver ##############                                                        
        {                                                                                                                                   // RETURN ==> the value to send at the block
            Command result = new Command();                                                                                                 // Create the result container
            String[] words = input_search_box.Split(' ');                                                                                   // make an array of string splitted by space char
            for (int a = 0; a < list_command.Count; a++)                                                                                    // 
            {
                if (words[0] == list_command[a])                                                                                            // if the word correspond to the first arg
                {
                    result.ID = Convert.ToString(a);                                                                                                    // set num block
                    result.Args = input_search_box.Replace(words[0] + " ", "");                                                              // set the arguments
                }
            }
            return result;                                                                                                                  // output is a block that contain info(block_num,args); 
                                                                                                                                            // return -1 if didn't find the block 
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

    }
}

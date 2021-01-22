using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Windows;
using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;

namespace TorchFlow
{
    class LoadEvents
    {
        public static List<Config> ConfigList = new List<Config>();
        public static XmlDocument ConfigFile = new XmlDocument();
        public static List<string> CommandsList = new List<string>();
        public static XmlDocument CommandsFile = new XmlDocument();
        public static string CommandsPrefix = null;


        internal void LoadConfigFile(bool Reload)                                                                       // Carica la configurazione del programma
        {
            // LoadConfigFile(bool Reload)
            if (Reload == true)
            {
                // true
                ConfigList.Clear();                                                                                     // Resetta la lista di classi config "ConfigList"
            }


            try
            {
                // try
                LoadEvents.ConfigFile.LoadXml(Properties.Resources.Config);                                             // Carica il file "Config.xml" dalle risorse dell'applicazione


                // Settings
                Config ConfigSettings = new Config();                                                                   // Crea una nuova istanza della classe config
                string SettingsXPath = "/Config/Settings/";                                                             // Rappresenta una "shortcut" per la lettura del file xml  
                ConfigSettings.Name = "SETTINGS";                                                                       // Salva il tipo
                ConfigSettings.FolderName = ConfigFile.SelectSingleNode(SettingsXPath + "FolderName").InnerText;        // Salva il valore FolderName
                

                if (ConfigSettings.FolderName.Contains("%MYDOCS%") == true)
                {
                    // true
                    string MyDocs = Microsoft.VisualBasic.FileIO.SpecialDirectories.MyDocuments;                        // Rappresenta una "shortcut" per la cartella "Documenti"
                    ConfigSettings.FolderName.Replace("%MYDOCS%", MyDocs);                                              // Sostituisce "%MYDOCS% con la cartella "Documenti"
                }


                ConfigSettings.FileName = ConfigFile.SelectSingleNode(SettingsXPath + "FileName").InnerText;            // Salva il valore FileName
                ConfigSettings.MaxValue = ConfigFile.SelectSingleNode(SettingsXPath + "MaxValue").InnerText;            // Salva il valore MaxValue
                ConfigList.Add(ConfigSettings);                                                                         // Salva l'istanza della classe config in una lista di classi config


                // Commands
                Config ConfigCommands = new Config();                                                                   // Crea una nuova istanza della classe config
                string CommandsXPath = "/Config/Commands/";                                                             // Rappresenta una "shortcut" per la lettura del file xml
                ConfigCommands.Name = "COMMANDS";                                                                       // Salva il tipo
                ConfigCommands.FolderName = ConfigFile.SelectSingleNode(CommandsXPath + "FolderName").InnerText;        // Salva il valore FolderName


                if (ConfigCommands.FolderName.Contains("%MYDOCS%") == true)
                {
                    // true
                    string MyDocs = Microsoft.VisualBasic.FileIO.SpecialDirectories.MyDocuments;                        // Rappresenta una "shortcut" per la cartella "Documenti"
                    ConfigCommands.FolderName.Replace("%MYDOCS%", MyDocs);                                              // Sostituisce "%MYDOCS% con la cartella "Documenti"
                }


                ConfigCommands.FileName= ConfigFile.SelectSingleNode(CommandsXPath + "FileName").InnerText;             // Salva il valore FileName
                ConfigCommands.MaxValue = ConfigFile.SelectSingleNode(CommandsXPath + "MaxValue").InnerText;            // Salva il valore MaxValue
                ConfigList.Add(ConfigCommands);                                                                         // Salva l'istanza della classe config in una lista di classi config
            }
            catch (Exception Ex)
            {
                // catch
                MessageBox.Show(Ex.Message);                                                                           // In caso di eccezione reporta il messaggio di errore
                System.Environment.Exit(0);                                                                            // Esplode il programma :)
            }
        }


        internal void CheckCommandsFile(string FolderName, string FileName, int MaxValue)
        {
            // CheckCommandsFile(string FolderName, string FileName, int MaxValue)
            if (System.IO.File.Exists(FolderName + FileName) == false)
            {
                // true
                try
                {
                    // try
                    System.IO.File.WriteAllText(FolderName + FileName, Properties.Resources.Commands);                 // Scrive il file "Commands.xml"
                }
                catch (Exception Ex)
                {
                    // catch
                    MessageBox.Show(Ex.Message);                                                                       // In caso di eccezione reporta il messaggio di errore
                    System.Environment.Exit(0);                                                                        // Esplode il programma :)
                }
            }
        }


        internal void LoadCommandsFile(string FolderName, string FileName, int MaxValue, bool Reload)                  // Carica la sintassi dei comandi
        {
            // LoadCommandsFile(string FolderName, string FileName, int MaxValue, bool Reload)
            if (Reload == true)
            {
                // true
                ConfigList.Clear();                                                                                    // Resetta la lista di stringhe "CommandsList"
            }


            try
            {
                // try
                LoadEvents.CommandsFile.LoadXml(FolderName + FileName);                                                // Carica il file "Commands.xml" dalle risorse dell'applicazione


                // Prefix
                CommandsPrefix = CommandsFile.SelectSingleNode("/Commands/Prefix").InnerText;                          // Salva il prefisso dei comandi


                // Commands
                int i = 0;
                do
                {
                    // do
                    CommandsList.Add(CommandsFile.SelectSingleNode("/Commands/IDs/ID" + i).InnerText);                 // Salva i comandi nella lista di stringhe "CommandsList"
                    i++;
                }
                while (i < MaxValue);
            }
            catch (Exception Ex)
            {
                // catch
                MessageBox.Show(Ex.Message);                                                                           // In caso di eccezione reporta il messaggio di errore
                System.Environment.Exit(0);                                                                            // Esplode il programma :)
            }
        }
    }


    class Config
    {
        internal string Name;
        internal string FolderName;
        internal string FileName;
        internal string MaxValue;
    }
}

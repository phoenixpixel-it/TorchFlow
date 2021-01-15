using System;
using System.Linq;
using System.Xml;
using System.Windows;


namespace TorchFlow
{
    class LoadConfiguration
    {
        internal void LoadConfigurationFiles()
        {
            string[] args;
            if (Environment.GetCommandLineArgs().Count() > 1)
            {
                args = Environment.GetCommandLineArgs();                                     // True


                if (System.IO.File.Exists(args[1]))
                {
                    if (System.IO.Path.GetExtension(args[1]) == ".tfext")
                    {
                                                                                             // True
                    }
                }
            }

            XmlDocument LoadConfig = new XmlDocument();
            try
            {
                LoadConfig.LoadXml(Properties.Resources.Config);                             // Load config configuration (Temporaneo)

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        
            
    }
}

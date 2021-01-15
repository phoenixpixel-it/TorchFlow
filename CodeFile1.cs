using System;
using System.Xml.Linq;

static class Var
{
    public static string Direcotry_db = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Settings\\";

    public static void Check_db_directory()
    {
        if(System.IO.Directory.Exists(Direcotry_db) == false)
        {
            System.IO.Directory.CreateDirectory(Direcotry_db);
        }
        
    }

    public static void Check_xml()
    {
        if (System.IO.File.Exists(Direcotry_db + "settings.xml") == false)
        {
            XDocument xml_doc = new XDocument(new XElement("settings",
                new XElement("Width", "820"),
                new XElement("Height", "60"),
                new XElement("Color", "#FF1F1F1F")
                ));


            xml_doc.Save(Var.Direcotry_db + "settings.xml");
        }
    }
}
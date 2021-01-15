using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;                                                                                              
using System.Xml;

namespace TorchFlow
{

    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
            Var.Check_db_directory();
            Var.Check_xml();

            #region xml textbox load
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Var.Direcotry_db + "settings.xml");

                XmlNodeList CList = xmlDoc.GetElementsByTagName("Width");
                for (int i = 0; i < CList.Count; i++)
                {
                    Width_txt.Text = CList[i].InnerText.ToString();
                }
                XmlNodeList CList2 = xmlDoc.GetElementsByTagName("Height");
                for (int i = 0; i < CList2.Count; i++)
                {
                    Height_txt.Text = CList2[i].InnerText.ToString();
                }
                XmlNodeList CList3 = xmlDoc.GetElementsByTagName("Color");
                for (int i = 0; i < CList3.Count; i++)
                {
                    Color_txt.Text = CList3[i].InnerText.ToString();
                }

            }
            catch
            {
                MessageBox.Show("error xml load");
            }

            #endregion
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            #region Xml Save

            if (Width_txt.Text.Length == 0)
            {
                MessageBox.Show("Il valore Width non può essere vuoto");
                return;
            }
            if (Height_txt.Text.Length == 0)
            {
                MessageBox.Show("Il valore Height non può essere vuoto");
                return;
            }
            if (Color_txt.Text.Length == 0)
            {
                MessageBox.Show("Il valore Color non può essere vuoto");
                return;
            }

            XDocument xml_doc = new XDocument(new XElement("settings",
                new XElement("Width", Width_txt.Text),
                new XElement("Height", Height_txt.Text),
                new XElement("Color", Color_txt.Text)
                ));


            xml_doc.Save(Var.Direcotry_db + "settings.xml");

            MessageBox.Show("Saved");

            #endregion

            /*try
            {
                BrushConverter bc = new BrushConverter();
                panel.Background = (Brush)bc.ConvertFrom(TextBox1.Text);
            }
            catch
            {
                MessageBox.Show("Check the color!");
            }*/
        }
    }
}

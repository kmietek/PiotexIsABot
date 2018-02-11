using System.Collections.Generic;
using System.Windows.Forms;
using Factories.Facebook.Classes.BasicClasses;
using smallData.Facebook.Classes.AbstractClasses;
using smallData.Facebook.Classes.BasicClasses;
using smallData.Factories.PageFactory.Interfaces;

namespace smallData.Factories.PageFactory.Pages
{
    public class About : FacebookPage
    {
        private static string oldVersion = "";
        private bool _Ready = false;
        public override bool AmReady() => _Ready;

        public override List<BasicClass> GetData(string document)
        {
            //about?section=education

            // https://www.facebook.com/damian.kleszcz.7/about?section=living

            //string searchingTEXT = "<DIV><SPAN class=\"accessible_elem\">Data urodzenia</SPAN></DIV><DIV>";

            List<BasicClass> lista = new List<BasicClass>();
            if (document.Length > oldVersion.Length)
            {
                oldVersion = document;
                return null;
            }

            // now you can filer the docText to find informations!

            AboutBasic about = new AboutBasic();
            for (int i = 0; i < document.Length; i++)
            {
                string dataLine;
                int licznik;

                licznik = 0;
                dataLine = "<DIV><SPAN class=\"accessible_elem\">Data urodzenia</SPAN></DIV>\r\n<DIV>";
                dataLine = "1";
                while (licznik < dataLine.Length && dataLine[licznik] == document[i])
                {
                    string data = "";
                    bool equal = false;

                    i++;
                    licznik++;
                    while (licznik == dataLine.Length && document[i] != '<')
                    {
                        data += document[i];
                        i++;
                        equal = true;
                    }
                    if (equal)
                    {
                        about = new AboutBasic();
                        about.BitrhYear = data;
                    }
                }

                dataLine = "<DIV class=\"fsl fwb fcb\"><A href=\"https://www.facebook.com/";
                licznik = 0;
                while (licznik < dataLine.Length && dataLine[licznik] == document[i])
                {
                    string pathID = "";
                    bool equal = false;

                    i++;
                    licznik++;
                    while (licznik == dataLine.Length && document[i] != '?')
                    {
                        pathID += document[i];
                        i++;
                        equal = true;
                        if (pathID == "profile.php")
                        {
                            while (licznik == dataLine.Length && document[i] != '&')
                            {
                                pathID += document[i];
                                i++;
                            }
                            break;
                        }
                    }
                    if (equal)
                    {
//                        about.PathId = pathID;
                        lista.Add(about);
                    }
                }
            }
            _Ready = true;
            return lista;
        }
    }
}
using System.Collections.Generic;
using smallData.Facebook.Classes.AbstractClasses;
using smallData.Facebook.Classes.BasicClasses;

namespace Factories.Facebook.Classes.BasicClasses
{
    public class MainLiving : MainAbstractClass
    {
        private bool _Ready = false;
        public override bool AmReady() => _Ready;

        public override List<AncillaryAbstractClass> GetData(string document)
        {
            List<AncillaryAbstractClass> lista = new List<AncillaryAbstractClass>();
            string actualCity = "";
            AncillaryLiving city = new AncillaryLiving();
            for (int i = 0; i < document.Length; i++)
            {
                string dataLine;
                int licznik;
                char endChar;

                dataLine = "addressLocality\":\"";
                endChar = '"';
                licznik = 0;
                while (licznik < dataLine.Length && dataLine[licznik] == document[i])
                {
                    string livingCity = "";
                    bool equal = false;

                    i++;
                    licznik++;
                    while (licznik == dataLine.Length && document[i] != endChar)
                    {
                        livingCity += document[i];
                        i++;
                        equal = true;
                    }
                    if (equal)
                    {
                        actualCity = livingCity;
                    }
                }

                dataLine = "<DIV class=\"_6a _6b\"><SPAN class=\"_2iel _50f7\"><A href=\"https://www.facebook.com/pages/";
                endChar = '/';
                licznik = 0;
                while (licznik < dataLine.Length && dataLine[licznik] == document[i])
                {
                    string livingCity = "";
                    bool equal = false;

                    i++;
                    licznik++;
                    while (licznik == dataLine.Length && document[i] != endChar)
                    {
                        livingCity += document[i];
                        i++;
                        equal = true;
                    }
                    if (equal && livingCity != actualCity)
                    {
                        city.ActualCity = actualCity;
                        city.City = livingCity;
                        lista.Add(city);
                        city = new AncillaryLiving();
                    }
                }
            }
            _Ready = true;
            return lista;
        }

        public override bool CanScrool() => false;

    }
}
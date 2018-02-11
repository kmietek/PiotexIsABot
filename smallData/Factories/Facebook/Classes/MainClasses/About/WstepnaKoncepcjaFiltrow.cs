using System.Collections.Generic;
using System.Windows.Forms;
using Factories.Facebook.Classes.BasicClasses;
using smallData.Facebook.Classes.AbstractClasses;
using smallData.Facebook.Classes.BasicClasses;
using smallData.Factories.PageFactory.Interfaces;
using smallData.Helpers;

namespace smallData.Factories.PageFactory.Pages
{
    public class WstepnaKoncepcjaFiltrow : MainAbstractClass
    {
        private bool _Ready = false;
        public override bool AmReady() => _Ready;

        public override List<AncillaryAbstractClass> GetData(string document)
        {
            if (!_Ready)
            {
                List<AncillaryAbstractClass> lista = new List<AncillaryAbstractClass>();
                AncillaryEducation ancillaryAbout = new AncillaryEducation();
                AncillaryEducation ab = new AncillaryEducation();

                for (int i = 0; i < document.Length; i++)
                {
                    string dataLine;
                    int licznik;
                    
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  aktualna szkoła
                    licznik = 0;
                    dataLine = "<DIV class=\"_c24 _50f4\">Chodzi do: <A class=\"profileLink\" href=\"";
                    while (licznik < dataLine.Length && dataLine[licznik] == document[i])
                    {
                        string data = "";
                        bool equal = false;

                        i++;
                        licznik++;
                        while (licznik == dataLine.Length && document[i] != '"')
                        {
                            data += document[i];
                            i++;
                            equal = true;
                        }
                        if (equal)
                        {
//                            ab.ActualSchoolUrl = data;
                        }
                    }
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  poprzednia szkola
                    licznik = 0;
                    dataLine = "Poprzednie: <A class=\"profileLink\" href=\"";
                    while (licznik < dataLine.Length && dataLine[licznik] == document[i])
                    {
                        string data = "";
                        bool equal = false;

                        i++;
                        licznik++;
                        while (licznik == dataLine.Length && document[i] != '"')
                        {
                            data += document[i];
                            i++;
                            equal = true;
                        }
                        if (equal)
                        {
                            ab.LastSchoolUrl = data;
                        }
                    }
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  mieszka
                    licznik = 0;
                    dataLine = "Mieszka w: <A class=\"profileLink\" href=\"";
                    while (licznik < dataLine.Length && dataLine[licznik] == document[i])
                    {
                        string data = "";
                        bool equal = false;

                        i++;
                        licznik++;
                        while (licznik == dataLine.Length && document[i] != '"')
                        {
                            data += document[i];
                            i++;
                            equal = true;
                        }
                        if (equal)
                        {
//                            ab.CityUrl = data;
                        }
                    }
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  From
                    licznik = 0;
                    dataLine = "Z: <SPAN class=\"fwb\"><A class=\"profileLink\"";
                    while (licznik < dataLine.Length && dataLine[licznik] == document[i])
                    {
                        string data = "";
                        bool equal = false;

                        i++;
                        licznik++;
                        int iCopy = i;
                        while (licznik == dataLine.Length && (document[i] != '"'|| document[i-1] == '='))
                        {
                            data += document[i];
                            i++;
                            equal = true;
                        }
                        if (equal)
                        {
//                            ab.From = "";
                            bool ok = false;
                            foreach (var c in data)
                            {
                                if (ok)
                                {
//                                    ab.From += c.ToString();
                                }
                                if (c=='"')
                                {
                                    ok = true;
                                }
                            }
                        }
                    }
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////   urodziny
                    licznik = 0;
                    dataLine = "<DIV><SPAN class=\"accessible_elem\">Data urodzenia</SPAN></DIV>";
                    while (licznik < dataLine.Length && dataLine[licznik] == document[i])
                    {
                        string data = "";
                        bool equal = false;

                        i++;
                        licznik++;
                        while (licznik == dataLine.Length && document[i] != '/')
                        {
                            data += document[i];
                            i++;
                            equal = true;
                        }
                        if (equal)
                        {
//                            data._GetBirthData(ab);
                        }
                    }
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    
                }
                _Ready = true;
                return new List<AncillaryAbstractClass>(){ab};
            }
            return null;
        }
        public override bool CanScrool() => false;
    }
}
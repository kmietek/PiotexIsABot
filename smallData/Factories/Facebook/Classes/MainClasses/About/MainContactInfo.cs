using System.Collections.Generic;
using smallData.Facebook.Classes.AbstractClasses;

namespace Factories.Facebook.Classes.BasicClasses
{
    public class MainContactInfo : MainAbstractClass
    {
        private bool _Ready = false;
        public override bool AmReady() => _Ready;

        public override List<AncillaryAbstractClass> GetData(string document)
        {
            string birthday = "";
            string sex = "";
            string rel = "";
            List<string> listaIn = new List<string>();
            List<string> phone = new List<string>();
            List<AncillaryAbstractClass> lista = new List<AncillaryAbstractClass>();
            AncillaryContactInfo info = new AncillaryContactInfo();
            for (int i = 0; i < document.Length; i++)
            {
                string dataLine;
                int licznik;
                char endChar;

                dataLine = "class=\"_2iem\">";
                endChar = '<';
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
                        listaIn.Add(livingCity);
                    }
                }

                dataLine = "dir=\"ltr\">";
                endChar = '<';
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
                        phone.Add(livingCity);
                    }
                }

                dataLine = "UL class=\"uiList _4kg\">\r\n      <LI>";
                endChar = '<';
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
                        string data = "";
                        foreach (var c in livingCity)
                        {
                            if (c != '\r' && c!='\n' && c!= ',')
                            {
                                data += c.ToString();
                            }
                        }
                        info.Adres = data;
                    }
                }
            }

            foreach (var s in phone)
            {
                int a;
                if (int.TryParse(s[s.Length-1].ToString(),out a))
                {
                    string number = "";
                    foreach (var c in s)
                    {
                        if (int.TryParse(c.ToString(), out a))
                        {
                            number += c.ToString();
                        }
                    }
                    info.Phone = number;
                }
            }
            foreach (var s in listaIn)
            {
                int c;
                if (s[0] != '\r')
                {
                    if (int.TryParse(s[0].ToString(),out c))
                    {
                        string q = "";
                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i] != '\r' && s[i] != '\n')
                            {
                                if (i > 0)
                                {
                                    if (s[i] == ' ' && s[i-1] != ' ')
                                    {
                                        q += s[i];
                                    }
                                    if (s[i] != ' ')
                                    {
                                        q += s[i];
                                    }
                                }
                                else
                                {
                                    q += s[i];
                                }
                            }
                        }
                        
                        info.BirthDay = q;
                    }
                    if (s[s.Length-1] == 'a')
                    {
                        info.Sex = s;
                    }
                    if (s[s.Length - 1] == 'y' || s[s.Length - 1] == 'i')
                    {
                        info.SexPreferences = s;
                    }
                }
            }
            lista.Add(info);
            _Ready = true;
            return lista;
        }

        public override bool CanScrool() => false;

    }
}
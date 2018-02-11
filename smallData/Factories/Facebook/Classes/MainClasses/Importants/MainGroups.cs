using System;
using System.Collections.Generic;
using smallData.Facebook.Classes.AbstractClasses;
using smallData.Facebook.Classes.BasicClasses;

namespace smallData.Factories.PageFactory.Pages
{
    public class MainGroups : MainAbstractClass
    {
        private static string oldVersion = "";
        private bool _Ready = false;
        public override bool AmReady() => _Ready;

        public override List<AncillaryAbstractClass> GetData(string document)
        {
            List<AncillaryAbstractClass> lista = new List<AncillaryAbstractClass>();
            if (document.Length > oldVersion.Length)
            {
                oldVersion = document;
                return null;
            }

            // now you can filer the docText to find informations!

            AncillaryGroups groups = new AncillaryGroups();
            for (int i = 0; i < document.Length; i++)
            {
                string dataLine;
                int licznik;

                dataLine = "DIV class=\"mbs fwb\"><A href=\"";
                licznik = 0;
                while (licznik < dataLine.Length && dataLine[licznik] == document[i])
                {
                    string url = "";
                    bool equal = false;
                    i++;
                    licznik++;
                    while (licznik == dataLine.Length && document[i] != '"')
                    {
                        url += document[i];
                        i++;
                        equal = true;
                    }
                    if (equal)
                    {
                        //                        groups.PathId = pathID;
                        groups = new AncillaryGroups();
                        url += "about/";
                        groups.GroupUrl = String.Format("https://www.facebook.com{0}",url);
                    }
                }


                licznik = 0;
                dataLine = "data-hovercard-prefer-more-content-show=\"1\" data-hovercard=";
                while (licznik < dataLine.Length && dataLine[licznik] == document[i])
                {
                    string group = "";
                    bool equal = false;
                    bool canAdd = false;
                    i++;
                    licznik++;
                    while (licznik == dataLine.Length && document[i] != '<')
                    {
                        group += document[i];
                        i++;
                        equal = true;
                    }
                    if (equal)
                    {
                        groups.GroupName = "";
                        for (var k = 0; k < group.Length; k++)
                        {
                            var c = group[k];
                            if (canAdd)
                            {
                                if (c != '\r' && c != '\n' )
                                {
                                    if (group[k] == ' ' && k + 1 < group.Length)
                                    {
                                        if (group[k + 1] != ' ')
                                        {
                                            groups.GroupName += c;
                                        }
                                    }
                                    else
                                    {
                                        groups.GroupName += c;
                                    }
                                }
                            }
                            if (c == '>')
                            {
                                canAdd = true;
                            }
                        }
                        lista.Add(groups);
                    }
                }

                
            }
            _Ready = true;
            return lista;
        }

        public override bool CanScrool() => true;

    }
}
using System;
using System.Collections.Generic;
using Factories.Facebook.Classes.AncillaryClasses.Rest;
using smallData.Facebook.Classes.AbstractClasses;
using smallData.Facebook.Classes.BasicClasses;

namespace Factories.Facebook.Classes.MainClasses.Rest
{
    public class MainBooks : MainAbstractClass
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

            var book = new AncillaryBooks();
            for (int i = 0; i < document.Length; i++)
            {
                string dataLine;
                int licznik;

                licznik = 0;
                dataLine = "class=\"_2zv4 _gx8\" href=\"";
                while (licznik < dataLine.Length && dataLine[licznik] == document[i])
                {
                    string url = "";
                    bool equal = false;
                    i++;
                    licznik++;
                    while (licznik == dataLine.Length && document[i] != '?')
                    {
                        url += document[i];
                        i++;
                        equal = true;
                    }
                    if (equal)
                    {
                        book = new AncillaryBooks();
                        book.BookUrl = url;
                    }
                }

                dataLine = "DIV class=\"_gx6 _agv\"><A title=\"";
                licznik = 0;
                while (licznik < dataLine.Length && dataLine[licznik] == document[i])
                {
                    string title = "";
                    bool equal = false;
                    i++;
                    licznik++;
                    while (licznik == dataLine.Length && document[i] != '"')
                    {
                        title += document[i];
                        i++;
                        equal = true;
                    }
                    if (equal)
                    {
                        book.BookTitle = title;
                        lista.Add(book);
                    }
                }
            }
            _Ready = true;
            return lista;
        }

        public override bool CanScrool() => false;

    }
}
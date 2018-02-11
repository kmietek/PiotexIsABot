using System.Collections.Generic;
using System.Windows.Forms;
using smallData.Facebook.Classes.AbstractClasses;
using smallData.Facebook.Classes.BasicClasses;

namespace smallData.Factories.PageFactory.Pages
{
    public class Friends : FacebookPage
    {
        private static string oldVersion = "";
        private bool _Ready = false;
        public override bool AmReady() => _Ready;

        public override List<BasicClass> GetData(string document)
        {
            List<BasicClass> lista = new List<BasicClass>();
            if (document.Length > oldVersion.Length)
            {
                oldVersion = document;
                return null;
            }

            // now you can filer the docText to find informations!

            FriendBasic friend = new FriendBasic();
            for (int i = 0; i < document.Length; i++)
            {
                string dataLine;
                int licznik;

                licznik = 0;
                dataLine = "class=\"_s0 _4ooo _1ve7 _rv img\" role=\"img\" aria-label=\"";
                while (licznik < dataLine.Length && dataLine[licznik] == document[i])
                {
                    string nameAndSurname = "";
                    bool equal = false;

                    i++;
                    licznik++;
                    while (licznik == dataLine.Length && document[i] != '"')
                    {
                        nameAndSurname += document[i];
                        i++;
                        equal = true;
                    }
                    if (equal)
                    {
                        friend = new FriendBasic();
                        bool space = false;
                        string name = "";
                        string surname = "";
                        foreach (var c in nameAndSurname)
                        {
                            if (c == ' ')
                            {
                                space = true;
                            }
                            if (!space && c != ' ')
                            {
                                name += c;
                            }
                            if (space && c != ' ')
                            {
                                surname += c;
                            }
                        }
                        friend.Name = name;
                        friend.Surename = surname;
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
                        friend.PathId = pathID;
                        lista.Add(friend);
                    }
                }
            }
            _Ready = true;
            return lista;
        }

    }
}
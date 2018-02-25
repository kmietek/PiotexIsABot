using System;
using System.Collections.Generic;
using smallData.Facebook.Classes.AbstractClasses;
using smallData.Facebook.Classes.BasicClasses;

namespace Filters.Main
{
    public abstract class MainFilter
    {
        public List<string> GetData(string document, string searchingPath, char stopChar)
        {
            List<string> lista = new List<string>();

            for (int i = 0; i < document.Length; i++)
            {
                int licznik = 0;

                while (licznik < searchingPath.Length && searchingPath[licznik] == document[i])
                {
                    string pathID = "";
                    bool equal = false;

                    i++;
                    licznik++;
                    while (licznik == searchingPath.Length && document[i] != stopChar)
                    {
                        pathID += document[i];
                        i++;
                        equal = true;
                        if (pathID == "profile.php")
                        {
                            while (licznik == searchingPath.Length && document[i] != '&')
                            {
                                pathID += document[i];
                                i++;
                            }
                            break;
                        }
                    }
                    if (equal)
                    {
                        lista.Add(pathID);
                    }
                }
            }
            return null;
        }
        
    }
}
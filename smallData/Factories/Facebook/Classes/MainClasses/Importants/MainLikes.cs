using System.Collections.Generic;
using System.Windows.Forms;
using smallData.Facebook.Classes.AbstractClasses;
using smallData.Facebook.Classes.BasicClasses;

namespace smallData.Factories.PageFactory.Pages
{
    public class MainLikes : MainAbstractClass
    {
        private static string oldVersion = "";
        private bool _Ready = false;
        public override bool AmReady() => _Ready;

        //  typ     =>      <DIV class="fsm fwn fcg">       => nie działa

        public override List<AncillaryAbstractClass> GetData(string document)
        {
            List<AncillaryAbstractClass> lista = new List<AncillaryAbstractClass>();
            if (document.Length > oldVersion.Length)
            {
                oldVersion = document;
                return null;
            }

            // now you can filer the docText to find informations!

            AncillaryLikes like = new AncillaryLikes();
            for (int i = 0; i < document.Length; i++)
            {
                string dataLine;
                int licznik;

                dataLine = "class=\"_s0 _4ooo _1ve7 _rv img\" role=\"img\" aria-label=\"";
                licznik = 0;
                while (licznik < dataLine.Length && dataLine[licznik] == document[i])
                {
                    string likeName = "";
                    bool equal = false;

                    i++;
                    licznik++;
                    while (licznik == dataLine.Length && document[i] != '"')
                    {
                        likeName += document[i];
                        i++;
                        equal = true;
                    }
                    if (equal)
                    {
                        like = new AncillaryLikes();

                        like.LikedPageName = likeName;
                    }
                }
                
                licznik = 0;
                dataLine = "<DIV class=\"fsl fwb fcb\"><A href=\"";
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
                        like.LikedPageUrl = url;
                        lista.Add(like);
                    }
                }
            }
            _Ready = true;
            return lista;
        }

        public override bool CanScrool() => true;

    }
}
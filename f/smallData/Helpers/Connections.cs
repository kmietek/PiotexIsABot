using System;

namespace Helpers
{
    public class Connections
    {
        public Connections(string profilID, string pageID)
        {
            _profil = profilID;
            _page = pageID;
        }

        private static string _profil = "";
        private static string _page = "";

        public static string FacebookUrl = String.Format("https://www.facebook.com/{0}/{1}", _profil, _page);
    }
}
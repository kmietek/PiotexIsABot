using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using smallData.Facebook.Classes.AbstractClasses;
using smallData.Facebook.Root;
using smallData.Factories.PageFactory;

namespace TestApp
{
    public class FacebookSpecyficManager
    {
        public static Timer timer;
        private string id;
        private WebBrowser w;
        private EnumPages ee;

        public FacebookSpecyficManager(WebBrowser ww, EnumPages e, string idd)
        {
            ee = e;
            id = idd;
            w = ww;
        }

        public void StartProcesses()
        {
            timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += Cycle;

            w.Navigate(RootFactory.GetUrlForFacebookID(id, ee));
            w.DocumentCompleted += OnDocumentCompleted;
        }

        private void OnDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs webBrowserDocumentCompletedEventArgs)
        {
            timer.Start();
        }

        private void Cycle(object sender, EventArgs eventArgs)
        {
            List<AncillaryAbstractClass> lista;
            if (w.DocumentText.Length > 10)
            {
                if (MainFactory.GetMainClass(ee).CanScrool())
                {
                    w.Document.Body.ScrollIntoView(false);
                }
                bool ready = MainFactory.GetMainClass(ee).AmReady();
                if (!ready)
                {
                    lista = MainFactory.GetMainClass(ee).GetData(w.DocumentText);
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Factories.DataBase;
using smallData.Facebook.Classes.AbstractClasses;
using smallData.Facebook.Root;
using smallData.Factories.PageFactory;
using smallData.Helpers;
using Timer = System.Windows.Forms.Timer;

namespace smallData.Facebook
{
    public class FacebookManager
    {
        public static Timer timer;
        private int licznik = 0;
        private string id = "weronika.zywert.1";


        public void StartProcesses()
        {
            timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += Cycle;

            foreach (var page in PageFactory.PageDictionary)
            {
                page.Value.Navigate(RootFactory.GetUrlForFacebookID(id,page.Key));
                page.Value.DocumentCompleted += OnDocumentCompleted;
            }
        }

        private void OnDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs webBrowserDocumentCompletedEventArgs)
        {
            licznik++;
            if (licznik == PageFactory.PageDictionary.Count)    // test that all pages are completed
            {
                timer.Start();
            }
        }

        private void Cycle(object sender, EventArgs eventArgs)
        {
            List<bool> stop = new List<bool>();

            foreach (var enumPage in PageFactory.PageDictionary)
            {
                List<AncillaryAbstractClass> lista;
                if (enumPage.Value.DocumentText.Length > 10)
                {
                    if (MainFactory.GetMainClass(enumPage.Key).CanScrool())
                    {
                        enumPage.Value.Document.Body.ScrollIntoView(false);
                    }
                    bool ready = MainFactory.GetMainClass(enumPage.Key).AmReady();
                    if (!ready)
                    {
                        lista = MainFactory.GetMainClass(enumPage.Key).GetData(enumPage.Value.DocumentText);
                    }
                    stop.Add(ready);
                }
                if (stop.All(x => x))
                {
                    //todo  save data(lista)
                    //Restart();
                }
            }
        }


        private void Restart()
        {
            Process.Start(@"C:\Users\Piotr\Desktop\smalDATA\smalDATA\bin\Debug\smalDATA.exe");
            Application.Exit();
        }
    }
}
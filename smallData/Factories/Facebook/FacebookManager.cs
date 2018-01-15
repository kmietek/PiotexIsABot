using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Factories.DataBase;
using smallData.Facebook.Classes.AbstractClasses;
using smallData.Factories.PageFactory;
using smallData.Helpers;

namespace smallData.Facebook
{
    public class FacebookManager
    {
        private Dictionary<EFacebookEnum,List<BasicClass>> slownik = new Dictionary<EFacebookEnum, List<BasicClass>>();
        private string id = "piotr.swierzy.5";


        private Timer timer1;

        public void StartProcesses(object sender, EventArgs e)
        {
            timer1 = new Timer();
            timer1.Interval = 5000;
            timer1.Tick += Cycle;
            timer1.Start();

            foreach (var enumPage in EnumHelper.GetValues<EFacebookEnum>())
            {
                FacebookFactory.GetPage(enumPage).Navigate(String.Format("https://www.facebook.com/{0}/{1}", id, enumPage.ToString().ToLower()));
                slownik.Add(enumPage,null);
            }
        }

        private void Cycle(object sender, EventArgs eventArgs)
        {
            List<bool> stop = new List<bool>();

            foreach (var enumPage in FacebookFactory.PageDictionary)
            {
                enumPage.Value.Document.Body.ScrollIntoView(false);  //  1 scroll = +20 items to document text 
                var lista = Factories.PageFactory.FacebookFactory.GetObject(enumPage.Key).GetData(enumPage.Value.DocumentText); //take document text and return list of objects
                var bol = Factories.PageFactory.FacebookFactory.GetObject(enumPage.Key).AmReady();

                slownik[enumPage.Key] = lista;
                stop.Add(bol);
            }
            if (stop.All(x => x))
            {
                DBManager.StartDBProcesses(slownik);
                Restart();
            }

        }


        private void Restart()
        {
            Process.Start(@"C:\Users\Piotr\Desktop\smalDATA\smalDATA\bin\Debug\smalDATA.exe");
            Application.Exit();
        }
    }
}
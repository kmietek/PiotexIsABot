using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using smallData.Factories.PageFactory;
using smallData.Helpers;

namespace smallData.Facebook
{
    public class FacebookManager
    {
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
            }
        }

        private void Cycle(object sender, EventArgs eventArgs)
        {
            List<bool> stop = new List<bool>();

            foreach (var enumPage in FacebookFactory.PageDictionary)
            {
                //bool val = Factories.Facebook.Factory.FacebookFactory.GetFacebookClasses(enumPage).AmReady();
                //PageFactory.PageFactory.StartPageMethod(enumPage);
                //stop.Add(val);
            }
            if (stop.All(x => x))
            {
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
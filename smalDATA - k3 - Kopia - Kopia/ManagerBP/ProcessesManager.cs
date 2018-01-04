using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DBCommunication;
using FacebookToolsBP;
using FacebookToolsBP.FacebookInfoFactory;
using ToDelLibrary;

namespace ManagerBP
{
    public class ProcessesManager
    {
        //WebBrowser FacebookLikesPage = new WebBrowser();
        FacebookConection Conection = new FacebookConection();
        PostgreComands comands = new PostgreComands("postgres", "start12345", "localhost", "5432", "smalDATA");

        public void StartAllProcesses()
        {
            string id = comands.GetUserIdToStartProcesses();
            //comands.Update("usersidtable", "checked", "1", "facebookid", id);
            ToDel.UserID = id;
            int locationX = 0;
            foreach (var page in FacebookInfoFactory.facebookPagesDictionary)
            {
                Timer timer = new Timer();
                timer.Start();
                timer.Interval = 3000;
                timer.Tick += (_page, _info) => ProcessesToDo(page.Value, page.Key);

                page.Value.Size = new Size(500,1100);
                page.Value.Location = new Point(locationX,0);
                locationX += 500;

                ToDel.form.Controls.Add(page.Value);              //todo delete it
                Conection.Connect(FacebookInfoFactory.facebookPagesDictionary[page.Key], id, page.Key.ToString());
            }

            //FacebookInfoFactory.facebookPagesDictionary[FacebookInfoEnum.Friends].Dock = DockStyle.Fill;              //todo delete it
        }

        private void ProcessesToDo(WebBrowser page, FacebookInfoEnum info)
        {
            var infoFromPage = FacebookInfoFactory.GetInfoFromFacebookPage(page, info);

            if (ToDel.friendsStop && ToDel.likesStop)
            {
                comands.UpdateValueWhereIsNull("usersidtable", "checked", "0", "checked");
                Restart();
            }
        }

        private void Restart()
        {
            Process.Start(@"C:\Users\Piotr\Desktop\smalDATA - k3 - Kopia - Kopia\smalDATA\bin\Debug\smalDATA.exe");
            Application.Exit();
            ToDel.form.Close();
        }
    }
}
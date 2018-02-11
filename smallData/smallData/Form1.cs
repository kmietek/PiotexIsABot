using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using smallData.Facebook;
using smallData.Facebook.Root;
using smallData.Factories.PageFactory;
using Timer = System.Windows.Forms.Timer;

namespace smallData
{
    public partial class Form1 : Form
    {
        public static Form form1;
        public Form1()
        {
            form1 = this;
//            test();
//            test();
            start();
            InitializeComponent();
        }

        private FacebookManager manager;
        private void start()
        {
            int size = 300;
            int x = 50;
            foreach (var web in PageFactory.PageDictionary.Values)
            {
                web.Size = new Size(size, 800);
                web.Location = new Point(x);
                x += size;
                Controls.Add(web);
            }
            manager = new FacebookManager();
            manager.StartProcesses();

        }

        //////////////////////////////////////////////////////////////////////////////////////

        private int licz = 0;
        private WebBrowser w;
        private List<string> l;

        public void test()
        {
            l = new List<string>
            {
                "https://www.facebook.com/profile.php?id=100002368868885&lst=100004370412103%3A100002368868885%3A1516404310",
                "https://www.facebook.com/profile.php?id=100002368868885&lst=100004370412103%3A100002368868885%3A1516404310&sk=about",
                "https://www.facebook.com/profile.php?id=100002368868885&lst=100004370412103%3A100002368868885%3A1516404310&sk=about&section=education&pnref=about",
                "https://www.facebook.com/profile.php?id=100002368868885&lst=100004370412103%3A100002368868885%3A1516404310&sk=about&section=living&pnref=about",
                "https://www.facebook.com/profile.php?id=100002368868885&lst=100004370412103%3A100002368868885%3A1516404310&sk=about&section=contact-info&pnref=about",
                "https://www.facebook.com/profile.php?id=100002368868885&lst=100004370412103%3A100002368868885%3A1516404310&sk=about&section=relationship&pnref=about",
                "https://www.facebook.com/profile.php?id=100002368868885&lst=100004370412103%3A100002368868885%3A1516404310&sk=about&section=bio&pnref=about",
                "https://www.facebook.com/profile.php?id=100002368868885&lst=100004370412103%3A100002368868885%3A1516404310&sk=about&section=year-overviews&pnref=about",
                "https://www.facebook.com/profile.php?id=100002368868885&lst=100004370412103%3A100002368868885%3A1516404310&sk=likes"
            };
            w = new WebBrowser();
            //Controls.Add(w);
            //w.Size = new Size(800,800);
            Timer timer = new Timer();
            timer.Interval = 8000;
            timer.Tick += Cycle;
            timer.Start();
        }

        private void Cycle(object sender, EventArgs e)
        {
            if (licz < l.Count)
            {
                w.Navigate(l[licz]);
                licz++;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            FacebookManager.timer.Stop();
        }
    }
}

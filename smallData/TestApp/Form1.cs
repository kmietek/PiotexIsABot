using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using smallData.Facebook;
using smallData.Factories.PageFactory;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public static Form form1;
        public Form1()
        {
            form1 = this;
            start();
            InitializeComponent();
        }

        private EnumPages page = EnumPages.CommingEvents;        //     <==    !!!!!!!!!!!!!!!!!!!!
        private string id = "larysa.hadasch";

        private void start()
        {
            var web = PageFactory.GetPage(page);
            web.Size = new Size(800, 800);
            Controls.Add(web);
            var manager = new FacebookSpecyficManager(web,page,id);
            manager.StartProcesses();

        }

    }
}

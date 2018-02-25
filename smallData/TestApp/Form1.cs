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

        private Config conf = new Config();

        private void start()
        {
            var web = PageFactory.GetPage(conf.page);
            web.Size = new Size(800, 800);
            Controls.Add(web);
            var manager = new FacebookSpecyficManager(web,conf.page,conf.id);
            manager.StartProcesses();

        }

    }
}

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

namespace smallData
{
    public partial class Form1 : Form
    {
        public static Form form1;
        private FacebookManager manager;
        public Form1()
        {
            form1 = this;
            add();
            InitializeComponent();
            manager = new FacebookManager();
            manager.StartProcesses();
        }

        public void add()
        {
            int size = 500;
            int x = 0;
            foreach (var web in FacebookFactory.PageDictionary.Values)
            {
                web.Size = new Size(size,800);
                web.Location = new Point(x);
                x += size;
                Controls.Add(web);
            }
        }

    }
}

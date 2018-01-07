using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using smallData.Factories.PageFactory;
using smallData.Helpers;

namespace smallData
{
    public partial class Form1 : Form
    {
        private Timer timer1;
        public static Form form1;

        public Form1()
        {
            InitializeComponent();
            form1 = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1 = new Timer();
            timer1.Interval = 5000;
            timer1.Tick += Cycle;
            timer1.Start();
        }

        private void Cycle(object sender, EventArgs eventArgs)
        {
            foreach (var browser in EnumHelper.GetValues<PageEnum>())
            {
                
            }
        }

        private void Restart()
        {
            Process.Start(@"C:\Users\Piotr\Desktop\smalDATA\smalDATA\bin\Debug\smalDATA.exe");
            Application.Exit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerBP;
using ToDelLibrary;

namespace smalDATA
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            ToDelLibrary.ToDel.form = this;
            InitializeComponent();
            new ProcessesManager().StartAllProcesses();
            Feedback.feedback.Show();
            Feedback.feedback.StartPosition = FormStartPosition.Manual;
            Feedback.feedback.Location = new Point(0, 0);

        }
    }
}

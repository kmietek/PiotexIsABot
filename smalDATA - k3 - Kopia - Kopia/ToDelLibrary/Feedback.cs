using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDelLibrary
{
    public partial class Feedback : Form
    {
        public static Feedback feedback = new Feedback();

        public Feedback()
        {
            feedback = this;
            InitializeComponent();
            this.Working.Checked = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VocTreeGUI
{
    public partial class UCAnalyze : MetroFramework.Controls.MetroUserControl
    {
        public UCAnalyze()
        {
            InitializeComponent();
        }

        private void UCAnalyze_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            foreach(MetroFramework.Controls.MetroPanel panels in f1.Controls)
            {
                //siwtch it up
            }
        }
    }
}

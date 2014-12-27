using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EserRomeHomeUI;

namespace EserRomaHome
{
    public partial class RomeHome : Form
    {
        public RomeHome()
        {
            InitializeComponent();
        }


        private void tsbSatis_Click(object sender, EventArgs e)
        {
            SatisForm x = new SatisForm();
            x.MdiParent = this;
            x.Show();
        }

        private void barkodOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateBarkodForm crbrkd = new CreateBarkodForm();
            crbrkd.MdiParent = this;
            crbrkd.Show();
        }

        private void alisFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlisForm crbrkd = new AlisForm();
            crbrkd.MdiParent = this;
            crbrkd.Show();
        }

    }
}

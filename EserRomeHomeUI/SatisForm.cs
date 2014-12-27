using EserRomeHomeBussines;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EserRomeHomeUI
{
    public partial class SatisForm : Form
    {
        public SatisForm()
        {
            InitializeComponent();
        }

        private void SatisForm_Load(object sender, EventArgs e)
        {
            Urun u = new Urun();
            u.Barkod = 1;
            dataGridView1.DataSource = u.GetUrunByBarkod(u);
        }

    }
}

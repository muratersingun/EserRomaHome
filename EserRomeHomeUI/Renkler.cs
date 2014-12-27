using EserRomeHomeBussines;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EserRomeHomeUI
{
    public partial class Renkler : Form
    {
        public Renkler()
        {
            InitializeComponent();
        }

        Renk SelectedFrima;
        private void Renkler_Load(object sender, EventArgs e)
        {
            List<Renk> TumRenklar = Renk.GetAllRenk();
            dataGridView1.DataSource = TumRenklar;
        }

        private void tsbtnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRenkAdi.Text))
            {
                MessageBox.Show("Frima Adı Boş Bırakılamaz!!!");
                return;
            }

            Renk f = new Renk { RenkKodu = txtRenkKodu.Text, RenkAdi = txtRenkAdi.Text };
            if (Renk.Kaydet(f))
            {
                MessageBox.Show("Yeni Renk Kaydedilmiştir");
                Clear();
                List<Renk> TumRenklar = Renk.GetAllRenk();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = TumRenklar;
            }
            else
            {
                MessageBox.Show("Bir hata oluştu!!!");
            }   
        }

        private void tsbtnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRenkAdi.Text) || string.IsNullOrEmpty(txtRenkKodu.Text))
            {
                MessageBox.Show("Renk Adı Boş Bırakılamaz!!!");
                return;
            }

            Renk f = new Renk { RenkKodu = txtRenkKodu.Text, RenkAdi = txtRenkAdi.Text };
            if (Renk.Update(f))
            {
                MessageBox.Show("Kayıt Güncellenmiştir");
                Clear();
                List<Renk> TumRenklar = Renk.GetAllRenk();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = TumRenklar;
            }
            else
            {
                MessageBox.Show("Bir hata oluştu!!!");
            }   
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRenkAdi.Text) || string.IsNullOrEmpty(txtRenkKodu.Text))
            {
                MessageBox.Show("Lütfen Bir Kayıt Seçiniz!!!");
                return;
            }

            Renk f = new Renk { RenkKodu = txtRenkKodu.Text, RenkAdi = txtRenkAdi.Text };
            if (Renk.Delete(f))
            {
                MessageBox.Show("Kayıt Silinmiştir");
                Clear();
                List<Renk> TumRenklar = Renk.GetAllRenk();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = TumRenklar;
            }
            else
            {
                MessageBox.Show("Bir hata oluştu!!!");
            }  
        }

       

        private void GridViewRenk_ShowingEditor(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void Renkler_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SelectedFrima != null)
            {
                List<Control> controllst = (List<Control>)this.Tag;
                foreach (Control item in controllst)
                {
                    if (item.Name == "txtRenkKodu")
                    {
                        item.Text = SelectedFrima.RenkKodu;
                    }
                    if (item.Name == "txtRenk")
                    {
                        item.Text = SelectedFrima.RenkAdi;
                    }
                }
            }
        }

        private void Clear()
        {
            txtRenkAdi.Clear();
            txtRenkKodu.Clear();
            SelectedFrima = null;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            String SecilenRenkKodu = dataGridView1.CurrentRow.Cells["RenkKodu"].Value.ToString();
            String SecilenRenkAdi = dataGridView1.CurrentRow.Cells["RenkAdi"].Value.ToString();

            if (!String.IsNullOrEmpty(SecilenRenkAdi) || !String.IsNullOrEmpty(SecilenRenkKodu))
            {
                SelectedFrima = new Renk { RenkKodu = SecilenRenkKodu, RenkAdi = SecilenRenkAdi };
            }

            txtRenkKodu.Text = SelectedFrima.RenkKodu.ToString();
            txtRenkAdi.Text = SelectedFrima.RenkAdi.ToString();
        }

       
    }
}

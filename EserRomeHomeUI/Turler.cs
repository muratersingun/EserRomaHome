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
    public partial class Turler : Form
    {
        public Turler()
        {
            InitializeComponent();
        }
        Tur SelectedTur;
        private void Turler_Load(object sender, EventArgs e)
        {
            List<Tur> TumTurler = Tur.GetAllTur();
            dataGridView1.DataSource = TumTurler;
        }

        private void GridWievTurler_ShowingEditor(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void tsbtnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTurAdi.Text))
            {
                MessageBox.Show("Tur Adı Boş Bırakılamaz!!!");
                return;
            }
            
            Tur f = new Tur { TurKodu = txtTurKodu.Text, TurAdi = txtTurAdi.Text };
            if (Tur.Kaydet(f))
            {
                MessageBox.Show("Yeni Tur Kaydedilmiştir");
                Clear();
                List<Tur> TumTurlar = Tur.GetAllTur();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = TumTurlar;
            }
            else
            {
                MessageBox.Show("Bir hata oluştu!!!");
            }           
        }

        private void tsbtnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTurAdi.Text) || string.IsNullOrEmpty(txtTurKodu.Text))
            {
                MessageBox.Show("Tur Adı Boş Bırakılamaz!!!");
                return;
            }

            Tur f = new Tur { TurKodu = txtTurKodu.Text, TurAdi = txtTurAdi.Text };
            if (Tur.Update(f))
            {
                MessageBox.Show("Kayıt Güncellenmiştir");
                Clear();
                List<Tur> TumTurlar = Tur.GetAllTur();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = TumTurlar;
            }
            else
            {
                MessageBox.Show("Bir hata oluştu!!!");
            }   
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTurAdi.Text) || string.IsNullOrEmpty(txtTurKodu.Text))
            {
                MessageBox.Show("Lütfen Bir Kayıt Seçiniz!!!");
                return;
            }

            Tur f = new Tur { TurKodu = txtTurKodu.Text, TurAdi = txtTurAdi.Text };
            if (Tur.Delete(f))
            {
                MessageBox.Show("Kayıt Silinmiştir");
                Clear();
                List<Tur> TumTurlar = Tur.GetAllTur();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = TumTurlar;
            }
            else
            {
                MessageBox.Show("Bir hata oluştu!!!");
            } 
        }

      
        private void Clear()
        {
            txtTurAdi.Clear();
            txtTurKodu.Clear();
            SelectedTur = null;
        }

        private void Turler_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SelectedTur != null)
            {
                List<Control> controllst = (List<Control>)this.Tag;
                foreach (Control item in controllst)
                {
                    if (item.Name == "txtTuruKodu")
                    {
                        item.Text = SelectedTur.TurKodu;
                    }
                    if (item.Name == "txtTuru")
                    {
                        item.Text = SelectedTur.TurAdi;
                    }
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            String SecilenTurKodu = dataGridView1.CurrentRow.Cells["TurKodu"].Value.ToString();
            String SecilenTurAdi = dataGridView1.CurrentRow.Cells["TurAdi"].Value.ToString();

            if (!String.IsNullOrEmpty(SecilenTurAdi) || !String.IsNullOrEmpty(SecilenTurKodu))
            {
                SelectedTur = new Tur { TurKodu = SecilenTurKodu, TurAdi = SecilenTurAdi };
            }

            txtTurKodu.Text = SelectedTur.TurKodu.ToString();
            txtTurAdi.Text = SelectedTur.TurAdi.ToString();
        }

    }
}

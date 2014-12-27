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
    public partial class Olculer : Form
    {
        public Olculer()
        {
            InitializeComponent();
        }

        String gTurKodu = String.Empty;
        Olcu SelectedOlcu;
        private void Olculer_Load(object sender, EventArgs e)
        {
            List<Control> controllst = (List<Control>)this.Tag;

            foreach (Control item in controllst)
            {
                if (item.Name == "txtTuruKodu")
                {
                    TextBox t = (TextBox)item;
                    gTurKodu = t.Text;
                }
            }
            if (!String.IsNullOrEmpty(gTurKodu))
            {
                List<Olcu> TümFrimalar = Olcu.GetAllOlcuOfTur(gTurKodu);
                dataGridView1.DataSource = TümFrimalar;
            }
        }

        private void tsbtnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOlcuAdi.Text))
            {
                MessageBox.Show("Ölçü Adı Boş Bırakılamaz!!!");
                return;
            }

            Olcu o = new Olcu { TurKodu = gTurKodu, OlcuKodu = txtOlcuKodu.Text, OlcuAdi = txtOlcuAdi.Text };
            if (Olcu.Kaydet(o))
            {
                MessageBox.Show("Yeni Olcu Kaydedilmiştir");
                Clear();
                List<Olcu> TumOlculer = Olcu.GetAllOlcuOfTur(gTurKodu);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = TumOlculer;
            }
            else
            {
                MessageBox.Show("Bir hata oluştu!!!");
            }  
        }

        private void tsbtnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOlcuAdi.Text))
            {
                MessageBox.Show("Ölçü Adı Boş Bırakılamaz!!!");
                return;
            }

            Olcu o = new Olcu { TurKodu = gTurKodu, OlcuKodu = txtOlcuKodu.Text, OlcuAdi = txtOlcuAdi.Text };
            if (Olcu.Update(o))
            {
                MessageBox.Show("Olcu Güncellenmiştir");
                Clear();
                List<Olcu> TumOlculer = Olcu.GetAllOlcuOfTur(gTurKodu);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = TumOlculer;
            }
            else
            {
                MessageBox.Show("Bir hata oluştu!!!");
            }    
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOlcuAdi.Text))
            {
                MessageBox.Show("Lütfen Bir Kayıt Seçiniz!!!");
                return;
            }
            
            Olcu o = new Olcu { TurKodu = gTurKodu, OlcuKodu = txtOlcuKodu.Text, OlcuAdi = txtOlcuAdi.Text };
            if (Olcu.Delete(o))
            {
                MessageBox.Show("Ölçü Silinmiştir");
                Clear();
                List<Olcu> TumOlculer = Olcu.GetAllOlcuOfTur(gTurKodu);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = TumOlculer;
            }
            else
            {
                MessageBox.Show("Bir hata oluştu!!!");
            }  
        }

       

        private void GridViewOlcu_ShowingEditor(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void Clear()
        {
            txtTurKodu.Clear();
            txtOlcuKodu.Clear();
            txtOlcuAdi.Clear();
            SelectedOlcu = null;
        }

        private void Olculer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SelectedOlcu != null)
            {
                List<Control> controllst = (List<Control>)this.Tag;
                foreach (Control item in controllst)
                {
                    if (item.Name == "txtOlcuKodu")
                    {
                        item.Text = SelectedOlcu.OlcuKodu;
                    }
                    if (item.Name == "txtOlcu")
                    {
                        item.Text = SelectedOlcu.OlcuAdi;
                    }
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            String SecilenTurKodu = dataGridView1.CurrentRow.Cells["TurKodu"].Value.ToString();
            String SecilenOlcuKodu = dataGridView1.CurrentRow.Cells["OlcuKodu"].Value.ToString();
            String SecilenOlcuAdi = dataGridView1.CurrentRow.Cells["OlcuAdi"].Value.ToString();

            if (!String.IsNullOrEmpty(SecilenOlcuAdi))
            {
                SelectedOlcu = new Olcu { TurKodu = SecilenTurKodu, OlcuKodu = SecilenOlcuKodu, OlcuAdi = SecilenOlcuAdi };
            }

            txtTurKodu.Text = SelectedOlcu.TurKodu.ToString();
            txtOlcuKodu.Text = SelectedOlcu.OlcuKodu.ToString();
            txtOlcuAdi.Text = SelectedOlcu.OlcuAdi.ToString();
        }



    }
}

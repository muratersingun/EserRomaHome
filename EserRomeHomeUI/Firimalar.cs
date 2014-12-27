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
    public partial class Firimalar : Form
    {
        public Firimalar()
        {
            InitializeComponent();              
        }

        Firima SelectedFrima;
        private void Form3_Load(object sender, EventArgs e)
        {
            List<Firima> TumFirimalar = Firima.GetAllFrima();
            dataGridView1.DataSource = TumFirimalar;
        }

        private void tsbtnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFrimaAdi.Text))
            {
                MessageBox.Show("Frima Adı Boş Bırakılamaz!!!");
                return;
            }

            Firima f = new Firima {FrimaKodu = txtFrimaKod.Text,FrimaAdi = txtFrimaAdi.Text};
            if (Firima.Kaydet(f))
	        {
                MessageBox.Show("Yeni Frima Kaydedilmiştir");
                Clear();
                List<Firima> TumFirimalar = Firima.GetAllFrima();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = TumFirimalar;
            }
            else
            {
                MessageBox.Show("Bir hata oluştu!!!");
            }                          
        }

       

        private void tsbtnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFrimaAdi.Text) || string.IsNullOrEmpty(txtFrimaKod.Text))
            {
                MessageBox.Show("Frima Adı Boş Bırakılamaz!!!");
                return;
            }

            Firima f = new Firima { FrimaKodu = txtFrimaKod.Text, FrimaAdi = txtFrimaAdi.Text };
            if (Firima.Update(f))
            {
                MessageBox.Show("Kayıt Güncellenmiştir");
                Clear();
                List<Firima> TumFirimalar = Firima.GetAllFrima();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = TumFirimalar;
            }
            else
            {
                MessageBox.Show("Bir hata oluştu!!!");
            }    
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFrimaAdi.Text) || string.IsNullOrEmpty(txtFrimaKod.Text))
            {
                MessageBox.Show("Lütfen Bir Kayıt Seçiniz!!!");
                return;
            }

            Firima f = new Firima { FrimaKodu = txtFrimaKod.Text, FrimaAdi = txtFrimaAdi.Text };
            if (Firima.Delete(f))
            {
                MessageBox.Show("Kayıt Silinmiştir");
                Clear();
                List<Firima> TumFirimalar = Firima.GetAllFrima();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = TumFirimalar;      
            }
            else
            {
                MessageBox.Show("Bir hata oluştu!!!");
            }   
        }

        private void Clear()
        {
            txtFrimaAdi.Clear();
            txtFrimaKod.Clear();
            SelectedFrima = null;
        }


        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SelectedFrima != null)
            {
                List<Control> controllst = (List<Control>)this.Tag;
                foreach (Control item in controllst)
                {
                    if (item.Name == "txtFirmaKodu")
                    {
                        item.Text = SelectedFrima.FrimaKodu;
                    }
                    if (item.Name == "txtFirma")
                    {
                        item.Text = SelectedFrima.FrimaAdi;
                    }
                }
            }
        }

        private void GridWievFirima_ShowingEditor(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            String SecilenFrimaKodu = dataGridView1.CurrentRow.Cells["FrimaKodu"].Value.ToString();
            String SecilenFrimaAdi = dataGridView1.CurrentRow.Cells["FrimaAdi"].Value.ToString();

            if (!String.IsNullOrEmpty(SecilenFrimaAdi) || !String.IsNullOrEmpty(SecilenFrimaKodu))
            {
                SelectedFrima = new Firima { FrimaKodu = SecilenFrimaKodu, FrimaAdi = SecilenFrimaAdi };
            }

            txtFrimaKod.Text = SelectedFrima.FrimaKodu.ToString();
            txtFrimaAdi.Text = SelectedFrima.FrimaAdi.ToString();
        }
                   
    }
}

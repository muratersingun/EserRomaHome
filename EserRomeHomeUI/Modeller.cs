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
    public partial class Modeller : Form
    {
        public Modeller()
        {
            InitializeComponent();
        }

        String gFrimaKodu = String.Empty;
        Model SelectedModel;
        private void Modeller_Load(object sender, EventArgs e)
        {
            List<Control> controllst = (List<Control>)this.Tag;
            
            foreach (Control item in controllst)
            {
                if (item.Name == "txtFirmaKodu")
                {
                    TextBox t = (TextBox)item;
                    gFrimaKodu = t.Text;
                }
            }
            if (!String.IsNullOrEmpty(gFrimaKodu))
            {
                List<Model> TümFrimalar = Model.GetAllModelofFirima(gFrimaKodu);
                dataGridView1.DataSource = TümFrimalar;
            }
        }

        private void tsbtnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtModelAdi.Text))
            {
                MessageBox.Show("Model Adı Boş Bırakılamaz!!!");
                return;
            }

            Model m = new Model {FrimaKodu =gFrimaKodu , ModelKodu = txtModelKodu.Text, ModelAdi = txtModelAdi.Text };
            if (Model.Kaydet(m))
            {
                MessageBox.Show("Yeni Model Kaydedilmiştir");
                Clear();
                List<Model> TumModeller = Model.GetAllModelofFirima(gFrimaKodu);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = TumModeller;
            }
            else
            {
                MessageBox.Show("Bir hata oluştu!!!");
            }             
        }

        

        private void tsbtnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtModelAdi.Text))
            {
                MessageBox.Show("Model Adı Boş Bırakılamaz!!!");
                return;
            }

            Model m = new Model { FrimaKodu = gFrimaKodu, ModelKodu = txtModelKodu.Text, ModelAdi = txtModelAdi.Text };
            if (Model.Update(m))
            {
                MessageBox.Show("Model Güncellenmiştir");
                Clear();
                List<Model> TumModeller = Model.GetAllModelofFirima(gFrimaKodu);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = TumModeller;
            }
            else
            {
                MessageBox.Show("Bir hata oluştu!!!");
            }             
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtModelAdi.Text))
            {
                MessageBox.Show("Lütfen Bir Kayıt Seçiniz!!!");
                return;
            }

            Model m = new Model { FrimaKodu = gFrimaKodu, ModelKodu = txtModelKodu.Text, ModelAdi = txtModelAdi.Text };
            if (Model.Delete(m))
            {
                MessageBox.Show("Model Silinmiştir");
                Clear();
                List<Model> TumModeller = Model.GetAllModelofFirima(gFrimaKodu);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = TumModeller;
            }
            else
            {
                MessageBox.Show("Bir hata oluştu!!!");
            }  
        }

        private void Clear()
        {
            txtFrimaKodu.Clear();
            txtModelKodu.Clear();
            txtModelAdi.Clear();
            SelectedModel = null;
        }

        private void GridViewModel_ShowingEditor(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void Modeller_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SelectedModel != null)
            {
                List<Control> controllst = (List<Control>)this.Tag;
                foreach (Control item in controllst)
                {
                    if (item.Name == "txtModelKodu")
                    {
                        item.Text = SelectedModel.ModelKodu;
                    }
                    if (item.Name == "txtUrun")
                    {
                        item.Text = SelectedModel.ModelAdi;
                    }
                }
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String SecilenFrimaKodu = dataGridView1.CurrentRow.Cells["FrimaKodu"].Value.ToString();
            String SecilenModelKodu = dataGridView1.CurrentRow.Cells["ModelKodu"].Value.ToString();
            String SecilenModelAdi = dataGridView1.CurrentRow.Cells["ModelAdi"].Value.ToString();

            if (!String.IsNullOrEmpty(SecilenModelAdi))
            {
                SelectedModel = new Model { FrimaKodu = SecilenFrimaKodu, ModelKodu = SecilenModelKodu, ModelAdi = SecilenModelAdi };
            }

            txtFrimaKodu.Text = SelectedModel.FrimaKodu.ToString();
            txtModelKodu.Text = SelectedModel.ModelKodu.ToString();
            txtModelAdi.Text = SelectedModel.ModelAdi.ToString();
        }
    }
}

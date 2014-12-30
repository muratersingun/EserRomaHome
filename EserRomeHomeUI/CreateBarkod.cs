using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EserRomeHomeUI
{
    public partial class CreateBarkodForm : Form
    {
        PrintDocument doc = new PrintDocument();
        Ean13Barcode2005.Ean13 barcode = new Ean13Barcode2005.Ean13();
        public CreateBarkodForm()
        {
            InitializeComponent();
        }

        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int a = 5;
            int b = 5;
            if (txtEtiket.Value.ToString() == "1")
            {

                e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new Point(Convert.ToInt32(3), Convert.ToInt32(txtYaziUst1.Value)))); // ÜST  2
                e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new Point(Convert.ToInt32(3), Convert.ToInt32(txtYaziAlt1.Value))));
                barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(txtYatBosluk1.Value), Convert.ToInt32(txtDikBosluk1.Value))));
       
            }
            if (txtEtiket.Value.ToString() == "2")
            {
                e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new Point(Convert.ToInt32(3), Convert.ToInt32(txtYaziUst1.Value)))); // ÜST  2
                e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new Point(Convert.ToInt32(3), Convert.ToInt32(txtYaziAlt1.Value))));
                barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(txtYatBosluk1.Value), Convert.ToInt32(txtDikBosluk1.Value))));
                e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(txtYaziUst2.Value)))); // ÜST 86
                e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(txtYaziAlt2.Value)))); // ALT 153
                barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(txtYatBosluk2.Value), Convert.ToInt32(txtDikBosluk2.Value))));
            }
            if (txtEtiket.Value.ToString() == "3")
            {
                e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new Point(Convert.ToInt32(3), Convert.ToInt32(txtYaziUst1.Value)))); // ÜST  2
                e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new Point(Convert.ToInt32(3), Convert.ToInt32(txtYaziAlt1.Value))));
                barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(txtYatBosluk1.Value), Convert.ToInt32(txtDikBosluk1.Value))));
                e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(txtYaziUst2.Value)))); // ÜST 86
                e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(txtYaziAlt2.Value)))); // ALT 153
                barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(txtYatBosluk2.Value), Convert.ToInt32(txtDikBosluk2.Value))));
                e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(txtYaziUst3.Value)))); // ÜST 169
                e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(txtYaziAlt3.Value)))); // ALT 243
                barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(txtYatBosluk3.Value), Convert.ToInt32(txtDikBosluk3.Value))));
            }
            if (txtEtiket.Value.ToString() == "4")
            {
                e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new Point(Convert.ToInt32(3), Convert.ToInt32(txtYaziUst1.Value)))); // ÜST  2
                e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new Point(Convert.ToInt32(3), Convert.ToInt32(txtYaziAlt1.Value))));
                barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(txtYatBosluk1.Value), Convert.ToInt32(txtDikBosluk1.Value))));
                e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(txtYaziUst2.Value)))); // ÜST 86
                e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(txtYaziAlt2.Value)))); // ALT 153
                barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(txtYatBosluk2.Value), Convert.ToInt32(txtDikBosluk2.Value))));
                e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(txtYaziUst3.Value)))); // ÜST 169
                e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(txtYaziAlt3.Value)))); // ALT 243
                barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(txtYatBosluk3.Value), Convert.ToInt32(txtDikBosluk3.Value))));
                e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(txtYaziUst4.Value)))); // ÜST 248
                e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(txtYaziAlt4.Value))));
                barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(txtYatBosluk4.Value), Convert.ToInt32(txtDikBosluk4.Value))));
            }
            if (txtEtiket.Value.ToString() == "5")
            {
                e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"),Convert.ToInt32(txtBaslikYazi.Value), FontStyle.Bold), Brushes.Black, (new Point(Convert.ToInt32(txtUstYaziMesfe.Value), Convert.ToInt32(txtYaziUst1.Value)))); // ÜST  2
                e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), Convert.ToInt32(txtBaslikYazi.Value), FontStyle.Bold), Brushes.Black, (new Point(Convert.ToInt32(txtAltYaziMesfe.Value), Convert.ToInt32(txtYaziAlt1.Value))));
                barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(txtYatBosluk1.Value), Convert.ToInt32(3.5))));
                e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), Convert.ToInt32(txtBaslikYazi.Value), FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(txtUstYaziMesfe.Value), Convert.ToInt32(txtYaziUst2.Value)))); // ÜST 86
                e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), Convert.ToInt32(txtBaslikYazi.Value), FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(txtAltYaziMesfe.Value), Convert.ToInt32(txtYaziAlt2.Value)))); // ALT 153
                barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(txtYatBosluk2.Value), Convert.ToInt32(txtDikBosluk2.Value))));
                e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), Convert.ToInt32(txtBaslikYazi.Value), FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(txtUstYaziMesfe.Value), Convert.ToInt32(txtYaziUst3.Value)))); // ÜST 169
                e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), Convert.ToInt32(txtBaslikYazi.Value), FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(txtAltYaziMesfe.Value), Convert.ToInt32(txtYaziAlt3.Value)))); // ALT 243
                barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(txtYatBosluk3.Value), Convert.ToInt32(txtDikBosluk3.Value))));
                e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), Convert.ToInt32(txtBaslikYazi.Value), FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(txtUstYaziMesfe.Value), Convert.ToInt32(txtYaziUst4.Value)))); // ÜST 248
                e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), Convert.ToInt32(txtBaslikYazi.Value), FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(txtAltYaziMesfe.Value), Convert.ToInt32(txtYaziAlt4.Value))));
                barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(txtYatBosluk4.Value), Convert.ToInt32(txtDikBosluk4.Value))));
                e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), Convert.ToInt32(txtBaslikYazi.Value), FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(txtUstYaziMesfe.Value), Convert.ToInt32(txtYaziUst5.Value)))); // ÜST 248
                e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), Convert.ToInt32(txtBaslikYazi.Value), FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(txtAltYaziMesfe.Value), Convert.ToInt32(txtYaziAlt5.Value))));
                barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(txtYatBosluk5.Value), Convert.ToInt32(txtDikBosluk5.Value))));
            }
            //e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new Point(Convert.ToInt32(3), Convert.ToInt32(12)))); // ÜST  2
            //e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(92)))); // ÜST 86
            //e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(170)))); // ÜST 169
            // e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(250)))); // ÜST 248
            // e.Graphics.DrawString(txtUstYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(328)))); // ÜST 248

            // e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new Point(Convert.ToInt32(3), Convert.ToInt32(78))));
            // e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(155)))); // ALT 153
            // e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(235)))); // ALT 243
            // e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(315))));
            // e.Graphics.DrawString(txtAltYazi.Text, new System.Drawing.Font(new FontFamily("Arial"), 7, FontStyle.Bold), Brushes.Black, (new PointF(Convert.ToInt32(3), Convert.ToInt32(393))));



            // barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(0), Convert.ToInt32(5.5))));
            // barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(0), Convert.ToInt32(25.5))));
            // barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(0), Convert.ToInt32(45.5))));
            // barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(0), Convert.ToInt32(65.5))));
            // barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(0), Convert.ToInt32(85.5))));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           



            //--------------------------------------------------------------------------------------------------------
            ////bu kod barkodun ilk 2 hanesi -ülke kodu
            //barcode.CountryCode = "90";

            ////Bu kod üretici-imalatçı numarası -bu kısımın legal illegal gibi durumları da var
            //barcode.ManufacturerCode = txtNo3.Text + txtNo2.Text;

            ////Bu kod öğrenci -ID si 
            //barcode.ProductCode =  "00" + txtNo1.Text;

            ////Bu kısım boş geçilsede birşey değişmiyor EAN-13 te zaten 12 veri okuyorsunuz ,bu sayı  barkodun sonunda oluyor.
            //barcode.ChecksumDigit = "5";

            //picture1.Image = barcode.CreateBitmap();    

            //------------------------------------------------------------------------------
            //bu kod barkodun ilk 2 hanesi -ülke kodu
            barcode.CountryCode = txtFirmaKodu.Text;

            //Bu kod üretici-imalatçı numarası -bu kısımın legal illegal gibi durumları da var
            barcode.ManufacturerCode = txtModelKodu.Text + txtTuruKodu.Text;

            //Bu kod öğrenci -ID si 
            barcode.ProductCode = txtOlcuKodu.Text + txtRenkKodu.Text; //"00" + 

            //Bu kısım boş geçilsede birşey değişmiyor EAN-13 te zaten 12 veri okuyorsunuz ,bu sayı  barkodun sonunda oluyor.
            barcode.ChecksumDigit = "1";


            picture1.Image = barcode.CreateBitmap();
            txtBarkod.Text = txtFirmaKodu.Text + txtModelKodu.Text + txtTuruKodu.Text + txtOlcuKodu.Text + txtRenkKodu.Text + barcode.ChecksumDigit;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sayi = Convert.ToInt32(txtBarkodSayisi.Text);
            for (int i = 0; i < sayi; i++)
            {

                doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
                //printPreview1.Document = doc;
                //printPreview1.PrintPreviewControl.Zoom = 1.0;
                //printPreview1.ShowDialog();
                doc.Print();
            }
        }



        private void txtNo1_TextChanged(object sender, EventArgs e)
        {

            /////////////
            barcode.CountryCode = txtFirmaKodu.Text;
            barcode.ManufacturerCode = txtModelKodu.Text + txtTuruKodu.Text;
            barcode.ProductCode = txtOlcuKodu.Text + txtRenkKodu.Text;  //"00" +
            // barcode.ManufacturerCode = txtNo1.Text + txtNo2.Text + txtNo3.Text;
            picture1.Image = barcode.CreateBitmap();
            txtBarkod.Text = txtFirmaKodu.Text + txtModelKodu.Text + txtTuruKodu.Text + txtOlcuKodu.Text + txtRenkKodu.Text + barcode.ChecksumDigit;
        }

        private void txtNo2_TextChanged(object sender, EventArgs e)
        {
            barcode.ManufacturerCode = txtModelKodu.Text + txtTuruKodu.Text;
            barcode.ProductCode = txtOlcuKodu.Text + txtRenkKodu.Text;  //"00" +
            picture1.Image = barcode.CreateBitmap();
            txtBarkod.Text = txtFirmaKodu.Text + txtModelKodu.Text + txtTuruKodu.Text + txtOlcuKodu.Text + txtRenkKodu.Text + barcode.ChecksumDigit;
        }

        private void txtNo3_TextChanged(object sender, EventArgs e)
        {
            barcode.ManufacturerCode = txtModelKodu.Text + txtTuruKodu.Text;
            barcode.ProductCode = txtOlcuKodu.Text + txtRenkKodu.Text;  //"00" +
            picture1.Image = barcode.CreateBitmap();
            txtBarkod.Text = txtFirmaKodu.Text + txtModelKodu.Text + txtTuruKodu.Text + txtOlcuKodu.Text + txtRenkKodu.Text + barcode.ChecksumDigit;
        }

        private void txtNo4_TextChanged(object sender, EventArgs e)
        {
            barcode.ProductCode = txtOlcuKodu.Text + txtRenkKodu.Text;  //"00" +
            picture1.Image = barcode.CreateBitmap();
            txtBarkod.Text = txtFirmaKodu.Text + txtModelKodu.Text + txtTuruKodu.Text + txtOlcuKodu.Text + txtRenkKodu.Text + barcode.ChecksumDigit;
        }
        private void txtNo5_TextChanged(object sender, EventArgs e)
        {
            barcode.ProductCode = txtOlcuKodu.Text + txtRenkKodu.Text;  //"00" +
            picture1.Image = barcode.CreateBitmap();
            txtBarkod.Text = txtFirmaKodu.Text + txtModelKodu.Text + txtTuruKodu.Text + txtOlcuKodu.Text + txtRenkKodu.Text + barcode.ChecksumDigit;
        }

        //private void txtNo6_TextChanged(object sender, EventArgs e)
        //{
        //    barcode.ProductCode = txtNo4.Text + txtNo5.Text ;  //"00" +
        //    picture1.Image = barcode.CreateBitmap();
        //    txtBarkod.Text = txtNo1.Text + txtNo2.Text + txtNo3.Text + txtNo4.Text + txtNo5.Text +  barcode.ChecksumDigit;
        //}
        private void button2_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(buttonEdit1.Text) || String.IsNullOrEmpty(btnEdtModel.Text) || String.IsNullOrEmpty(btnEdtTur.Text) || String.IsNullOrEmpty(btnEdtOlcu.Text) | String.IsNullOrEmpty(btnEdtRenk.Text))
            //{
            //    MessageBox.Show("Firma\nModel\nTuru\nÖlçü\nRenk\nAlanlarını Doldurun");
            //    return;
            //}
            List<Control> ctrl = new List<Control>();
            //barcode.ProductCode = Convert.ToString(Convert.ToInt32(txtOlcuKodu.Text + txtRenkKodu.Text ));//+i);  //"00" +
            ctrl.Add(this.txtOlcuKodu);
            ctrl.Add(this.txtRenkKodu);
            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
            printPreviewDialog1.Document = doc;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1.0;
            printPreviewDialog1.ShowDialog();
        }

        private void txtBarkodEni_TextChanged(object sender, EventArgs e)
        {
            barcode._fWidth = Convert.ToInt32(Convert.ToString(txtBarkodEni.Text));
            picture1.Image = barcode.CreateBitmap();
        }

        private void txtBarkodBoy_TextChanged(object sender, EventArgs e)
        {
            barcode._fHeight = Convert.ToInt32(Convert.ToString(txtBarkodBoy.Text));
            picture1.Image = barcode.CreateBitmap();
        }

        private void txtSayiBoy_TextChanged(object sender, EventArgs e)
        {
            barcode._fFontSize = Convert.ToInt32(Convert.ToString(txtSayiBoy.Text));
            picture1.Image = barcode.CreateBitmap();
        }



        private void btnEdtTur_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUrun.Text) || String.IsNullOrEmpty(txtModelKodu.Text))
            {
                MessageBox.Show("Model Seçilmeden Model Seçilemez");
                return;
            }
            txtOlcuKodu.Text = "00";
            txtRenkKodu.Text = "00";
            txtOlcu.Text = String.Empty;
            txtRenk.Text = String.Empty;

            List<Control> cntrl = new List<Control>();
            cntrl.Add(this.txtTuruKodu);
            cntrl.Add(this.txtTuru);
            Turler formTurler = new Turler();
            formTurler.Tag = cntrl;
            formTurler.Show();
        }

        private void btnEdtOlcu_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(txtTuru.Text) || String.IsNullOrEmpty(txtTuruKodu.Text))
            //{
            //    MessageBox.Show("Tur Seçilmeden Ölçü Seçilemez");
            //    return;
            //}

            //txtRenkKodu.Clear();
            //btnEdtRenk.EditValue = String.Empty;

            //List<Control> cntrl = new List<Control>();
            //cntrl.Add(this.txtTuruKodu);
            //cntrl.Add(this.txtOlcuKodu);
            //cntrl.Add(this.btnEdtOlcu);
            //Olculer formOlculer = new Olculer();
            //formOlculer.Tag = cntrl;
            //formOlculer.Show();
        }

        private void btnEdtRenk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtOlcu.Text) || String.IsNullOrEmpty(txtOlcuKodu.Text))
            {
                MessageBox.Show("Ölçü Seçilmeden Model Seçilemez");
                return;
            }
            List<Control> cntrl = new List<Control>();
            cntrl.Add(this.txtRenkKodu);
            cntrl.Add(this.txtRenk);
            Renkler formRenkler = new Renkler();
            formRenkler.Tag = cntrl;
            formRenkler.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 12)
            {
                MessageBox.Show("Barkod 12 Haneli Rakam Olmalı ");
            }
            else
            {
                txtFirmaKodu.Text = textBox1.Text.Substring(0, 3);
                txtModelKodu.Text = textBox1.Text.Substring(3, 3);
                txtTuruKodu.Text = textBox1.Text.Substring(6, 2);
                txtOlcuKodu.Text = textBox1.Text.Substring(8, 2);
                txtRenkKodu.Text = textBox1.Text.Substring(10, 2);

            }
        }

      

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Barkod oluşturma texbox yazı girmeyi engelleme kod
            e.Handled = Char.IsLetter(e.KeyChar);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtFirma.Text) || String.IsNullOrEmpty(txtUrun.Text) || String.IsNullOrEmpty(txtTuru.Text) || String.IsNullOrEmpty(txtOlcu.Text) | String.IsNullOrEmpty(txtRenk.Text))
            {
                MessageBox.Show("Firma\nModel\nTuru\nÖlçü\nRenk\nAlanlarını Doldurun");
                return;
            }
            SqlConnection baglanti = new SqlConnection("Data Source = 192.168.2.254,1433\\server\\SERVER\\SQLEXPRESS;Initial Catalog = OZDILEKMNGSISTEM;User ID =ahmet;Password =123456;");

            SqlCommand cmd = new SqlCommand();
            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = "INSERT INTO BarkodKaydi(Barkod,FirmaAdi,UrunAdi,TuruAdi,OlcuAdi,RenkAdi,Fiyat)VALUES(@Barkod,@FirmaAdi,@UrunAdi,@TuruAdi,@OlcuAdi,@RenkAdi,@Fiyat)";
            cmd.Parameters.AddWithValue("@Barkod", txtBarkod.Text);
            cmd.Parameters.AddWithValue("@FirmaAdi", txtFirma.Text);
            cmd.Parameters.AddWithValue("@UrunAdi", txtUrun.Text);
            cmd.Parameters.AddWithValue("@TuruAdi", txtTuru.Text);
            cmd.Parameters.AddWithValue("@OlcuAdi", txtOlcu.Text);
            cmd.Parameters.AddWithValue("@RenkAdi", txtRenk.Text);
            cmd.Parameters.AddWithValue("@Fiyat", txtFiyat.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt tamamlandı");
        }


        private void btnFirma_Click(object sender, EventArgs e)
        {
            txtModelKodu.Text = "000";
            txtOlcuKodu.Text = "00";
            txtTuruKodu.Text = "00";
            txtRenkKodu.Text = "00";
            txtUrun.Text = String.Empty;
            txtTuru.Text = String.Empty;
            txtOlcu.Text = String.Empty;
            txtRenk.Text = String.Empty;
            List<Control> cntrl = new List<Control>();
            cntrl.Add(this.txtFirmaKodu);
            cntrl.Add(this.txtFirma);
            Firimalar formFrima = new Firimalar();
            formFrima.Tag = cntrl;
            formFrima.Show();
        }

        private void txtFirma_TextChanged(object sender, EventArgs e)
        {
            txtUstYazi.Text = txtFirma.Text;
            lblUst.Text = txtFirma.Text;
        }

        private void btnUrun_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtFirma.Text) || String.IsNullOrEmpty(txtFirmaKodu.Text))
            {
                MessageBox.Show("Firima Seçilmeden Model Seçilemez");
                return;
            }

            txtOlcuKodu.Text = "00";
            txtTuruKodu.Text = "00";
            txtRenkKodu.Text = "00";
            txtTuru.Text = String.Empty;
            txtOlcu.Text = String.Empty;
            txtRenk.Text = String.Empty;

            List<Control> cntrl = new List<Control>();
            cntrl.Add(this.txtFirmaKodu);
            cntrl.Add(this.txtModelKodu);
            cntrl.Add(this.txtUrun);
            Modeller formModeller = new Modeller();
            formModeller.Tag = cntrl;
            formModeller.Show();
        }

        private void btnTuru_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUrun.Text) || String.IsNullOrEmpty(txtModelKodu.Text))
            {
                MessageBox.Show("Model Seçilmeden Model Seçilemez");
                return;
            }
            txtOlcuKodu.Text = "00";
            txtRenkKodu.Text = "00";
            txtOlcu.Text = String.Empty;
            txtRenk.Text = String.Empty;

            List<Control> cntrl = new List<Control>();
            cntrl.Add(this.txtTuruKodu);
            cntrl.Add(this.txtTuru);
            Turler formTurler = new Turler();
            formTurler.Tag = cntrl;
            formTurler.Show();
        }

        private void btnOlcu_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTuru.Text) || String.IsNullOrEmpty(txtTuruKodu.Text))
            {
                MessageBox.Show("Tur Seçilmeden Ölçü Seçilemez");
                return;
            }

            txtRenkKodu.Clear();
            txtRenk.Text = String.Empty;

            List<Control> cntrl = new List<Control>();
            cntrl.Add(this.txtTuruKodu);
            cntrl.Add(this.txtOlcuKodu);
            cntrl.Add(this.txtOlcu);
            Olculer formOlculer = new Olculer();
            formOlculer.Tag = cntrl;
            formOlculer.Show();
        }

        private void btnRenk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtOlcu.Text) || String.IsNullOrEmpty(txtOlcuKodu.Text))
            {
                MessageBox.Show("Ölçü Seçilmeden Model Seçilemez");
                return;
            }
            List<Control> cntrl = new List<Control>();
            cntrl.Add(this.txtRenkKodu);
            cntrl.Add(this.txtRenk);
            Renkler formRenkler = new Renkler();
            formRenkler.Tag = cntrl;
            formRenkler.Show();
        }

        private void txtEtiket_ValueChanged(object sender, EventArgs e)
        {
            if (txtEtiket.Value.ToString()=="1")
            {
                grup1.Visible = true;
                grup2.Visible = false;
                grup3.Visible = false;
                grup4.Visible = false;
                grup5.Visible = false;
            }
            if (txtEtiket.Value.ToString() == "2")
            {
                grup1.Visible = true;
                grup2.Visible = true;
                grup3.Visible = false;
                grup4.Visible = false;
                grup5.Visible = false;
            }
           
            if (txtEtiket.Value.ToString() == "3")
            {
                grup1.Visible = true;
                grup2.Visible = true;
                grup3.Visible = true;
                grup4.Visible = false;
                grup5.Visible = false;
            }
            if (txtEtiket.Value.ToString() == "4")
            {
                grup1.Visible = true;
                grup2.Visible = true;
                grup3.Visible = true;
                grup4.Visible = true;
                grup5.Visible = false;
            }
            if (txtEtiket.Value.ToString() == "5")
            {
                grup1.Visible = true;
                grup2.Visible = true;
                grup3.Visible = true;
                grup4.Visible = true;
                grup5.Visible = true;
            }
            //txtAltYazi.Text = txtUrun.Text;
            //lblAlt.Text = txtUrun.Text;
        }

        private void txtAltYazi_TextChanged(object sender, EventArgs e)
        {
           lblAlt.Text = txtAltYazi.Text;
        }
    }
}

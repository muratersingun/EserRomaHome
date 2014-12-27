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
    public partial class AlisForm : Form
    {
        public AlisForm()
        {
            InitializeComponent();
        }


        DataTable datatable1 = new DataTable();
        DataTable datatable3 = new DataTable();
        DataTable tablom1 = new DataTable();
        DataTable tablom = new DataTable();
        int sayi = 1;
        Urun urun = new Urun();

        private void txtBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                if (txtBarkod.Text != "")
                {
                    txtBarkod.Focus();
                    bool varmi = false;

                    if (dataGridView1.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (Convert.ToString(row.Cells[1].Value) == txtBarkod.Text)
                            {
                                int al = Convert.ToInt32(row.Cells[7].Value = Convert.ToString(sayi + Convert.ToInt16(row.Cells[7].Value))); //ek
                                varmi = true;
                                MiktarArtir(al);
                                Topla();
                            }
                        }
                        if (!varmi)
                        {
                            sayi = 1;

                            TablodanVeriCek(sayi);
                            Topla();
                        }
                    }
                    else
                    {
                        sayi = 1;
                        TablodanVeriCek(sayi);
                        Topla();

                    }
                }
                txtBarkod.Text = "";
            }
        }

        private void AlisForm_Load(object sender, EventArgs e)
        {
            urun.GetAllUrun();
        }
        public void TablodanVeriCek(int miktar)
        {
           
                tablom1 = urun.GetAllUrun();
                DataRow[] sat = tablom1.Select("Barkod=" + txtBarkod.Text);

                DataRow satir = tablom.NewRow();
                if (tablom.Columns["ID"] == null)
                {
                    tablom.Columns.Add("ID", Type.GetType("System.String"));
                    tablom.Columns.Add("Barkod", Type.GetType("System.String"));
                    tablom.Columns.Add("FirmaAdi", Type.GetType("System.String"));
                    tablom.Columns.Add("UrunAdi", Type.GetType("System.String"));
                    tablom.Columns.Add("TuruAdi", Type.GetType("System.String"));
                    tablom.Columns.Add("OlcuAdi", Type.GetType("System.String"));
                    tablom.Columns.Add("RenkAdi", Type.GetType("System.String"));
                    tablom.Columns.Add("Miktar", Type.GetType("System.String"));
                    tablom.Columns.Add("Fiyat", Type.GetType("System.String"));
                    tablom.Columns.Add("Total", Type.GetType("System.String"));
                }
                // string ıd = Convert.ToString(sat[0].ItemArray[0].ToString());
                string ID = sat[0].ItemArray[0].ToString();
                string Barkod = sat[0].ItemArray[1].ToString();
                string FirmaAdi = sat[0].ItemArray[2].ToString();
                string UrunAdi = sat[0].ItemArray[3].ToString();
                string TuruAdi = sat[0].ItemArray[4].ToString();
                string OlcuAdi = sat[0].ItemArray[5].ToString();
                string RenkAdi = sat[0].ItemArray[6].ToString();
                string Fiyat = sat[0].ItemArray[7].ToString();

                int Miktar = miktar;
                decimal total = Convert.ToDecimal(Fiyat) * Miktar;
                tablom.Rows.Add(ID, Barkod, FirmaAdi, UrunAdi, TuruAdi, OlcuAdi, RenkAdi, Miktar, Fiyat, total);


                DataRow satir1 = tablom.Rows[0];
                datatable1.ImportRow(satir1);


                datatable3 = tablom.Clone();
                for (int i = tablom.Rows.Count - 1; i >= 0; i--)
                {
                    datatable3.ImportRow(tablom.Rows[i]);
                }
                dataGridView1.DataSource = datatable3;
                Gritkolon();
          

        }
        public void MiktarArtir(int miktar)
        {
            DataRow[] sat = tablom.Select("Barkod =" + txtBarkod.Text);
            sat[0]["Miktar"] = miktar;
            int Miktar = Convert.ToInt32(sat[0]["Miktar"]);
            decimal Fiyat = Convert.ToInt32(sat[0]["Fiyat"]);
            decimal total = Miktar * Fiyat;
            sat[0]["Total"] = total;

            dataGridView1.DataSource = tablom;
            DataRow satir = tablom.Rows[0];
            datatable1.ImportRow(satir);

            dataGridView1.DataSource = datatable1;
            //DataTable table = new DataTable();
            datatable3 = tablom.Clone();
            for (int i = tablom.Rows.Count - 1; i >= 0; i--)
            {
                datatable3.ImportRow(tablom.Rows[i]);
            }
            dataGridView1.DataSource = datatable3;
            Gritkolon();
        }
        public void Gritkolon()
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.Columns[9].ReadOnly = true;
        }
        //public void Kadet()
        //{
        //    SqlConnection baglanti = new SqlConnection("Data Source=BILGISAYAR\\SQLSERVER2012; Initial Catalog=MYData; Integrated Security=true");
        //    // for ile dataGridView1 veri tabanına kadetme
        //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //    {
        //        using (SqlCommand com = new SqlCommand("INSERT INTO BarkodKaydi VALUES(@Barkod,@FirmaAdi,@UrunAdi,@TuruAdi,@OlcuAdi,@RenkAdi,@Miktar,@Fiyat,@Toplam,@ParaBirimi,@Kur,@TLTotal)", baglanti))
        //        {
        //            com.Parameters.AddWithValue("@Barkod", dataGridView1.Rows[i].Cells[0].Value);
        //            com.Parameters.AddWithValue("@FirmaAdi", dataGridView1.Rows[i].Cells[1].Value);
        //            com.Parameters.AddWithValue("@UrunAdi", dataGridView1.Rows[i].Cells[2].Value);
        //            com.Parameters.AddWithValue("@TuruAdi", dataGridView1.Rows[i].Cells[3].Value);
        //            com.Parameters.AddWithValue("@OlcuAdi", dataGridView1.Rows[i].Cells[4].Value);
        //            com.Parameters.AddWithValue("@RenkAdi", dataGridView1.Rows[i].Cells[5].Value);
        //            com.Parameters.AddWithValue("@Miktar", dataGridView1.Rows[i].Cells[6].Value);
        //            com.Parameters.AddWithValue("@Fiyat", dataGridView1.Rows[i].Cells[7].Value);
        //            com.Parameters.AddWithValue("@Toplam", dataGridView1.Rows[i].Cells[8].Value);
        //            baglanti.Open();
        //            com.ExecuteNonQuery();
        //        }
        //        baglanti.Close();
        //    }
        //}
        public void MiktarArtir2(int Kolon, int Satir, string deger, string sam)
        {
            DataRow[] sat = tablom.Select("Barkod =" + sam);
            sat[0][Kolon] = deger;
            //sat[0]["Fiyat"] = fiyat;
            int Miktar = Convert.ToInt32(sat[0]["Miktar"]);
            decimal Fiyat = Convert.ToDecimal(sat[0]["Fiyat"]);
            decimal total = Miktar * Fiyat;
            sat[0]["Total"] = total;

            dataGridView1.DataSource = tablom;
            DataRow satir = tablom.Rows[0];
            datatable1.ImportRow(satir);
            dataGridView1.DataSource = datatable1;
            DataTable table = new DataTable();
            datatable3 = tablom.Clone();
            for (int i = tablom.Rows.Count - 1; i >= 0; i--)
            {
                datatable3.ImportRow(tablom.Rows[i]);
            }
            dataGridView1.DataSource = datatable3;
            Gritkolon();
        }
        public void Topla()
        {
            decimal toplam = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                toplam = toplam + Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
            txtToplam.Text = Convert.ToString(toplam);
        }
        public void sil(string deger)
        {
            for (int i = 0; i < datatable3.Rows.Count; i++)
            {
                if (datatable3.Rows[i]["Barkod"].ToString() == deger)
                {
                    datatable3.Rows[i].Delete();
                    break;
                }
            }
            for (int i = 0; i < tablom.Rows.Count; i++)
            {
                if (tablom.Rows[i]["Barkod"].ToString() == deger)
                {
                    tablom.Rows[i].Delete();
                    break;
                }
            }
            datatable3 = tablom.Clone();
            for (int i = tablom.Rows.Count - 1; i >= 0; i--)
            {
                datatable3.ImportRow(tablom.Rows[i]);
            }
            dataGridView1.DataSource = datatable3;
            Gritkolon();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            string Satiriçindeki = "";
            int Kolon = dataGridView1.CurrentCellAddress.X;
            int Satir = dataGridView1.CurrentCellAddress.Y;
            Satiriçindeki = dataGridView1.Rows[Satir].Cells[Kolon].Value.ToString();
            string sa = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            MiktarArtir2(Kolon, Satir, Satiriçindeki, sa);
            Topla();
            txtBarkod.Focus();
        }

        private void txtSil_Click(object sender, EventArgs e)
        {
            string deger = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            sil(deger);
            Topla();
            txtBarkod.Focus();
        }
    }
}

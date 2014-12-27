using DALC4NET;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EserRomeHomeBussines
{
    public class Renk
    {
        public string RenkKodu { get; set; }
        public string RenkAdi { get; set; }

        public static List<Renk> GetAllRenk()
        {
            List<Renk> AllRenk = new List<Renk>();
            DBHelper baglan = new DBHelper();
            SqlConnection con = new SqlConnection(baglan.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select RenkKodu,RenkAdi From Renkler ORDER BY RenkKodu ASC", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                AllRenk.Add(new Renk
                {
                    RenkKodu = dr.GetString(0),
                    RenkAdi = dr.GetString(1)
                });
            }
            dr.Close();
            con.Close();
            return AllRenk;
        }

        public static Boolean Kaydet(Renk pRenk)
        {
            DBHelper baglan = new DBHelper();
            try
            {
                SqlConnection con = new SqlConnection(baglan.ConnectionString);
                string NewRenkNumber = GetNewRenkNumber();
                SqlCommand cmd = new SqlCommand("INSERT INTO Renkler(RenkKodu,RenkAdi) VALUES(@RenkKodu,@RenkAdi)", con);
                cmd.Parameters.AddWithValue("@RenkKodu", NewRenkNumber);
                cmd.Parameters.AddWithValue("@RenkAdi", pRenk.RenkAdi);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }

        }

        public static Boolean Update(Renk pRenk)
        {
            DBHelper baglan = new DBHelper();
            try
            {
                SqlConnection con = new SqlConnection(baglan.ConnectionString);
                SqlCommand cmd = new SqlCommand("UPDATE Renkler SET RenkAdi=@RenkAdi Where RenkKodu=@RenkKodu", con);
                cmd.Parameters.AddWithValue("@RenkKodu", pRenk.RenkKodu);
                cmd.Parameters.AddWithValue("@RenkAdi", pRenk.RenkAdi);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }

        }

        public static Boolean Delete(Renk pRenk)
        {
            DBHelper baglan = new DBHelper();
            try
            {
                SqlConnection con = new SqlConnection(baglan.ConnectionString);
                SqlCommand cmd = new SqlCommand("DELETE FROM Renkler Where RenkKodu=@RenkKodu", con);
                cmd.Parameters.AddWithValue("@RenkKodu", pRenk.RenkKodu);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }

        }


        private static string GetNewRenkNumber()
        {
            List<Renk> AllRenk = Renk.GetAllRenk();
            if (AllRenk == null || AllRenk.Count == 0)
            {
                return "01";
            }

            List<int> TmpRenkCode = new List<int>();
            foreach (Renk item in AllRenk)
            {
                TmpRenkCode.Add(Convert.ToInt32(item.RenkKodu));
            }

            TmpRenkCode.Sort();
            if (TmpRenkCode[0] != 1)
            {
                return (1.ToString().PadLeft(2, '0'));
            }
            for (int i = 0; i < TmpRenkCode.Count - 1; i++)
            {
                if ((TmpRenkCode[i] + 1) != TmpRenkCode[i + 1])
                {
                    return (TmpRenkCode[i] + 1).ToString().PadLeft(2, '0');
                }
            }

            return (TmpRenkCode[TmpRenkCode.Count - 1] + 1).ToString().PadLeft(2, '0');
        }

    }
}

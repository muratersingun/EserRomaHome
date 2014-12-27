using DALC4NET;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EserRomeHomeBussines
{
    public class Tur
    {
        public string TurKodu { get; set; }
        public string TurAdi { get; set; }

        public static List<Tur> GetAllTur()
        {
            List<Tur> AllTur = new List<Tur>();
            DBHelper baglan = new DBHelper();
            SqlConnection con = new SqlConnection(baglan.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select TurKodu,TurAdi From Turler ORDER BY TurKodu ASC", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                AllTur.Add(new Tur
                {
                    TurKodu = dr.GetString(0),
                    TurAdi = dr.GetString(1)
                });
            }
            dr.Close();
            con.Close();
            return AllTur;
        }

        public static Boolean Kaydet(Tur pTur)
        {
            DBHelper baglan = new DBHelper();
            try
            {
                SqlConnection con = new SqlConnection(baglan.ConnectionString);
                string NewTurNumber = GetNewTurNumber();
                SqlCommand cmd = new SqlCommand("INSERT INTO Turler(TurKodu,TurAdi) VALUES(@TurKodu,@TurAdi)", con);
                cmd.Parameters.AddWithValue("@TurKodu", NewTurNumber);
                cmd.Parameters.AddWithValue("@TurAdi", pTur.TurAdi);
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

        public static Boolean Update(Tur pTur)
        {
            DBHelper baglan = new DBHelper();
            try
            {
                SqlConnection con = new SqlConnection(baglan.ConnectionString);
                SqlCommand cmd = new SqlCommand("UPDATE Turler SET TurAdi=@TurAdi Where TurKodu=@TurKodu", con);
                cmd.Parameters.AddWithValue("@TurKodu", pTur.TurKodu);
                cmd.Parameters.AddWithValue("@TurAdi", pTur.TurAdi);
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

        public static Boolean Delete(Tur pTur)
        {
            DBHelper baglan = new DBHelper();
            try
            {
                SqlConnection con = new SqlConnection(baglan.ConnectionString);
                SqlCommand cmd = new SqlCommand("DELETE FROM Turler Where TurKodu=@TurKodu", con);
                cmd.Parameters.AddWithValue("@TurKodu", pTur.TurKodu);
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


        private static string GetNewTurNumber()
        {
            List<Tur> AllTur = Tur.GetAllTur();
            if (AllTur == null || AllTur.Count == 0)
            {
                return "01";
            }

            List<int> TmpTurCode = new List<int>();
            foreach (Tur item in AllTur)
            {
                TmpTurCode.Add(Convert.ToInt32(item.TurKodu));
            }

            TmpTurCode.Sort();
            if (TmpTurCode[0] != 1)
            {
                return (1.ToString().PadLeft(2, '0'));
            }
            for (int i = 0; i < TmpTurCode.Count - 1; i++)
            {
                if ((TmpTurCode[i] + 1) != TmpTurCode[i + 1])
                {
                    return (TmpTurCode[i] + 1).ToString().PadLeft(2, '0');
                }
            }

            return (TmpTurCode[TmpTurCode.Count - 1] + 1).ToString().PadLeft(2, '0');
        }

    }
}

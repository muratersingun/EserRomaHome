using DALC4NET;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EserRomeHomeBussines
{
    public class Olcu
    {
        public string TurKodu { get; set; }
        public string OlcuKodu { get; set; }
        public string OlcuAdi { get; set; }

        public static List<Olcu> GetAllOlcuOfTur(string pTurKodu)
        {
            List<Olcu> AllOlcuOfTur = new List<Olcu>();
            DBHelper baglan = new DBHelper();
            SqlConnection con = new SqlConnection(baglan.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select OlcuKodu,OlcuAdi,TurKodu From Olculer Where TurKodu = @TurKodu", con);
            cmd.Parameters.AddWithValue("@TurKodu", pTurKodu);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                AllOlcuOfTur.Add(new Olcu
                {
                    OlcuKodu = dr.GetString(0),
                    OlcuAdi = dr.GetString(1),
                    TurKodu = dr.GetString(2)
                });
            }
            dr.Close();
            con.Close();
            return AllOlcuOfTur;
        }

        public static Boolean Kaydet(Olcu pOlcu)
        {
            DBHelper baglan = new DBHelper();
            try
            {
                string NewOlcuNumber = GetNewOlcuNumber(pOlcu.TurKodu);
                SqlConnection con = new SqlConnection(baglan.ConnectionString);
                SqlCommand cmd = new SqlCommand("INSERT INTO Olculer(TurKodu,OlcuKodu,OlcuAdi) VALUES(@TurKodu,@OlcuKodu,@OlcuAdi)", con);
                cmd.Parameters.AddWithValue("@TurKodu", pOlcu.TurKodu);
                cmd.Parameters.AddWithValue("@OlcuKodu", NewOlcuNumber);
                cmd.Parameters.AddWithValue("@OlcuAdi", pOlcu.OlcuAdi);
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

        public static Boolean Update(Olcu pOlcu)
        {
            DBHelper baglan = new DBHelper();
            try
            {
                SqlConnection con = new SqlConnection(baglan.ConnectionString);
                SqlCommand cmd = new SqlCommand("UPDATE Olculer SET OlcuAdi=@OlcuAdi Where OlcuKodu=@OlcuKodu AND TurKodu = @TurKodu", con);
                cmd.Parameters.AddWithValue("@TurKodu", pOlcu.TurKodu);
                cmd.Parameters.AddWithValue("@OlcuKodu", pOlcu.OlcuKodu);
                cmd.Parameters.AddWithValue("@OlcuAdi", pOlcu.OlcuAdi);
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

        public static Boolean Delete(Olcu pOlcu)
        {
            DBHelper baglan = new DBHelper();
            try
            {
                SqlConnection con = new SqlConnection(baglan.ConnectionString);
                SqlCommand cmd = new SqlCommand("DELETE FROM Olculer Where OlcuKodu=@OlcuKodu AND TurKodu = @TurKodu", con);
                cmd.Parameters.AddWithValue("@TurKodu", pOlcu.TurKodu);
                cmd.Parameters.AddWithValue("@OlcuKodu", pOlcu.OlcuKodu);
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


        private static string GetNewOlcuNumber(string pFrimaCode)
        {
            List<Olcu> AllOlcuOfFrima = Olcu.GetAllOlcuOfTur(pFrimaCode);
            if (AllOlcuOfFrima == null || AllOlcuOfFrima.Count == 0)
            {
                return "01";
            }

            List<int> TmpFrimaCode = new List<int>();
            foreach (Olcu item in AllOlcuOfFrima)
            {
                TmpFrimaCode.Add(Convert.ToInt32(item.OlcuKodu));
            }

            TmpFrimaCode.Sort();
            for (int i = 0; i < TmpFrimaCode.Count - 1; i++)
            {
                if ((TmpFrimaCode[i] + 1) != TmpFrimaCode[i + 1])
                {
                    return (TmpFrimaCode[i] + 1).ToString().PadLeft(2, '0');
                }
            }

            return (TmpFrimaCode[TmpFrimaCode.Count - 1] + 1).ToString().PadLeft(2, '0');
        }
    }
}

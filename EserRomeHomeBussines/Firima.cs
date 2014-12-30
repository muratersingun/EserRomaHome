using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using DALC4NET;

namespace EserRomeHomeBussines
{
    public class Firima
    {
        public string FrimaKodu { get; set; }
        public string FrimaAdi { get; set; }

        public static List<Firima> GetAllFrima()
        {
            List<Firima> AllFrima = new List<Firima>();
            DBHelper baglan = new DBHelper();
            SqlConnection con = new SqlConnection(baglan.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select firima_kodu,firima_adi From firmalar ORDER BY firima_kodu ASC", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())       
            {
                AllFrima.Add(new Firima
                {
                    FrimaKodu = dr.GetString(0),
                    FrimaAdi = dr.GetString(1)
                });
            }
            dr.Close();
            con.Close();
            return AllFrima;
        }

        public static Boolean Kaydet(Firima pFrima)
        {
            DBHelper baglan = new DBHelper();
            try
            {
                SqlConnection con = new SqlConnection(baglan.ConnectionString);
                string NewFirimaNumber = GetNewFirimaNumber();
                SqlCommand cmd = new SqlCommand("INSERT INTO firmalar(firima_kodu,firima_adi) VALUES(@FrimaKodu,@FrimaAdi)", con);
                cmd.Parameters.AddWithValue("@FrimaKodu",NewFirimaNumber);
                cmd.Parameters.AddWithValue("@FrimaAdi",pFrima.FrimaAdi);
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

        public static Boolean Update(Firima pFrima)
        {
            DBHelper baglan = new DBHelper();
            try
            {
                SqlConnection con = new SqlConnection(baglan.ConnectionString);
                SqlCommand cmd = new SqlCommand("UPDATE firmalar SET firima_adi=@FrimaAdi Where firima_kodu=@FrimaKodu", con);
                cmd.Parameters.AddWithValue("@FrimaKodu", pFrima.FrimaKodu);
                cmd.Parameters.AddWithValue("@FrimaAdi", pFrima.FrimaAdi);
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

        public static Boolean Delete(Firima pFrima)
        {
            DBHelper baglan = new DBHelper();
            try
            {
                SqlConnection con = new SqlConnection(baglan.ConnectionString);
                SqlCommand cmd = new SqlCommand("DELETE FROM firmalar Where firima_kodu=@FrimaKodu", con);
                cmd.Parameters.AddWithValue("@FrimaKodu", pFrima.FrimaKodu);
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


        private static string GetNewFirimaNumber()
        {
            List<Firima> AllFirimaOfFrima = Firima.GetAllFrima();
            if (AllFirimaOfFrima == null || AllFirimaOfFrima.Count == 0)
            {
                return "101";
            }

            List<int> TmpFrimaCode = new List<int>();
            foreach (Firima item in AllFirimaOfFrima)
            {
                TmpFrimaCode.Add(Convert.ToInt32(item.FrimaKodu));
            }

            TmpFrimaCode.Sort();
            if (TmpFrimaCode[0] != 1)
            {
                //return (1.ToString().PadLeft(3, '0'));
                return (TmpFrimaCode[TmpFrimaCode.Count - 1] + 1).ToString().PadLeft(3, '0');
            }
            for (int i = 0; i < TmpFrimaCode.Count - 1; i++)
            {
                if ((TmpFrimaCode[i] + 1) != TmpFrimaCode[i + 1])
                {
                   // return (TmpFrimaCode[i] + 1).ToString().PadLeft(3, '0');
                    return (TmpFrimaCode[TmpFrimaCode.Count - 1] + 1).ToString().PadLeft(3, '0');
                }
            }

            return (TmpFrimaCode[TmpFrimaCode.Count - 1] + 1).ToString().PadLeft(3, '0');
        }
    }
}

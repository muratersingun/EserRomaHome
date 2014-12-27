using DALC4NET;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EserRomeHomeBussines
{
    public class Model
    {
        public string FrimaKodu { get; set; }
        public string ModelKodu { get; set; }
        public string ModelAdi { get; set; }

        public static List<Model> GetAllModelofFirima(string pFrimaKodu)
        {
            List<Model> AllModelOfFirima = new List<Model>();
            DBHelper baglan = new DBHelper();
            SqlConnection con = new SqlConnection(baglan.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select ModelKodu,ModelAdi,FrimaKodu From Modeller Where FrimaKodu = @FrimaKodu", con);
            cmd.Parameters.AddWithValue("@FrimaKodu", pFrimaKodu);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                AllModelOfFirima.Add(new Model
                {
                    ModelKodu = dr.GetString(0),
                    ModelAdi = dr.GetString(1),     
                    FrimaKodu = dr.GetString(2)
                });
            }
            dr.Close();
            con.Close();
            return AllModelOfFirima;
        }

        public static Boolean Kaydet(Model pModel)
        {
            DBHelper baglan = new DBHelper();
            try
            {
                string NewModelNumber = GetNewModelNumber(pModel.FrimaKodu);
                SqlConnection con = new SqlConnection(baglan.ConnectionString);
                SqlCommand cmd = new SqlCommand("INSERT INTO Modeller(FrimaKodu,ModelKodu,ModelAdi) VALUES(@FrimaKodu,@ModelKodu,@ModelAdi)", con);
                cmd.Parameters.AddWithValue("@FrimaKodu", pModel.FrimaKodu);
                cmd.Parameters.AddWithValue("@ModelKodu", NewModelNumber);
                cmd.Parameters.AddWithValue("@ModelAdi", pModel.ModelAdi);
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

        public static Boolean Update(Model pModel)
        {
            DBHelper baglan = new DBHelper();
            try
            {
                SqlConnection con = new SqlConnection(baglan.ConnectionString);
                SqlCommand cmd = new SqlCommand("UPDATE Modeller SET ModelAdi=@ModelAdi Where ModelKodu=@ModelKodu AND FrimaKodu = @FrimaKodu", con);
                cmd.Parameters.AddWithValue("@FrimaKodu", pModel.FrimaKodu);
                cmd.Parameters.AddWithValue("@ModelKodu", pModel.ModelKodu);
                cmd.Parameters.AddWithValue("@ModelAdi", pModel.ModelAdi);
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

        public static Boolean Delete(Model pModel)
        {
            DBHelper baglan = new DBHelper();
            try
            {
                SqlConnection con = new SqlConnection(baglan.ConnectionString);
                SqlCommand cmd = new SqlCommand("DELETE FROM Modeller Where ModelKodu=@ModelKodu AND FrimaKodu = @FrimaKodu", con);
                cmd.Parameters.AddWithValue("@FrimaKodu", pModel.FrimaKodu);
                cmd.Parameters.AddWithValue("@ModelKodu", pModel.ModelKodu);
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


        private static string GetNewModelNumber(string pFrimaCode)
        {
            List<Model> AllModelOfFrima = Model.GetAllModelofFirima(pFrimaCode);
            if (AllModelOfFrima == null || AllModelOfFrima.Count == 0 )
            {
                return "001";
            }

            List<int> TmpFrimaCode = new List<int>();
            foreach (Model item in AllModelOfFrima)
            {
                TmpFrimaCode.Add(Convert.ToInt32(item.ModelKodu));
            }

            TmpFrimaCode.Sort();
            for (int i = 0; i < TmpFrimaCode.Count-1; i++)
            {
                if ((TmpFrimaCode[i] +1) != TmpFrimaCode[i+1])
                {
                    return (TmpFrimaCode[i] + 1).ToString().PadLeft(3, '0');
                }
            }

            return (TmpFrimaCode[TmpFrimaCode.Count - 1] + 1).ToString().PadLeft(3, '0');
        }
    }
}

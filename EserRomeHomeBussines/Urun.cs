using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALC4NET;
using System.Data;

namespace EserRomeHomeBussines
{
    public class Urun
    {
        public int ID { get; set; }
        public int Barkod { get; set; }
        public string FirmaAdi { get; set;}
        public string UrunAdi { get; set; }
        public string TuruAdi { get; set; }
        public string OlcuAdi { get; set; }
        public string RenkAdi { get; set; }
        public int Fiyat { get; set; }



        public DataTable GetAllUrun()
        {
            DBHelper baglan = new DBHelper();

            return baglan.ExecuteDataTable("Select * From BarkodKaydi");            
        }

        public DataTable GetUrunByBarkod(Urun pUrun)
        {
            DBHelper baglan = new DBHelper();
            return baglan.ExecuteDataTable("Select * From BarkodKaydi where Barkod = @Barkod",new DBParameter("@Barkod",pUrun.Barkod));
        }
    }
}

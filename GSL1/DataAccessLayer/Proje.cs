using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Proje
    {
        public int ID { get; set; }
        public int BolumID { get; set; }
        public string Bolum { get; set; }
        public int KategoriID { get; set; }
        public string Kategori { get; set; }
        public int YazarID { get; set; }
        public string Ogrennci { get; set; }
        public int SehirID { get; set; }
        public string Sehir { get; set; }
        public int OkulID { get; set; }
        public string Okul { get; set; }
        public string Baslik { get; set; }
        public string Ozet { get; set; }
        public string BaTarih { get; set; }
        public string BiTarih { get; set; }
        public string KapakResim { get; set; }
        public string Sart { get; set; }
        public string Icerik { get; set; }
        public string Katilimcilar { get; set; }
        public string iletisim { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public bool Durum { get; set; }

    }
}

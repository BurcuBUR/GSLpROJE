using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Ogrenci
    {
        public int ID { get; set; }
        public int KategoriID { get; set; }
        public int BolumID { get; set; }
        public string bolum { get; set; }
        public int OkullID { get; set; }
        public string okul { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string nickname { get; set; }
        public string mail { get; set; }
        public string sifre { get; set; }
        public DateTime uyelikTarihi { get; set; }
        public bool Durum { get; set; }
    }
}

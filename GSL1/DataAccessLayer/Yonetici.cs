using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Yonetici
    {
        public int ID { get; set; }
        public int YoneticiTurID { get; set; }
        public string ad { get; set; }
        public  string soyad { get; set; }
        public string  mail { get; set; }
        public string sifre { get; set; }
        public bool Durum { get; set; }


    }
}

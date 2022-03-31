using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Yorum
    {
        public int ID { get; set; }
        public int OgrenciID { get; set; }
        public string nickname { get; set; }
        public string Baslik { get; set; }
        public int ProjeID { get; set; }
        public string Icerik { get; set; }
        public DateTime YorumTarih { get; set; }
        public bool OnayDurum { get; set; }

    }
}

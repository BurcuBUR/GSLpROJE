using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Okul
    {
        public int ID { get; set; }
        public string isim { get; set; }
        public int BolumID { get; set; }
        public int SehirID { get; set; }
    }
}

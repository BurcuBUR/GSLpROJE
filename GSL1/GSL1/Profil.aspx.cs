using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSL1
{
    public partial class Profil : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uye"] != null)
            {
                Ogrenci o = (Ogrenci)Session["uye"];
                lbl_kullanici.Text = o.ad + " " + o.soyad;
            }
            else
            {
                Response.Redirect("Giris.aspx");
            }
        }

        protected void lbtn_degistir_Click(object sender, EventArgs e)
        {
            Session["uye"] = null;
            Response.Redirect("uyeGiris.aspx");
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["uye"] = null;
            Response.Redirect("uyeGiris.aspx");
        }
    }
}
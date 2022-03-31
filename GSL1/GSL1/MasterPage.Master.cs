using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSL1
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_kategoriler.DataSource = dm.KategoriListele();
            rp_kategoriler.DataBind();

            if (Session["uye"] != null)
            {
                Ogrenci o = (Ogrenci)Session["uye"];
                pnlGirisVar.Visible = true;
                lbl_uye.Text = o.nickname;
                pnl_girisyok.Visible = false;
            }
            else
            {
                pnlGirisVar.Visible = false;
                pnl_girisyok.Visible = true;
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["uye"] = null;
            Response.Redirect("Default.aspx");
        }


        protected void lbtn_profil_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Profil.aspx");
        }
    }
}
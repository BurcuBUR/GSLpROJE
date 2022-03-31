using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSL1.Yonetici
{
    public partial class YoneticiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yonetici"] != null)
            {
                DataAccessLayer.Yonetici yon = (DataAccessLayer.Yonetici)Session["yonetici"];
                lbl_kullanici.Text = yon.ad + " " + yon.soyad;
            }
            else
            {
                Response.Redirect("Giris.aspx");
            }

        }

        protected void lbtn_CikisYap_Click(object sender, EventArgs e)
        {
            pnl_cikis.Visible = true;
        }

        protected void lbtn_evet_Click(object sender, EventArgs e)
        {
            Session["yonetici"] = null;
            Response.Redirect("Giris.aspx");
        }

        protected void lbtn_hayir_Click(object sender, EventArgs e)
        {
            pnl_cikis.Visible = false;
        }
    }
}
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSL1.Yonetici
{
    public partial class SehirGuncelle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count != 0)
                {
                    int id = Convert.ToInt32(Request.QueryString["sid"]);
                    Sehir s = dm.SehirGetir(id);

                    tb_ID.Text = s.ID.ToString();
                    tb_ad.Text = s.AD;
                }
                else
                {
                    Response.Redirect("SehirListele.aspx");
                }
            }

        }

        protected void lbtn_update_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["sid"]);
            DataAccessLayer.Sehir s = dm.SehirGetir(id);
            s.AD = tb_ad.Text;

            if (dm.SehirGuncelle(s))
            {
                pnl_basarili.Visible = true;
                pnl_basarisiz.Visible = false;
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Güncelleme işlemi sırasıda bir hata oluştu :/";
            }
        }
    }
}
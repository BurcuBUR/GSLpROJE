using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSL1.Yonetici
{
    public partial class OkulGuncelle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count != 0)
                {
                    int id = Convert.ToInt32(Request.QueryString["oid"]);
                    Okul o = dm.OkulGetir(id);

                    tb_ID.Text = o.ID.ToString();
                    tb_ad.Text = o.isim;  
                }
                else
                {
                    Response.Redirect("OkulListele.aspx");
                }
            }
        }


        protected void lbtn_update_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["oid"]);
            Okul o = dm.OkulGetir(id);
            o.isim = tb_ad.Text;

            if (dm.OkulGuncelle(o))
            {
                pnl_basarili.Visible = true;
                pnl_basarisiz.Visible = false;
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Güncelleme İşlemi Sırasında Hata Oluştu";
            }
        }
    }
}
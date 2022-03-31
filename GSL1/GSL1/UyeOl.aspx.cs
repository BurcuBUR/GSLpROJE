using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSL1
{
    public partial class UyeOl : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_bolumler.DataSource = dm.BolumListele();
                ddl_bolumler.DataBind();
                ddl_okullar.DataSource = dm.OkulListele();
                ddl_okullar.DataBind();
                
            }
        }

        protected void btn_kayit_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(tb_mail.Text) && !string.IsNullOrEmpty(tb_sifre.Text))
            {
                Ogrenci o = new Ogrenci();
                o.BolumID = Convert.ToInt32(ddl_bolumler.SelectedValue);
                o.OkullID = Convert.ToInt32(ddl_okullar.SelectedValue);
                o.ad = tb_ad.Text;
                o.soyad = tb_soyad.Text;
                o.nickname = tb_nick.Text;
                o.mail = tb_mail.Text;
                o.sifre = tb_sifre.Text;
                o.uyelikTarihi = DateTime.Now;

                if (dm.UyeOl(o))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Kayıt sırasında bir hata oluştu :(";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Lütfen boş alan bırakmayınız :)";
            }
        }
    }
}
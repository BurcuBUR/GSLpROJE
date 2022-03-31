using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSL1
{
    public partial class ProjeDevami : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["pid"]);
                Proje p = dm.ProjeGetir(id);
                ltrl_baslik.Text = p.Baslik;
                ltrl_icerik.Text = p.Icerik;
                ltrl_kategori.Text = p.Kategori;
                ltrl_ogrenci.Text = p.Ogrennci;
                ltrl_bolum.Text = p.Bolum;
                ltrl_okul.Text = p.Okul;
                ltrl_sart.Text = p.Sart;
                ltrl_sehir.Text = p.Sart;
                ltrl_katılımcı.Text = p.Katilimcilar;
                ltrl_iletisim.Text = p.iletisim;
                img_resim.ImageUrl = "ProjeResimleri/" + p.KapakResim;
                if (Session["uye"] != null)
                {
                    pnl_girisVar.Visible = true;
                    pnl_girisyok.Visible = false;
                }
                else
                {
                    pnl_girisVar.Visible = false;
                    pnl_girisyok.Visible = true;
                }
                rp_yorumlar.DataSource = dm.YorumListele(id);
                rp_yorumlar.DataBind();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void lbtn_yorumYap_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["pid"]);
            Yorum y = new Yorum();
            y.ProjeID = id;
            y.OgrenciID = ((Ogrenci)Session["uye"]).ID;
            y.Icerik = tb_yorum.Text;
            y.YorumTarih = DateTime.Now;
            y.OnayDurum = false;

            if (dm.YorumEkle(y))
            {
                Response.Write("<script>alert('Yorumunuz onay sonrasında yayınlanacaktır')</script>");
            }
            else
            {

                Response.Write("<script>alert('Bir Hata Oluştu')</script>");
            } 
        }
    }
}
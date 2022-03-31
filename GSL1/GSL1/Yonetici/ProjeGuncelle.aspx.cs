using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSL1.Yonetici
{
    public partial class ProjeGuncelle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_sehirler.DataSource = dm.SehirListele();
                ddl_okullar.DataSource = dm.OkulListele();
                ddl_kategoriler.DataSource = dm.KategoriListele();
                int id = Convert.ToInt32(Request.QueryString["pid"]);
                Proje p = dm.ProjeGetir(id);
                ddl_kategoriler.SelectedValue = Convert.ToString(p.KategoriID);
                ddl_okullar.SelectedValue = Convert.ToString(p.OkulID);
                ddl_sehirler.SelectedValue = Convert.ToString(p.SehirID);
                tb_baslik.Text = p.Baslik;
                tb_ozet.Text = p.Ozet;
                tb_baslangic.Text = p.BaTarih;
                tb_bitis.Text = p.BiTarih;
                tb_sartlar.Text = p.Sart;
                tb_icerik.Text = p.Icerik;
                tb_katilimci.Text = p.Katilimcilar;
                
                tb_iletisim.Text = p.iletisim;
                cb_yayinla.Checked = p.Durum;

            }
            else
            {
                Response.Redirect("ProjeListele.aspx");
            }
        }

        protected void lbtn_update_Click(object sender, EventArgs e)
        {
            bool go = true;
            int id = Convert.ToInt32(Request.QueryString["pid"]);
            Proje p = dm.ProjeGetir(id);
            p.Baslik = tb_baslik.Text;
            p.Icerik = tb_icerik.Text;
            p.Sehir = ddl_sehirler.SelectedValue;
            p.Okul = ddl_okullar.SelectedValue;
            p.Kategori = ddl_kategoriler.SelectedValue;
            p.Ozet = tb_ozet.Text;
            p.BaTarih = tb_baslangic.Text;
            p.BiTarih = tb_bitis.Text;
            p.Sart = tb_sartlar.Text;
            p.Katilimcilar = tb_katilimci.Text;
            p.iletisim = tb_iletisim.Text;
            p.Durum = cb_yayinla.Checked;
            if (fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;
                string dosyad = Guid.NewGuid() + uzanti;
                if (uzanti == ".png"|| uzanti== ".jpg" || uzanti==".jpeg" )
                {
                    fu_resim.SaveAs(Server.MapPath("~/ProjeResimleri/" + dosyad));
                    p.KapakResim = dosyad;
                }
                else
                {
                    go = false;
                }
            }
            if (go)
            {
                if (dm.ProjeGuncelle(p))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Bir hata oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Dosya uzantısı uygun değil";
            }
        }
    }
}
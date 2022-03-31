using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSL1
{
    public partial class ProjeEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_bolumler.DataSource = dm.BolumListele();
                ddl_bolumler.DataBind();
                ddl_kategoriler.DataSource = dm.KategoriListele();
                ddl_kategoriler.DataBind();
                ddl_okullar.DataSource = dm.OkulListele();
                ddl_okullar.DataBind();
                ddl_sehirler.DataSource = dm.SehirListele();
                ddl_sehirler.DataBind();
            }
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            bool resimformat = false;
            Proje prj = new Proje();
            prj.Baslik = tb_baslik.Text;
            prj.Baslik = tb_bat.Text;
            prj.BiTarih = tb_bit.Text;
            prj.BolumID = Convert.ToInt32(ddl_bolumler.SelectedValue);
            prj.KategoriID = Convert.ToInt32(ddl_kategoriler.SelectedValue);
            prj.OkulID = Convert.ToInt32(ddl_okullar.SelectedValue);
            prj.SehirID = Convert.ToInt32(ddl_sehirler.SelectedValue);
            prj.Durum = cb_yayinla.Checked;
            prj.Icerik = tb_icerik.Text;
            prj.Katilimcilar = tb_katiimcilar.Text;
            prj.Sart = tb_sartlar.Text;
            prj.iletisim = tb_iletisim.Text;
            Ogrenci o = (Ogrenci)Session["pid"];
            prj.EklemeTarihi = DateTime.Now;

            if (fu_resim.HasFiles)
            {
                FileInfo f = new FileInfo(fu_resim.FileName);
                string uzanti = f.Extension;
                if (uzanti == ".jpg" || uzanti == ".png")
                {
                    string resimad = Guid.NewGuid() + uzanti;
                    fu_resim.SaveAs(Server.MapPath("~/ProjeResimleri/" + resimad));
                    prj.KapakResim = resimad;
                    resimformat = true;
                }
            }
            else
            {
                prj.KapakResim = "none.png";
            }
            if (resimformat)
            {
                if (dm.ProjeEkle(prj))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Ekleme sırasında hata oluştu:( ";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Dosya türü uygun değil!";
            }
        }
    }
}
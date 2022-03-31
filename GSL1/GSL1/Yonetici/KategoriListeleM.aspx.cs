using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSL1.Yonetici
{
    public partial class KategoriListeleM : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lvi_kategoriler.DataSource = dm.MKategoriListele();
            lvi_kategoriler.DataBind();
        }

        protected void lvi_kategoriler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (!dm.KategoriSİL(id))
                {
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Silme işleminde bir hata oluştu";
                }
            }
            lvi_kategoriler.DataSource = dm.MKategoriListele();
            lvi_kategoriler.DataBind();
        }
    }
}
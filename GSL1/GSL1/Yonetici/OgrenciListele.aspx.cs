using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSL1.Yonetici
{
    public partial class OgrenciListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lvi_ogrenciler.DataSource = dm.OgrenciListele();
            lvi_ogrenciler.DataBind();

        }

        protected void lvi_ogrenciler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (!dm.OgrenciSİL(id))
                {
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Silme işleminde bir hata oluştu";
                }
            }
            lvi_ogrenciler.DataSource = dm.OgrenciListele();
            lvi_ogrenciler.DataBind();
        }
    }
}
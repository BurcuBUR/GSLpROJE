using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSL1.Yonetici
{
    public partial class SehirListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lvi_sehirler.DataSource = dm.SehirListele();
            lvi_sehirler.DataBind();
        }

        protected void lvi_sehirler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (!dm.SehirSİL(id))
                {
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Silme işleminde bir hata oluştu";
                }
            }
            lvi_sehirler.DataSource = dm.SehirListele();
            lvi_sehirler.DataBind();
        }
    }
}
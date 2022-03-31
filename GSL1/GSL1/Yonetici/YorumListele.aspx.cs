using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSL1.Yonetici
{
    public partial class YorumListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lvi_yorumlar.DataSource = dm.YorumListele();
            lvi_yorumlar.DataBind();
        }

        protected void lvi_yorumlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                dm.YorumSİL(id);
            }
            if (e.CommandName == "durum")
            {
                dm.YorumDurumDegistir(id);
            }
            lvi_yorumlar.DataSource = dm.YorumListele();
            lvi_yorumlar.DataBind();
        }
    }
}
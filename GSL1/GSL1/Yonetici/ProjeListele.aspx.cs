using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSL1.Yonetici
{
    public partial class ProjeListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lvi_projeler.DataSource = dm.ProjeListele();
            lvi_projeler.DataBind();
        }

        protected void lvi_projeler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                dm.ProjeSİL(id);
            }
            if(e.CommandName == "durum")
            {
                dm.ProjeDurumDegistir(id);
            }
            lvi_projeler.DataSource = dm.ProjeListele();
            lvi_projeler.DataBind();
        }
    }
}
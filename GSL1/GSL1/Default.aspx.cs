using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSL1
{
    public partial class Default : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
            {
                lv_projeler.DataSource = dm.ProjeListele();
                lv_projeler.DataBind();
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["kid"]);
                lv_projeler.DataSource = dm.ProjeListele(id);
                lv_projeler.DataBind();

            }
        }
    }
}
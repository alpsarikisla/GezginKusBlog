using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace GezginKusBlogWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        VeriModeli db = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_makaleler.DataSource = db.AktifMakaleleriListele();
            rp_makaleler.DataBind();
        }
    }
}
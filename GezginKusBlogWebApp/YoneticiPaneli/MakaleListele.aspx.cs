using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace GezginKusBlogWebApp.YoneticiPaneli
{
    public partial class MakaleListele : System.Web.UI.Page
    {
        VeriModeli db = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_makaleler.DataSource = db.TumMakaleleriListele();
            lv_makaleler.DataBind();
        }
    }
}
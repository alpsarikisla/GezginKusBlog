using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace GezginKusBlogWebApp
{
    public partial class Main : System.Web.UI.MasterPage
    {
        VeriModeli db = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_kategoriler.DataSource = db.AktifKategorileriGetir();
            rp_kategoriler.DataBind();
            rp_onerilenler.DataSource = db.OnerilenMakaleleriListele();
            rp_onerilenler.DataBind();
        }
    }
}
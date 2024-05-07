using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace GezginKusBlogWebApp.YoneticiPaneli
{
    public partial class KategoriListele : System.Web.UI.Page
    {
        VeriModeli db = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            ListDoldur();

        }

        protected void lv_Kategoriler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "durumdegistir")
            {
                db.KategoriDurumDegistir(id);
            }
            if (e.CommandName == "sil")
            {
                db.KategoriSil(id);
            }
           
            ListDoldur();
        }

        public void ListDoldur()
        {
            List<Kategori> kategoriler = db.TumKategorileriGetir();

            lv_Kategoriler.DataSource = kategoriler;
            lv_Kategoriler.DataBind();

            lbl_sayi.Text = "Kategori Sayı = " + kategoriler.Count;
        }
    }
}
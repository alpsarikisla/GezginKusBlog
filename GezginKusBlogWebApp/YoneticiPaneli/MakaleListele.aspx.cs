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
            ListDoldur();
        }

        protected void lv_makaleler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "durum")
            {
                db.MakaleDurumDegistir(id);
            }
            if (e.CommandName == "sil")
            {
                db.MakaleSil(id);
            }
            if (e.CommandName == "oneri")
            {
                db.MakaleOnerilenDegistir(id);
            }
            ListDoldur();
        }
        public void ListDoldur()
        {
            lv_makaleler.DataSource = db.TumMakaleleriListele();
            lv_makaleler.DataBind();
        }
    }
}
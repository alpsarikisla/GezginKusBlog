using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace GezginKusBlogWebApp.YoneticiPaneli
{
    public partial class MakaleEkle : System.Web.UI.Page
    {
        VeriModeli db = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            ddl_kategoriler.DataTextField = "Isim";
            ddl_kategoriler.DataValueField = "ID";
            ddl_kategoriler.DataSource = db.AktifKategorileriGetir();
            ddl_kategoriler.DataBind();
        }

        protected void lbtn_makaleEkle_Click(object sender, EventArgs e)
        {
            Makale mak = new Makale();
            mak.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);

            //Yonetici y = (Yonetici)Session["yonetici"];//Unboxing
            //mak.Yazar_ID = y.ID;

            mak.Yazar_ID = ((Yonetici)Session["yonetici"]).ID;
            mak.Baslik = tb_baslik.Text;
            mak.BegeniSayi = 0;
            mak.Durum = cb_durum.Checked;
            mak.EklemeTarihi = DateTime.Now;
            mak.GoruntulemeSayi = 0;
            mak.Icerik = tb_icerik.Text;
            mak.KapakResim = "none.png";
            mak.Ozet = tb_ozet.Text;

            if (db.MakaleEkle(mak))
            {
                pnl_basarili.Visible = true;
                pnl_basaririz.Visible = false;
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basaririz.Visible = true;
                lbl_mesaj.Text = "Makale eklerken Bir Hata Oluştu";
            }
        }
    }
}
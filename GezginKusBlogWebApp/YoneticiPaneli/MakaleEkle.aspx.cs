using System;
using System.Collections.Generic;
using System.IO;
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
            if (!IsPostBack)
            {
                ddl_kategoriler.DataTextField = "Isim";
                ddl_kategoriler.DataValueField = "ID";
                ddl_kategoriler.DataSource = db.AktifKategorileriGetir();
                ddl_kategoriler.DataBind();
            }
        }

        protected void lbtn_makaleEkle_Click(object sender, EventArgs e)
        {
            bool imageValid = true;
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
            mak.Ozet = tb_ozet.Text;

            if (fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;//Dosyanın Uzantısını verir ".jpg"
                if (uzanti == ".jpg" || uzanti == ".png" || uzanti == ".jpeg" || uzanti == ".gif")
                {
                    //Dosya isimlerini eşsiz yapmalıyız
                    string isim = Guid.NewGuid().ToString();
                    string dosyaTamAdi = isim + uzanti;
                    mak.KapakResim = dosyaTamAdi;
                    //fu_resim.SaveAs("../assets/MakaleResimleri/"+dosyaTamAdi);
                    fu_resim.SaveAs(Server.MapPath("../assets/MakaleResimleri/" + dosyaTamAdi));
                }
                else
                {
                    imageValid = false;
                }
            }
            else
            {
                mak.KapakResim = "none.png";
            }


            if (imageValid)
            {
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
            else
            {
                pnl_basarili.Visible = false;
                pnl_basaririz.Visible = true;
                lbl_mesaj.Text = "Resim türü uygun değil";
            }
        }
    }
}
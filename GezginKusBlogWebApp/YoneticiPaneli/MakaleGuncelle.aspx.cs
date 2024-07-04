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
    public partial class MakaleGuncelle : System.Web.UI.Page
    {
        VeriModeli db = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["MakaleID"]);
                    ddl_kategoriler.DataTextField = "Isim";
                    ddl_kategoriler.DataValueField = "ID";
                    ddl_kategoriler.DataSource = db.AktifKategorileriGetir();
                    ddl_kategoriler.DataBind();
                    Makale mak = db.MakaleGetir(id);
                    tb_baslik.Text = mak.Baslik;
                    tb_icerik.Text = mak.Icerik;
                    tb_ozet.Text = mak.Ozet;
                    cb_durum.Checked = mak.Durum;
                    img_resim.ImageUrl = "../assets/MakaleResimleri/" + mak.KapakResim;
                    ddl_kategoriler.SelectedValue = mak.Kategori_ID.ToString();
                }
            }
            else
            {
                Response.Redirect("MakaleListele.aspx");
            }
        }

        protected void lbtn_makaleGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["MakaleID"]);
            Makale mak = db.MakaleGetir(id);
            mak.Baslik = tb_baslik.Text;
            mak.Icerik = tb_icerik.Text;
            mak.Ozet = tb_ozet.Text;
            mak.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
            mak.Durum = cb_durum.Checked;
            bool imageValid = true;
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
                    fu_resim.SaveAs(Server.MapPath("../assets/MakaleResimleri/" + dosyaTamAdi));
                }
                else
                {
                    imageValid = false;
                }
            }
            if (imageValid)
            {
                if (db.MakaleGucelle(mak))
                {
                    pnl_basarili.Visible = true;
                    pnl_basaririz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basaririz.Visible = true;
                    lbl_mesaj.Text = "Makale güncellenirken Bir Hata Oluştu";
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
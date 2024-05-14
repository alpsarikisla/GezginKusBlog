using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace GezginKusBlogWebApp.YoneticiPaneli
{
    public partial class KategoriGuncelle : System.Web.UI.Page
    {
        VeriModeli db = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["kategoriid"]);
                    Kategori kat = db.KategoriGetir(id);
                    tb_isim.Text = kat.Isim;
                    tb_aciklama.Text = kat.Aciklama;
                    cb_durum.Checked = kat.Durum;
                }
            }
            else
            {
                Response.Redirect("KategoriListele.aspx");
            }
        }

        protected void lbtn_guncelle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                int id = Convert.ToInt32(Request.QueryString["kategoriid"]);
                Kategori kat = new Kategori();
                kat.ID = id;
                kat.Isim = tb_isim.Text;
                kat.Aciklama = tb_aciklama.Text;
                kat.Durum = cb_durum.Checked;

                if (db.KategoriGuncelle(kat))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_basarisiz.Text = "Kategori guncellenirken bir hata oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_basarisiz.Text = "Kategori ismi boş bırakılamaz";
            }
        }
    }
}
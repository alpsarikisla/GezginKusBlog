using System;
using System.Collections.Generic;
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

        protected void lbtn_makaleEkle_Click(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace GezginKusBlogWebApp.YoneticiPaneli
{
    public partial class KategoriEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                try
                {
                    SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=GezginKus_DB; Integrated Security=True");
                    SqlCommand komut = baglanti.CreateCommand();
                    komut.CommandText = "INSERT INTO Kategoriler(Isim,Aciklama,Durum) VALUES(@isim,@aciklama,@durum)";
                    komut.Parameters.AddWithValue("@isim", tb_isim.Text);
                    komut.Parameters.AddWithValue("@aciklama", tb_aciklama.Text);
                    komut.Parameters.AddWithValue("@durum", cb_durum.Checked);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                catch
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_basarisiz.Text = "Kategori eklenirken bir hata oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_basarisiz.Text = "Kategori adı boş bırakılamaz";
            }
        }

        protected void lbtn_Model_ile_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                Kategori kat = new Kategori();
                kat.Isim = tb_isim.Text;
                kat.Aciklama = tb_aciklama.Text;
                kat.Durum = cb_durum.Checked;
                VeriModeli db = new VeriModeli();
                if (db.KategoriEkle(kat))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_basarisiz.Text = "Kategori eklenirken bir hata oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_basarisiz.Text = "Kategori adı boş bırakılamaz";
            }
        }
    }
}
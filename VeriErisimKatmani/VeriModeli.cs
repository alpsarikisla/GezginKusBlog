using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class VeriModeli
    {
        SqlConnection baglanti;
        SqlCommand komut;
        public VeriModeli()
        {
            baglanti = new SqlConnection(BaglantiYollari.BagnatiYolu);
            komut = baglanti.CreateCommand();
        }

        #region Yonetici Metotları

        //Bu metot mail adresi ve şifreyi veritabanında kontrol edip eğer varsa Giriş yapmak isteyen Yonetici Bilgilerini Nesne haline getirip dondurecek
        public Yonetici YoneticiGiris(string mail, string sifre)
        {
            try
            {
                komut.CommandText = "SELECT Y.ID, Y.YoneticiTur_ID, YT.Isim, Y.Isim, Y.Soyisim, Y.Mail, Y.KullaniciAdi, Y.Sifre, Y. ProfilFotografi, Y.Durum, Y.Silinmis FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YoneticiTur_ID = YT.ID WHERE Y.Mail = @mail AND Y.Sifre = @sifre";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@mail", mail);
                komut.Parameters.AddWithValue("@sifre", sifre);
                baglanti.Open();
                SqlDataReader Okuyucu = komut.ExecuteReader();
                Yonetici y = new Yonetici();
                while (Okuyucu.Read())
                {
                    y.ID = Okuyucu.GetInt32(0);
                    y.YoneticiTur_ID = Okuyucu.GetInt32(1);
                    y.YoneticiTur = Okuyucu.GetString(2);
                    y.Isim = Okuyucu.GetString(3);
                    y.Soyisim = Okuyucu.GetString(4);
                    y.Mail = Okuyucu.GetString(5);
                    y.KullaniciAdi = Okuyucu.GetString(6);
                    y.Sifre = Okuyucu.GetString(7);
                    y.ProfilFotografi = Okuyucu.GetString(8);
                    y.Durum = Okuyucu.GetBoolean(9);
                    y.Silinmis = Okuyucu.GetBoolean(10);
                }
                return y;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }


        #endregion

        #region Kategori Metotları

        public bool KategoriEkle(Kategori kat)
        {
            try
            {
                komut.CommandText = "INSERT INTO Kategoriler(Isim, Aciklama, Durum) VALUES(@isim,@aciklama,@durum)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@isim", kat.Isim);
                komut.Parameters.AddWithValue("@aciklama", kat.Aciklama);
                komut.Parameters.AddWithValue("@durum", kat.Durum);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

        #endregion
    }
}

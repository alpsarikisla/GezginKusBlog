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
        public List<Kategori> TumKategorileriGetir()
        {
            try
            {
                List<Kategori> kategoriler = new List<Kategori>();
                komut.CommandText = "SELECT ID, Isim, Aciklama, Durum FROM Kategoriler";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = okuyucu.GetInt32(0);
                    kat.Isim = okuyucu.GetString(1);
                    kat.Aciklama = okuyucu.GetString(2);
                    kat.Durum = okuyucu.GetBoolean(3);
                    kategoriler.Add(kat);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public List<Kategori> AktifKategorileriGetir()
        {
            try
            {
                List<Kategori> kategoriler = new List<Kategori>();
                komut.CommandText = "SELECT ID, Isim, Aciklama, Durum FROM Kategoriler WHERE Durum = 1";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = okuyucu.GetInt32(0);
                    kat.Isim = okuyucu.GetString(1);
                    kat.Aciklama = okuyucu.GetString(2);
                    kat.Durum = okuyucu.GetBoolean(3);
                    kategoriler.Add(kat);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public void KategoriDurumDegistir(int id)
        {
            try
            {
                komut.CommandText = "SELECT Durum FROM Kategoriler WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                bool durum = Convert.ToBoolean(komut.ExecuteScalar());
                komut.CommandText = "UPDATE Kategoriler SET Durum = @durum WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                komut.Parameters.AddWithValue("@durum", !durum);
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }
        public void KategoriSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM Kategoriler WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }
        public bool KategoriGuncelle(Kategori kat)
        {
            try
            {
                komut.CommandText = "UPDATE Kategoriler SET Isim=@i, Aciklama=@a, Durum=@d WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", kat.ID);
                komut.Parameters.AddWithValue("@i", kat.Isim);
                komut.Parameters.AddWithValue("@a", kat.Aciklama);
                komut.Parameters.AddWithValue("@d", kat.Durum);
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
        public Kategori KategoriGetir(int id)
        {
            try
            {
                Kategori kat = new Kategori();
                komut.CommandText = "SELECT ID, Isim, Aciklama, Durum FROM Kategoriler WHERE ID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();

                while (okuyucu.Read())
                {
                    kat.ID = okuyucu.GetInt32(0);
                    kat.Isim = okuyucu.GetString(1);
                    kat.Aciklama = okuyucu.GetString(2);
                    kat.Durum = okuyucu.GetBoolean(3);
                }
                return kat;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        #endregion

        #region Makale Metotları

        public bool MakaleEkle(Makale mak)
        {
            try
            {
                komut.CommandText = "INSERT INTO Makaleler(Kategori_ID, Yazar_ID, Baslik, Ozet, Icerik, EklemeTarihi, KapakResim, GoruntulemeSayi, BegeniSayi, Durum) VALUES(@kategori_ID, @yazar_ID, @baslik, @ozet, @icerik, @eklemeTarihi, @kapakResim, @goruntulemeSayi, @begeniSayi, @durum)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kategori_ID", mak.Kategori_ID);
                komut.Parameters.AddWithValue("@yazar_ID", mak.Yazar_ID);
                komut.Parameters.AddWithValue("@baslik", mak.Baslik);
                komut.Parameters.AddWithValue("@ozet", mak.Ozet);
                komut.Parameters.AddWithValue("@icerik", mak.Icerik);
                komut.Parameters.AddWithValue("@eklemeTarihi", mak.EklemeTarihi);
                komut.Parameters.AddWithValue("@kapakResim", mak.KapakResim);
                komut.Parameters.AddWithValue("@goruntulemeSayi", mak.GoruntulemeSayi);
                komut.Parameters.AddWithValue("@begeniSayi", mak.BegeniSayi);
                komut.Parameters.AddWithValue("@durum", mak.Durum);
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

        public List<Makale> TumMakaleleriListele()
        {
            List<Makale> makaleler = new List<Makale>();
            try
            {
                komut.CommandText = "SELECT M.ID, M.Kategori_ID, K.Isim, M.Yazar_ID, Y.KullaniciAdi, M.Baslik, M.Ozet, M.Icerik, M.EklemeTarihi, M.KapakResim, M.GoruntulemeSayi, M.BegeniSayi, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON M.Kategori_ID = K.ID JOIN Yoneticiler AS Y ON M.Yazar_ID = Y.ID";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Makale m = new Makale();
                    m.ID = okuyucu.GetInt32(0);
                    m.Kategori_ID = okuyucu.GetInt32(1);
                    m.Kategori = okuyucu.GetString(2);
                    m.Yazar_ID = okuyucu.GetInt32(3);
                    m.Yazar = okuyucu.GetString(4);
                    m.Baslik = okuyucu.GetString(5);
                    m.Ozet = okuyucu.GetString(6);
                    m.Icerik = okuyucu.GetString(7);
                    m.EklemeTarihi = okuyucu.GetDateTime(8);
                    m.EklemeTarihiStr = okuyucu.GetDateTime(8).ToShortDateString();
                    m.KapakResim = okuyucu.GetString(9);
                    m.GoruntulemeSayi = okuyucu.GetInt32(10);
                    m.BegeniSayi = okuyucu.GetInt32(11);
                    m.Durum = okuyucu.GetBoolean(12);
                    makaleler.Add(m);
                }
                return makaleler;
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

        public Makale MakaleGetir(int id)
        {
            try
            {
                komut.CommandText = "SELECT M.ID, M.Kategori_ID, K.Isim, M.Yazar_ID, Y.KullaniciAdi, M.Baslik, M.Ozet, M.Icerik, M.EklemeTarihi, M.KapakResim, M.GoruntulemeSayi, M.BegeniSayi, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON M.Kategori_ID = K.ID JOIN Yoneticiler AS Y ON M.Yazar_ID = Y.ID WHERE M.ID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                Makale m = new Makale();
                while (okuyucu.Read())
                {
                    m.ID = okuyucu.GetInt32(0);
                    m.Kategori_ID = okuyucu.GetInt32(1);
                    m.Kategori = okuyucu.GetString(2);
                    m.Yazar_ID = okuyucu.GetInt32(3);
                    m.Yazar = okuyucu.GetString(4);
                    m.Baslik = okuyucu.GetString(5);
                    m.Ozet = okuyucu.GetString(6);
                    m.Icerik = okuyucu.GetString(7);
                    m.EklemeTarihi = okuyucu.GetDateTime(8);
                    m.EklemeTarihiStr = okuyucu.GetDateTime(8).ToShortDateString();
                    m.KapakResim = okuyucu.GetString(9);
                    m.GoruntulemeSayi = okuyucu.GetInt32(10);
                    m.BegeniSayi = okuyucu.GetInt32(11);
                    m.Durum = okuyucu.GetBoolean(12);
                }
                return m;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        #endregion
    }
}

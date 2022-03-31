using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {

        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region Yonetici Metotlarıı
        public Yonetici YoneticiGiris(string mail,string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE mail=@m AND sifre=@s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT ID,YoneticiTurID,ad,soyad,mail,sifre,Durum FROM Yoneticiler WHERE mail=@m AND sifre=@s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Yonetici y = null;
                    while (reader.Read())
                    {
                        y = new Yonetici();
                        y.ID = reader.GetInt32(0);
                        y.YoneticiTurID = reader.GetInt32(1);
                        y.ad = reader.GetString(2);
                        y.soyad = reader.GetString(3);
                        y.mail = reader.GetString(4);
                        y.sifre = reader.GetString(5);
                        y.Durum = reader.GetBoolean(6);
                    }
                    return y;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception )
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Okul Metotları

        public List<Okul> OkulListele()
        {
            try
            {
                List<Okul> okullar = new List<Okul>();
                cmd.CommandText = "SELECT ID, isim, BolumID, SehirID FROM Okullar ";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Okul o = new Okul();
                    o.ID = reader.GetInt32(0);
                    o.isim = reader.GetString(1);
                    o.BolumID = reader.GetInt32(2);
                    o.SehirID = reader.GetInt32(3);
                    okullar.Add(o);
                }
                return okullar;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        
        public bool OkulSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Okullar WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public Okul OkulGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID,isim,BolumID,SehirID FROM Okullar WHERE ID =@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Okul o = new Okul();

                while (reader.Read())
                {
                    o.ID = reader.GetInt32(0);
                    o.isim = reader.GetString(1);
                    o.BolumID = reader.GetInt32(2);
                    o.SehirID = reader.GetInt32(3);
                }
                return o;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool OkulGuncelle(Okul o)
        {
            try
            {
                cmd.CommandText = "UPDATE Okullar SET isim = @i WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@i", o.isim);
                cmd.Parameters.AddWithValue("@id", o.ID);
                con.Open();

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Sehir Metotları

        public List<Sehir> SehirListele()
        {
            try
            {
                List<Sehir> sehirler = new List<Sehir>();
                cmd.CommandText = "SELECT ID,AD FROM Sehirler";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Sehir s = new Sehir();
                    s.ID = reader.GetInt32(0);
                    s.AD = reader.GetString(1);
                    sehirler.Add(s);
                }
                return sehirler;
            }
            catch (Exception)
            {
                return null;
                
            }
            finally
            {
                con.Close();
            }
        }

        public bool SehirSİL(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Sehirler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public Sehir SehirGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID,AD FROM Sehirler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Sehir s = new Sehir();
                while (reader.Read())
                {
                    s.ID = reader.GetInt32(0);
                    s.AD = reader.GetString(1);
                }
                return s;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }


        }

        public bool SehirGuncelle(Sehir s)
        {
            try
            {
                cmd.CommandText = "UPDATE Sehirler SET AD= @a WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@a", s.AD);
                cmd.Parameters.AddWithValue("@id", s.ID);
                con.Open();

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }

        
        #endregion

        #region Ogrenci Metotları

        public List<Ogrenci> OgrenciListele()
        {
            try
            {
                List<Ogrenci> ogrenciler = new List<Ogrenci>();
                cmd.CommandText = "SELECT ID,KategoriID, BolumID,OkullID,ad,soyad,nickname,uyelikTarihi,Durum FROM Ogrenciler ";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Ogrenci o = new Ogrenci();
                    o.ID = reader.GetInt32(0);
                    o.KategoriID = reader.GetInt32(1);
                    o.BolumID = reader.GetInt32(2);
                    o.OkullID = reader.GetInt32(3);
                    o.ad = reader.GetString(4);
                    o.soyad = reader.GetString(5);
                    o.nickname = reader.GetString(6);
                    o.uyelikTarihi = reader.GetDateTime(7);
                    o.Durum = reader.GetBoolean(8);
                    ogrenciler.Add(o);
                }
                return ogrenciler;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool OgrenciSİL(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Ogrenciler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public Ogrenci UyeGiris(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Ogrenciler WHERE mail=@m AND sifre=@s ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());

                if (sayi == 1)
                {
                    cmd.CommandText = "SELECT ID,KategoriID,BolumID,OkulID,ad,soyad,nickname,mail,sifre,uyelikTarihi,Durum FROM Ogrenciler WHERE mail=@m AND sifre=@s ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Ogrenci o = new Ogrenci();
                    while (reader.Read())
                    {
                        o.ID = reader.GetInt32(0);
                        o.KategoriID = reader.GetInt32(1);
                        o.BolumID = reader.GetInt32(2);
                        o.OkullID = reader.GetInt32(3);
                        o.ad = reader.GetString(4);
                        o.soyad = reader.GetString(5);
                        o.nickname = reader.GetString(6);
                        o.mail = reader.GetString(7);
                        o.sifre = reader.GetString(8);
                        o.uyelikTarihi = reader.GetDateTime(9);
                        o.Durum = reader.GetBoolean(10);
                    }
                    return o;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UyeOl(Ogrenci uye)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Ogrenciler( BolumID, OkulID, ad,soyad,nickname,mail,sifre,uyelikTarihi) VALUES ( @bolumID, @okulID, @aad,@ssoyad,@nnickname,@mmail,@ssifre,@uuyelikTarihi)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@bolumID", uye.BolumID);
                cmd.Parameters.AddWithValue("@okulID", uye.OkullID);
                cmd.Parameters.AddWithValue("@aad", uye.ad);
                cmd.Parameters.AddWithValue("@ssoyad", uye.soyad);
                cmd.Parameters.AddWithValue("@nnickname", uye.nickname);
                cmd.Parameters.AddWithValue("@mmail", uye.mail);
                cmd.Parameters.AddWithValue("@ssifre", uye.sifre);
                cmd.Parameters.AddWithValue("@uuyelikTarihi", uye.uyelikTarihi);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;


            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Kategori Metotları

        public List<Kategori> KategoriListele()
        {
            try
            {
                List<Kategori> kategoriler = new List<Kategori>();
                cmd.CommandText = "SELECT ID,BolumID,Isim From Kategoriler";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori k = new Kategori();
                    k.ID = reader.GetInt32(0);
                    k.BolumID = reader.GetInt32(1);
                    k.Isim = reader.GetString(2);
                    kategoriler.Add(k);
                }
                return kategoriler;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Kategori> RKategoriListele()
        {
            try
            {
                List<Kategori> kategoriler = new List<Kategori>();
                cmd.CommandText = "SELECT ID,BolumID,Isim From Kategoriler WHERE BolumID=1";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori k = new Kategori();
                    k.ID = reader.GetInt32(0);
                    k.BolumID = reader.GetInt32(1);
                    k.Isim = reader.GetString(2);
                    kategoriler.Add(k);
                }
                return kategoriler;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Kategori> MKategoriListele()
        {
            try
            {
                List<Kategori> kategoriler = new List<Kategori>();
                cmd.CommandText = "SELECT ID,BolumID,Isim FROM Kategoriler WHERE BolumID=2";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori k = new Kategori();
                    k.ID = reader.GetInt32(0);
                    k.BolumID = reader.GetInt32(1);
                    k.Isim = reader.GetString(2);
                    kategoriler.Add(k);

                }
                return kategoriler;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool KategoriSİL(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public Kategori KategoriGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID,BolumID,Isim FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                Kategori k = new Kategori();
                while (reader.Read())
                {
                    k.ID = reader.GetInt32(0);
                    k.BolumID = reader.GetInt32(1);
                    k.Isim = reader.GetString(2);

                }
                return k;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool KategoriGuncelle(Kategori k)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET BolumID = @bid,Isim = @i WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@bid", k.BolumID);
                cmd.Parameters.AddWithValue("@i", k.Isim);
                cmd.Parameters.AddWithValue("@id", k.ID);
                con.Open();

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Proje Metotları
        public List<Proje> ProjeListele()
        {
            try
            {
                List<Proje> projeler = new List<Proje>();
                cmd.CommandText = "SELECT P.ID ,P.BolumID ,B.isim,P.KategoriID ,K.isim,P.YazarID,Y.ad+''+Y.soyad,P.SehirID,S.AD,P.OkulID,O.isim,P.Baslik,P.Ozet,P.Batarih,P.BiTarih,P.KapakResim,P.Sart,P.Icerik,P.Katilimcilar,P.iletişim,P.EklemeTarihi,P.Durum FROM Projeler AS P JOIN Bolumler AS B ON B.ID = P.BolumID JOIN Kategoriler AS K ON K.ID = P.KategoriID JOIN Ogrenciler AS Y ON Y.ID = P.YazarID JOIN Sehirler AS S ON S.ID = P.SehirID JOIN Okullar AS O ON O.ID = P.OkulID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Proje p = new Proje();
                    p.ID = reader.GetInt32(0);
                    p.BolumID = reader.GetInt32(1);
                    p.Bolum = reader.GetString(2);
                    p.KategoriID = reader.GetInt32(3);
                    p.Kategori = reader.GetString(4);
                    p.YazarID = reader.GetInt32(5);
                    p.Ogrennci = reader.GetString(6);
                    p.SehirID = reader.GetInt32(7);
                    p.Sehir = reader.GetString(8);
                    p.OkulID = reader.GetInt32(9);
                    p.Okul = reader.GetString(10);
                    p.Baslik = reader.GetString(11);
                    p.Ozet = reader.GetString(12);
                    p.BaTarih = reader.GetString(13);
                    p.BiTarih = reader.GetString(14);
                    p.KapakResim = reader.GetString(15);
                    p.Sart = reader.GetString(16);
                    p.Icerik = reader.GetString(17);
                    p.Katilimcilar = reader.GetString(18);
                    p.iletisim = reader.GetString(19);
                    p.EklemeTarihi = reader.GetDateTime(20);
                    p.Durum = reader.GetBoolean(21);
                    projeler.Add(p);
                }
                return projeler;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Proje> RProjeListele()
        {
            try
            {
                List<Proje> projeler = new List<Proje>();
                cmd.CommandText = "SELECT P.ID ,P.BolumID ,B.isim,P.KategoriID ,K.isim,P.YazarID,Y.ad + '' + Y.soyad,P.SehirID,S.AD,P.OkulID,O.isim,P.Baslik,P.Ozet,P.Batarih,P.BiTarih,P.KapakResim,P.Sart,P.Icerik,P.Katilimcilar,P.iletişim,P.EklemeTarihi,P.Durum FROM Projeler AS P JOIN Bolumler AS B ON B.ID = P.BolumID JOIN Kategoriler AS K ON K.ID = P.KategoriID JOIN Ogrenciler AS Y ON Y.ID = P.YazarID JOIN Sehirler AS S ON S.ID = P.SehirID JOIN Okullar AS O ON O.ID = P.OkulID WHERE P.BolumID=1";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Proje p = new Proje();
                    p.ID = reader.GetInt32(0);
                    p.BolumID = reader.GetInt32(1);
                    p.Bolum = reader.GetString(2);
                    p.KategoriID = reader.GetInt32(3);
                    p.Kategori = reader.GetString(4);
                    p.YazarID = reader.GetInt32(5);
                    p.Ogrennci = reader.GetString(6);
                    p.SehirID = reader.GetInt32(7);
                    p.Sehir = reader.GetString(8);
                    p.OkulID = reader.GetInt32(9);
                    p.Okul = reader.GetString(10);
                    p.Baslik = reader.GetString(11);
                    p.Ozet = reader.GetString(12);
                    p.BaTarih = reader.GetString(13);
                    p.BiTarih = reader.GetString(14);
                    p.KapakResim = reader.GetString(15);
                    p.Sart = reader.GetString(16);
                    p.Icerik = reader.GetString(17);
                    p.Katilimcilar = reader.GetString(18);
                    p.iletisim = reader.GetString(19);
                    p.EklemeTarihi = reader.GetDateTime(20);
                    p.Durum = reader.GetBoolean(21);
                    projeler.Add(p);


                }
                return projeler;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Proje> MProjeListele()
        {
            try
            {
                List<Proje> projeler = new List<Proje>();
                cmd.CommandText = "SELECT P.ID ,P.BolumID ,B.isim,P.KategoriID ,K.isim,P.YazarID,Y.ad + '' + Y.soyad,P.SehirID,S.AD,P.OkulID,O.isim,P.Baslik,P.Ozet,P.Batarih,P.BiTarih,P.KapakResim,P.Sart,P.Icerik,P.Katilimcilar,P.iletişim,P.EklemeTarihi,P.Durum FROM Projeler AS P JOIN Bolumler AS B ON B.ID = P.BolumID JOIN Kategoriler AS K ON K.ID = P.KategoriID JOIN Ogrenciler AS Y ON Y.ID = P.YazarID JOIN Sehirler AS S ON S.ID = P.SehirID JOIN Okullar AS O ON O.ID = P.OkulID WHERE P.BolumID=2";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Proje p = new Proje();
                    p.ID = reader.GetInt32(0);
                    p.BolumID = reader.GetInt32(1);
                    p.Bolum = reader.GetString(2);
                    p.KategoriID = reader.GetInt32(3);
                    p.Kategori = reader.GetString(4);
                    p.YazarID = reader.GetInt32(5);
                    p.Ogrennci = reader.GetString(6);
                    p.SehirID = reader.GetInt32(7);
                    p.Sehir = reader.GetString(8);
                    p.OkulID = reader.GetInt32(9);
                    p.Okul = reader.GetString(10);
                    p.Baslik = reader.GetString(11);
                    p.Ozet = reader.GetString(12);
                    p.BaTarih = reader.GetString(13);
                    p.BiTarih = reader.GetString(14);
                    p.KapakResim = reader.GetString(15);
                    p.Sart = reader.GetString(16);
                    p.Icerik = reader.GetString(17);
                    p.Katilimcilar = reader.GetString(18);
                    p.iletisim = reader.GetString(19);
                    p.EklemeTarihi = reader.GetDateTime(20);
                    p.Durum = reader.GetBoolean(21);
                    projeler.Add(p);


                }
                return projeler;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool ProjeSİL(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Projeler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }      
        public List<Proje> ProjeListele(int katid)
        {
            try
            {
                List<Proje> projeler = new List<Proje>();
                cmd.CommandText = "SELECT P.ID ,P.BolumID ,B.isim,P.KategoriID ,K.isim,P.YazarID,Y.ad+''+Y.soyad,P.SehirID,S.AD,P.OkulID,O.isim,P.Baslik,P.Ozet,P.Batarih,P.BiTarih,P.KapakResim,P.Sart,P.Icerik,P.Katilimcilar,P.iletişim,P.EklemeTarihi,P.Durum FROM Projeler AS P JOIN Bolumler AS B ON B.ID = P.BolumID JOIN Kategoriler AS K ON K.ID = P.KategoriID JOIN Ogrenciler AS Y ON Y.ID = P.YazarID JOIN Sehirler AS S ON S.ID = P.SehirID JOIN Okullar AS O ON O.ID = P.OkulID WHERE P.KategoriID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", katid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Proje p = new Proje();
                    p.ID = reader.GetInt32(0);
                    p.BolumID = reader.GetInt32(1);
                    p.Bolum = reader.GetString(2);
                    p.KategoriID = reader.GetInt32(3);
                    p.Kategori = reader.GetString(4);
                    p.YazarID = reader.GetInt32(5);
                    p.Ogrennci = reader.GetString(6);
                    p.SehirID = reader.GetInt32(7);
                    p.Sehir = reader.GetString(8);
                    p.OkulID = reader.GetInt32(9);
                    p.Okul = reader.GetString(10);
                    p.Baslik = reader.GetString(11);
                    p.Ozet = reader.GetString(12);
                    p.BaTarih = reader.GetString(13);
                    p.BiTarih = reader.GetString(14);
                    p.KapakResim = reader.GetString(15);
                    p.Sart = reader.GetString(16);
                    p.Icerik = reader.GetString(17);
                    p.Katilimcilar = reader.GetString(18);
                    p.iletisim = reader.GetString(19);
                    p.EklemeTarihi = reader.GetDateTime(20);
                    p.Durum = reader.GetBoolean(21);
                    projeler.Add(p);
                }
                return projeler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool ProjeDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Projeler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = (bool)cmd.ExecuteScalar();
                cmd.CommandText = "UPDATE Projeler SET Durum=@id WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public Proje ProjeGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT P.ID ,P.BolumID ,B.isim,P.KategoriID ,K.isim,P.YazarID,Y.ad+''+Y.soyad,P.SehirID,S.AD,P.OkulID,O.isim,P.Baslik,P.Ozet,P.Batarih,P.BiTarih,P.KapakResim,P.Sart,P.Icerik,P.Katilimcilar,P.iletişim,P.EklemeTarihi,P.Durum FROM Projeler AS P JOIN Bolumler AS B ON B.ID = P.BolumID JOIN Kategoriler AS K ON K.ID = P.KategoriID JOIN Ogrenciler AS Y ON Y.ID = P.YazarID JOIN Sehirler AS S ON S.ID = P.SehirID JOIN Okullar AS O ON O.ID = P.OkulID WHERE P.ID=@id ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Proje p = new Proje();
                while (reader.Read())
                {
                    p.ID = reader.GetInt32(0);
                    p.BolumID = reader.GetInt32(1);
                    p.Bolum = reader.GetString(2);
                    p.KategoriID = reader.GetInt32(3);
                    p.Kategori = reader.GetString(4);
                    p.YazarID = reader.GetInt32(5);
                    p.Ogrennci = reader.GetString(6);
                    p.SehirID = reader.GetInt32(7);
                    p.Sehir = reader.GetString(8);
                    p.OkulID = reader.GetInt32(9);
                    p.Okul = reader.GetString(10);
                    p.Baslik = reader.GetString(11);
                    p.Ozet = reader.GetString(12);
                    p.BaTarih = reader.GetString(13);
                    p.BiTarih = reader.GetString(14);
                    p.KapakResim = reader.GetString(15);
                    p.Sart = reader.GetString(16);
                    p.Icerik = reader.GetString(17);
                    p.Katilimcilar = reader.GetString(18);
                    p.iletisim = reader.GetString(19);
                    p.EklemeTarihi = reader.GetDateTime(20);
                    p.Durum = reader.GetBoolean(21);
                }
                return p;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool ProjeEkle(Proje prj)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Projeler(BolumID ,KategoriID ,YazarID,SehirID,OkulID,Baslik,Ozet,Batarih,BiTarih,KapakResim,Sart,Icerik,Katilimcilar,iletişim,EklenmeTarihi,Durum) VALUES(@bolumID ,@kategoriID ,@yazarID,@sehirID,@okulID,@baslik,@ozet,@bat,@bit,@resim,@sart,@icerik,@katilimci,@iletisim,@ekt,@durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@bolumID", prj.BolumID);
                cmd.Parameters.AddWithValue("@kategoriID", prj.KategoriID);
                cmd.Parameters.AddWithValue("@yazarID", prj.YazarID);
                cmd.Parameters.AddWithValue("@sehirID", prj.SehirID);
                cmd.Parameters.AddWithValue("@okulID", prj.OkulID);
                cmd.Parameters.AddWithValue("@baslik", prj.Baslik);
                cmd.Parameters.AddWithValue("@ozet", prj.Ozet);
                cmd.Parameters.AddWithValue("@bat", prj.BaTarih);
                cmd.Parameters.AddWithValue("@bit", prj.BiTarih);
                cmd.Parameters.AddWithValue("@resim", prj.KapakResim);
                cmd.Parameters.AddWithValue("@sart", prj.Sart);
                cmd.Parameters.AddWithValue("@icerik", prj.Icerik);
                cmd.Parameters.AddWithValue("@katilimci", prj.Katilimcilar);
                cmd.Parameters.AddWithValue("@iletişim", prj.iletisim);
                cmd.Parameters.AddWithValue("@ekt", prj.EklemeTarihi);
                cmd.Parameters.AddWithValue("@durum", prj.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool ProjeGuncelle(Proje prj)
        {
            try
            {
                cmd.CommandText = "UPDATE Projeler SET KategoriID=@katid, OkulID=@okulid, SehirID=sehirid, Baslik=@baslik,Ozet=@ozet,KapakResim=@kapakresim,Batarih=@batarih,BiTarih=@bitarih, Sart=@sart, Icerik=@icerik,Katilimcilar=@katilimci,Durum=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", prj.ID);
                cmd.Parameters.AddWithValue("@katid", prj.KategoriID);
                cmd.Parameters.AddWithValue("@okulid", prj.OkulID);
                cmd.Parameters.AddWithValue("@sehirid", prj.SehirID);
                cmd.Parameters.AddWithValue("@baslik", prj.Baslik);
                cmd.Parameters.AddWithValue("@ozet", prj.Ozet);
                cmd.Parameters.AddWithValue("@kapakresim", prj.KapakResim); 
                cmd.Parameters.AddWithValue("@batarih", prj.BaTarih);
                cmd.Parameters.AddWithValue("@bitarih", prj.BiTarih);
                cmd.Parameters.AddWithValue("@sart", prj.Sart);
                cmd.Parameters.AddWithValue("@icerik", prj.Icerik);
                cmd.Parameters.AddWithValue("@katilimci", prj.Katilimcilar);
                cmd.Parameters.AddWithValue("@durum", prj.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Proje> Projelerim(int uyeid)
        {
            try
            {
                List<Proje> projeler = new List<Proje>();
                cmd.CommandText = "SELECT P.ID ,P.BolumID ,B.isim,P.KategoriID ,K.isim,P.YazarID,Y.ad+''+Y.soyad,P.SehirID,S.AD,P.OkulID,O.isim,P.Baslik,P.Ozet,P.Batarih,P.BiTarih,P.KapakResim,P.Sart,P.Icerik,P.Katilimcilar,P.iletişim,P.EklemeTarihi,P.Durum FROM Projeler AS P JOIN Bolumler AS B ON B.ID = P.BolumID JOIN Kategoriler AS K ON K.ID = P.KategoriID JOIN Ogrenciler AS Y ON Y.ID = P.YazarID JOIN Sehirler AS S ON S.ID = P.SehirID JOIN Okullar AS O ON O.ID = P.OkulID WHERE P.YazarID=@id ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", uyeid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Proje p = new Proje();
                    p.ID = reader.GetInt32(0);
                    p.BolumID = reader.GetInt32(1);
                    p.Bolum = reader.GetString(2);
                    p.KategoriID = reader.GetInt32(3);
                    p.Kategori = reader.GetString(4);
                    p.YazarID = reader.GetInt32(5);
                    p.Ogrennci = reader.GetString(6);
                    p.SehirID = reader.GetInt32(7);
                    p.Sehir = reader.GetString(8);
                    p.OkulID = reader.GetInt32(9);
                    p.Okul = reader.GetString(10);
                    p.Baslik = reader.GetString(11);
                    p.Ozet = reader.GetString(12);
                    p.BaTarih = reader.GetString(13);
                    p.BiTarih = reader.GetString(14);
                    p.KapakResim = reader.GetString(15);
                    p.Sart = reader.GetString(16);
                    p.Icerik = reader.GetString(17);
                    p.Katilimcilar = reader.GetString(18);
                    p.iletisim = reader.GetString(19);
                    p.EklemeTarihi = reader.GetDateTime(20);
                    p.Durum = reader.GetBoolean(21);
                    projeler.Add(p);
                }
                return projeler;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Bolum Metot

        public List<Bolum> BolumListele()
        {
            try
            {
                List<Bolum> bolumler = new List<Bolum>();
                cmd.CommandText = "SELECT isim FROM Bolumler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Bolum b = new Bolum();
                    b.isim = reader.GetString(0);
                    bolumler.Add(b);
                }
                return bolumler;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Yorum Metotları

        public List<Yorum> YorumListele()
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID , Y.OgrenciID , O.nickname , Y.ProjeID,P.Baslik, Y.Icerik, Y.YorumTarih, Y.OnayDurum FROM Yorumlar AS Y JOIN Ogrenciler AS O ON O.ID = Y.OgrenciID JOIN Projeler AS P ON P.ID=Y.ProjeID  ";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.OgrenciID = reader.GetInt32(1);
                    y.nickname = reader.GetString(2);
                    y.ProjeID = reader.GetInt32(3);
                    y.Baslik = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.YorumTarih = reader.GetDateTime(6);
                    y.OnayDurum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Yorum> YorumListele(int Pid)
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID , Y.OgrenciID , O.nickname , Y.ProjeID,P.Baslik, Y.Icerik, Y.YorumTarih, Y.OnayDurum FROM Yorumlar AS Y JOIN Ogrenciler AS O ON O.ID = Y.OgrenciID JOIN Projeler AS P ON P.ID=Y.ProjeID WHERE P.ProjeID =@id AND P.OnayDurum =1 ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", Pid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.OgrenciID = reader.GetInt32(1);
                    y.nickname = reader.GetString(2);
                    y.ProjeID = reader.GetInt32(3);
                    y.Baslik = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.YorumTarih = reader.GetDateTime(6);
                    y.OnayDurum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }    

        public bool YorumEkle(Yorum y)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Yorumlar(OgrenciID, ProjeID,Icerik,YorumTarih,Onayurum) VALUES(@ogrenciID, @projeID,@icerik,@yorumTarih,@onayurum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ogrenciID", y.OgrenciID);
                cmd.Parameters.AddWithValue("@projeID", y.ProjeID);
                cmd.Parameters.AddWithValue("@icerik", y.Icerik);
                cmd.Parameters.AddWithValue("@yorumTarih", y.YorumTarih);
                cmd.Parameters.AddWithValue("@onayDurum", y.OnayDurum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool YorumDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Yorumlar WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = (bool)cmd.ExecuteScalar();
                cmd.CommandText = "UPDATE Yorumlar SET Durum=@d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@d",!durum);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool YorumSİL(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Yorumlar WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                con.Close();
            }
        }


        #endregion


    }
}

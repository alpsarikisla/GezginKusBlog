CREATE DATABASE GezginKus_DB
GO
USE GezginKus_DB
GO
CREATE TABLE YoneticiTurleri
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50),
	CONSTRAINT pk_YoneticiTur PRIMARY KEY(ID)
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
)
GO
INSERT INTO YoneticiTurleri(Isim) VALUES('Admin')
INSERT INTO YoneticiTurleri(Isim) VALUES('Yazar')
GO
CREATE TABLE Yoneticiler
(
	ID int IDENTITY(1,1),
	YoneticiTur_ID int,
	Isim nvarchar(50),
	Soyisim nvarchar(50),
	Mail nvarchar(100),
	KullaniciAdi nvarchar(20),
	Sifre nvarchar(20),
	ProfilFotografi nvarchar(50),
<<<<<<< Updated upstream
	Durum bit,   --IsActive de kullanabilirdik
	Silinmiþ bit, --IsDeleted de olurdu
	--SOFT VE HARD DELETE FARKLIDIR
	CONSTRAINT pk_Yonetici PRIMARY KEY(ID),
	CONSTRAINT fk_YoneticiYoneticiTur FOREIGN KEY(YoneticiTur_ID) REFERENCES YoneticiTurleri(ID)

=======
	Durum bit,
	Silinmis bit,
	CONSTRAINT pk_Yonetici PRIMARY KEY(ID),
	CONSTRAINT fk_YoneticiYoneticiTur FOREIGN KEY(YoneticiTur_ID) REFERENCES YoneticiTurleri(ID)
>>>>>>> Stashed changes
)
GO
CREATE TABLE Kategoriler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50),
	Aciklama ntext,
	Durum bit,
	CONSTRAINT pk_Kategori PRIMARY KEY(ID)
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
)
GO
CREATE TABLE Makaleler
(
	ID int IDENTITY(1,1),
	Kategori_ID int,
	Yazar_ID int,
	Baslik nvarchar(250),
	Ozet nvarchar(500),
	Icerik ntext,
<<<<<<< Updated upstream
	EklemeTarihi time,
=======
	EklemeTarihi date,
>>>>>>> Stashed changes
	KapakResim nvarchar(50),
	GoruntulemeSayi int,
	BegeniSayi int,
	Durum bit,
	CONSTRAINT pk_Makale PRIMARY KEY(ID),
<<<<<<< Updated upstream
	CONSTRAINT fk_MakaleKategori FOREIGN KEY(Kategori_ID) REFERENCES Kategoriler(ID),
=======
	CONSTRAINT fk_makaleKategori FOREIGN KEY(Kategori_ID) REFERENCES Kategoriler(ID),
>>>>>>> Stashed changes
	CONSTRAINT fk_MakaleYazar FOREIGN KEY(Yazar_ID) REFERENCES Yoneticiler(ID),
)
GO
CREATE TABLE Uyeler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50),
	Soyisim nvarchar(50),
	Mail nvarchar(100),
	KullaniciAdi nvarchar(20),
	Sifre nvarchar(20),
<<<<<<< Updated upstream
	UyelikTarihi time,
	Durum bit,  
	Silinmiþ bit,
	CONSTRAINT pk_Uye PRIMARY KEY(ID)
	
=======
	UyelikTarihi date,
	Durum bit,
	Silinmis bit,
	CONSTRAINT pk_Uye PRIMARY KEY(ID)
>>>>>>> Stashed changes
)
GO
CREATE TABLE Yorumlar
(
	ID int IDENTITY(1,1),
	Makale_ID int,
	Uye_ID int,
	Icerik nvarchar(1000),
	EklemeTarihi datetime,
	Onaylayan_ID int,
	OnayTarihi datetime,
	Durum bit,
	CONSTRAINT pk_Yorum PRIMARY KEY(ID),
	CONSTRAINT fk_MakaleYorum FOREIGN KEY(Makale_ID) REFERENCES Makaleler(ID),
	CONSTRAINT fk_UyeYorum FOREIGN KEY(Uye_ID) REFERENCES Uyeler(ID),
	CONSTRAINT fk_YoneticiYorum FOREIGN KEY(Onaylayan_ID) REFERENCES Yoneticiler(ID)
)
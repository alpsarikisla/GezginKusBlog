CREATE DATABASE GezginKus_DB
GO
USE GezginKus_DB
GO
CREATE TABLE YoneticiTurleri
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50),
	CONSTRAINT pk_YoneticiTur PRIMARY KEY(ID)

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
	Durum bit,   --IsActive de kullanabilirdik
	Silinmiþ bit, --IsDeleted de olurdu
	--SOFT VE HARD DELETE FARKLIDIR
	CONSTRAINT pk_Yonetici PRIMARY KEY(ID),
	CONSTRAINT fk_YoneticiYoneticiTur FOREIGN KEY(YoneticiTur_ID) REFERENCES YoneticiTurleri(ID)

)
GO
CREATE TABLE Kategoriler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50),
	Aciklama ntext,
	Durum bit,
	CONSTRAINT pk_Kategori PRIMARY KEY(ID)

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
	EklemeTarihi time,
	KapakResim nvarchar(50),
	GoruntulemeSayi int,
	BegeniSayi int,
	Durum bit,
	CONSTRAINT pk_Makale PRIMARY KEY(ID),
	CONSTRAINT fk_MakaleKategori FOREIGN KEY(Kategori_ID) REFERENCES Kategoriler(ID),
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
	UyelikTarihi time,
	Durum bit,  
	Silinmiþ bit,
	CONSTRAINT pk_Uye PRIMARY KEY(ID)
	
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
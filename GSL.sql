CREATE DATABASE GSL_DB
GO
USE GSL_DB
GO
CREATE TABLE YoneticiTurler
(
  ID int IDENTITY(1,1),
  isim nvarchar(50) NOT NULL,
  CONSTRAINT pk_yoneticiTur PRIMARY KEY(ID)
)
INSERT INTO YoneticiTurler(isim) VALUES('Admin')
INSERT INTO YoneticiTurler(isim) VALUES('Moderatör')
GO
CREATE TABLE Yoneticiler
(
ID int IDENTITY(1,1),
YoneticiTurID int,
ad nvarchar(50),
soyad nvarchar(75),
mail nvarchar(120),
sifre nvarchar(20),
Durum bit,
CONSTRAINT pk_yonetici PRIMARY KEY(ID),
CONSTRAINT fk_yoneticiYoneticiTur FOREIGN KEY(YoneticiTurID) REFERENCES YoneticiTurler(ID) 
)
GO
CREATE TABLE Bolumler
(
ID int IDENTITY(1,1),
isim nvarchar(50),
CONSTRAINT pk_bolum PRIMARY KEY(ID)
)
GO
CREATE TABLE Kategoriler
(
ID int IDENTITY(1,1),
BolumID int,
Isim nvarchar(50),
CONSTRAINT pk_kategori PRIMARY KEY(ID),
CONSTRAINT fk_kategoriBolum FOREIGN KEY(BolumID) REFERENCES Bolumler(ID)
)
GO
CREATE TABLE Sehirler
(
ID int IDENTITY(1,1),
AD  nvarchar(20),
CONSTRAINT pk_sehir PRIMARY KEY(ID)
)
GO
CREATE TABLE Okullar
(
ID int IDENTITY(1,1),
isim nvarchar(100),
BolumID int,
SehirID int,
CONSTRAINT pk_okul PRIMARY KEY(ID),
CONSTRAINT fk_okulBolum FOREIGN KEY(BolumID) REFERENCES Bolumler(ID),
CONSTRAINT fk_sehir  FOREIGN KEY(SehirID) REFERENCES Sehirler(ID)
)
GO
CREATE TABLE Ogrenciler
(
ID int IDENTITY(1,1),
KategoriID int,
BolumID int,
OkulID int,
ad nvarchar(50),
soyad nvarchar(75),
nickname nvarchar(50),
mail nvarchar(120),
sifre nvarchar(20),
uyelikTarihi datetime,
Durum bit,
CONSTRAINT pk_ogrenci PRIMARY KEY(ID),
CONSTRAINT fk_ogrenciBolum FOREIGN KEY(BolumID) REFERENCES Bolumler(ID),
CONSTRAINT fk_ogrenciOkul FOREIGN KEY(OkulID) REFERENCES Okullar(ID),
CONSTRAINT fk_ogrenciKategori FOREIGN KEY(KategoriID) REFERENCES Kategoriler(ID)
)
GO
CREATE TABLE Projeler
(
ID int IDENTITY(20,1),
BolumID int,
KategoriID int,
YazarID int,
SehirID int,
OkulID int,
Baslik nvarchar(50),
Ozet nvarchar(500),
Batarih nvarchar(20),
BiTarih nvarchar(20),
KapakResim nvarchar(75),
Sart nvarchar(MAX),
Icerik nvarchar(MAX),
Katilimcilar nvarchar(MAX),
iletiþim nvarchar(MAX),
EklemeTarihi datetime,
Durum bit,
CONSTRAINT pk_proje PRIMARY KEY(ID),
CONSTRAINT fk_projeBolum FOREIGN KEY(BolumID) REFERENCES Bolumler(ID),
CONSTRAINT fk_projeKategori FOREIGN KEY(KategoriID) REFERENCES Kategoriler(ID),
CONSTRAINT fk_projeOgrenci FOREIGN KEY(YazarID) REFERENCES Ogrenciler(ID),
CONSTRAINT fk_projeSehir FOREIGN KEY(SehirID) REFERENCES Sehirler(ID),
CONSTRAINT fk_projeOkul FOREIGN KEY(OkulID) REFERENCES Okullar(ID)
)
GO
CREATE TABLE Yorumlar
(
ID int IDENTITY(1,1),
OgrenciID int,
ProjeID int,
Icerik nvarchar(500),
YorumTarih datetime,
OnayDurum bit,
CONSTRAINT pk_yorum PRIMARY KEY(ID),
CONSTRAINT fk_yorumOgrenci FOREIGN KEY(OgrenciID) REFERENCES Ogrenciler(ID),
CONSTRAINT fk_yorumProje FOREIGN KEY(ProjeID) REFERENCES Projeler(ID)
)




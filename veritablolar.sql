Insert Into Admin(AdminTc,Sifre) values ('12946095804','123456');
Insert Into Yay�nevi(Yay�neviAdi) values('k');
Drop Table Uyeler;
Delete From Uyeler;
Drop table kitaplar;

Insert Into Admin(AdminTc,Sifre) values ('1','1');
Insert Into Oduncalma(kitap�d,odunctarihi,�adetarihi) values(22,'19-NOV-2021',NULL);
Insert Into Yay�nevi(Yay�neviAdi) values('Beyaz');
Insert Into Yazar(YazarAdi) values('Peyami Safa');
Insert Into Kitaplar(KitapAd�,YazarId,Yay�neviId,SayfaNumaras�) values('Kuyucakl� Yusuf','1','2',235);
Insert Into Uyeler(UyeTc,UyeAd,UyeSoyad,UyeCinsiyet,UyeTel,UyeSifre) values('1','Eren','Karaymir','Male','2222','1');

Update ODUNCALMA Set IADETARIHI = odunctarihi + 15 where ISLEMID = 42;

Create Table Admin(
AdminTc varchar(20),
Sifre varchar(20)
);

Create Table Uyeler(
UyeId number generated always as IDENTITY,
UyeTc varchar(20),
UyeAd varchar(20),
UyeSoyad varchar(20),
UyeCinsiyet varchar(10),
UyeTel varchar(15),
UyeSifre varchar(20),
CONSTRAINT PK_uye PRIMARY KEY(UyeId)
);

Create Table Yazar(
YazarId number generated always as IDENTITY,
YazarAdi varchar(20),
CONSTRAINT PK_yazar PRIMARY KEY(YazarId)
);

Create Table Yay�nevi(
Yay�neviId number generated always as IDENTITY,
Yay�neviAdi varchar(20),
CONSTRAINT PK_yay�nevi PRIMARY KEY(Yay�neviId)
);

Create Table Kitaplar(
KitapId number generated always as IDENTITY,
KitapAd� varchar(20),
YazarId number(4),
Yay�neviId number(4),
SayfaNumaras� Decimal(10),
CONSTRAINT PK_kitap PRIMARY KEY(KitapId),
CONSTRAINT fk_YazarId FOREIGN KEY (YazarId) REFERENCES Yazar(YazarId),
CONSTRAINT fk_Yay�neviId FOREIGN KEY (YAYINEVIID) REFERENCES YAYINEVI(YAYINEVIID));

Create Table OduncAlma(
IslemId number generated always as IDENTITY,
UyeId number(4),
KitapId number(4),
OduncTarihi Date,
IadeTarihi Date,
CONSTRAINT PK_islem PRIMARY KEY(IslemId),
CONSTRAINT fk_UyeId FOREIGN KEY (UyeId) REFERENCES Uyeler(UyeId),
CONSTRAINT fk_KitapId FOREIGN KEY (KitapId) REFERENCES Kitaplar(KitapId)
);

Alter Table Kitaplar(
KitapId number generated always as IDENTITY,
KitapAd� varchar(20),
YazarId number(4),
Yay�neviId number(4),
SayfaNumaras� Decimal(10),
CONSTRAINT PK_kitap PRIMARY KEY(KitapId),
CONSTRAINT fk_YazarId FOREIGN KEY (YazarId) REFERENCES Yazar(YazarId) ON DELETE CASCADE,
CONSTRAINT fk_Yay�neviId FOREIGN KEY (YAYINEVIID) REFERENCES YAYINEVI(YAYINEVIID));

Insert Into OduncAlma(UyeId,KitapId,OduncTarihi,IadeTarihi) Values (1,22,'2021-01-02','2021-02-02');
Drop Table KitapIslemleri;
SELECT k.kitapId,k.kitapAdi,yay.YAYINEVIADI,yaz.YazarAdi,k.SayfaNumaras� FROM Kitaplar k,YAYINEVI yay,Yazar yaz where k.yazarId = yaz.yazarId and yay.YAYINEVIID = yay.YAYINEVIID;
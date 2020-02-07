CREATE TABLE [dbo].[Kullanicilar] (
    [kullaniciadi] NVARCHAR (20) NOT NULL,
    [sifre]        NVARCHAR (20) NOT NULL,
    [yetki]        NVARCHAR (20) NOT NULL,
    [tcno]         NVARCHAR(11) NOT NULL,
    [ad]           NVARCHAR (20) NOT NULL,
    [soyad]        NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([kullaniciadi] ASC)
);


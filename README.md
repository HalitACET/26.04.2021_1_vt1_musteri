# Müşteri Yönetim Uygulaması

Müşteri kayıt, sorgulama ve adres bilgilerini yönetmek için geliştirilmiş Windows Forms masaüstü uygulaması. SQL Server veritabanı ile çalışır; il seçimine bağlı kademeli ilçe dropdown'ı içerir.

## Öne Çıkanlar

- **İlişkisel veritabanı tasarımı**: Müşteri ve adres bilgileri ayrı tablolarda (`TblMusteri`, `TblAdres`) tutulur; INNER JOIN ile sorgulanır
- **Kademeli dropdown**: İl seçildiğinde ilçe listesi otomatik olarak veritabanından filtrelenerek güncellenir
- **Parametre doğrulama**: SQL komutları parametre (`SqlParameter`) ile oluşturulur, doğrudan string birleştirme kullanılmaz

## Tech Stack

![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET_Framework_4.6.1-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=flat-square&logo=microsoftsqlserver&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows_Forms-0078D4?style=flat-square&logo=windows&logoColor=white)

## Kurulum

**Gereksinimler:** Visual Studio, .NET Framework 4.6.1, SQL Server Express

1. SQL Server'da `BeyazEsyaDB` adında bir veritabanı oluştur.
2. Aşağıdaki tabloları oluştur:

```sql
CREATE TABLE Iller (IlId INT PRIMARY KEY IDENTITY, Il NVARCHAR(50));
CREATE TABLE Ilceler (IlceId INT PRIMARY KEY IDENTITY, IlID INT, Ilce NVARCHAR(50));
CREATE TABLE TblMusteri (Kod INT PRIMARY KEY IDENTITY, Ad NVARCHAR(50), Soyad NVARCHAR(50), Cinsiyet NVARCHAR(10), Dyer NVARCHAR(50), Dtar DATE);
CREATE TABLE TblAdres (MusteriKod INT, IlKod INT, IlceKod INT, Semt NVARCHAR(100));
```

3. [Vt.cs](Vt.cs) dosyasındaki bağlantı dizesini kendi sunucu adınla güncelle:

```csharp
// Vt.cs
con = new SqlConnection(@"Server=SUNUCU_ADIN\SQLEXPRESS;Database=BeyazEsyaDB;Integrated Security=True;");
```

4. Projeyi Visual Studio'da aç ve çalıştır (`F5`).

## Kullanım

| İşlem | Açıklama |
|---|---|
| **Kaydet** | Ad, soyad, cinsiyet, doğum bilgileri ve adres doldurulup kaydedilir |
| **Bul** | Ad ve soyad ile müşteri aranır, adres bilgileri otomatik doldurulur |
| **Sil** | Seçili müşteri kaydı silinir |

## Veritabanı Şeması

```
Iller ──< Ilceler
  │
  └──> TblAdres <── TblMusteri
```

`TblAdres`, müşteri ile il/ilçe tablolarını birleştiren köprü tablodur.

## Öğrendiklerim

- ADO.NET ile SQL Server bağlantısı ve CRUD işlemleri
- `SqlConnection`, `SqlCommand`, `SqlDataReader` kullanımı
- İlişkisel tablo tasarımı ve JOIN sorguları
- Windows Forms ile olaya dayalı (event-driven) programlama
- Kademeli (cascade) dropdown implementasyonu

# CoreDemo 🎯

**CoreDemo**, ASP.NET Core (özellikle .NET 6/7/8) kullanılarak geliştirilmiş temel konseptleri içeren öğretici bir projedir.

---

## 🚀 Teknolojiler & Yaklaşımlar

- ASP.NET Core 6/7/8
- Entity Framework Core (Code‑First)
- Repository & Unit of Work pattern
- AutoMapper ile DTO dönüşümleri
- Dependency Injection (DI)
- FluentValidation veya manuel model doğrulama (varsa)
- RESTful Web API mimarisi
- JSON serileştirme (`System.Text.Json`)
- Swagger/OpenAPI (varsa)

---

## 🎯 Amaç & Kullanım

CoreDemo; yeni başlayanlar için ASP.NET Core temelleri, katmanlı mimari yapısı, clean code anlayışı ve basit CRUD işlemleri konularını örneklerle öğretmeyi hedefler:

- Entity tanımları ve veri modele aktarımı
- EF Core ile veritabanı işlemleri
- Service sınıfları (iş mantığı)
- DTO’lar ve mapping
- API endpoint’leri (GET, POST, PUT, DELETE)
- Hata yönetimi ve sonuç formatlama

---

## 🛠 Kurulum & Çalıştırma

Adım adım:

```bash
git clone https://github.com/ulasaktas07/CoreDemo.git
cd CoreDemo

# Paketleri yükle ve projeyi derle
dotnet restore
dotnet build

# Migrations ekleyip veritabanını oluştur (ilk seferlik)
cd DataAccess
dotnet ef migrations add InitialCreate
dotnet ef database update
cd ..

# Uygulamayı çalıştır
dotnet run
Clean Architecture, katmanlı geliştirme prensipleri ve modern .NET web uygulaması kalıplarına hızlı giriş niteliğindedir.

---


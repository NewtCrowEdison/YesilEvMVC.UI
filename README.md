# YesilEvMVC.UI

YesilEvMVC, kullanıcıların ürün içeriklerini detaylı şekilde inceleyebileceği, alerjen içeriklere karşı önlem alabileceği, sağlıklı ürünleri favorilerine ekleyebileceği ASP.NET Core MVC ile geliştirilmiş bir web uygulamasıdır.

## 🚀 Projenin Amacı

Alerjen içeriklere duyarlı bireylerin veya sağlıklı yaşamla ilgilenen kullanıcıların;
- Ürünleri detaylı şekilde incelemesini,
- İçerik filtrelemesi yapmasını,
- Barkod ile ürün taraması gerçekleştirmesini,
- Alerjik içerikleri kara listeye almasını,
- Güvendiği ürünleri favorilere eklemesini sağlar.

## 🧰 Kullanılan Teknolojiler ve Paketler

- ASP.NET Core MVC
- Entity Framework Core
- ASP.NET Identity
- Serilog Logging
- Cookie Authentication
- Custom Middleware
- Bootstrap 5
- MSSQL

Temel Özellikler

🔍 Ürün arama (isimle veya barkodla)

🧾 Ürün içeriklerinin detaylı görüntülenmesi

🖤 Favori ürün listesi oluşturma

⛔ Kara liste oluşturma (alerjen içerikler)

🧪 Kategori, üretici ve içerik filtreleme

📸 Ürünlere ön ve arka yüz resim yükleme

👥 Role-based yetkilendirme

📊 Admin paneli üzerinden yönetim

🧑‍💻 Kullanıcı Rolleri

User : Ürünleri ve içerikleri görüntüleyebilir
Premium : Favorilere ve kara listeye ekleyebilir, ürün önerebilir
Admin : Ürün, kategori, üretici ve içerik ekleyebilir; tüm sistemi yönetebilir

🔐 Not: Kayıt ekranında kullanıcı rolü seçimlidir (geçici test amaçlıdır, ileride geliştirilecektir).

🛠️ Kurulum
Bu repoyu klonlayın:

git clone https://github.com/kullaniciadi/YesilEvMVC.git
Visual Studio veya Rider ile açın.

appsettings.json
ConnectionStringinizi ayarlayın.(DefaultConnection adında kalmalı)

Aşağıdaki komutla veritabanını oluşturun:

powershell
Update-Database
Uygulamayı başlatın ve tarayıcınızdan görüntüleyin.

👥 Demo Kullanıcılar

Admin	Kullanıcı Email : admin@yesilev.com	 Şifre : 123QWEasd.
Premium	Kullanıcı Email :	premium@yesilev.com Şifre : 123QWEasd.
User Kullanıcı Email : user@yesilev.com Şifre : 123QWEasd.

⚠️ Not: Premium ve User kullanıcılarının bazı fonksiyonları henüz tamamlanmamıştır.

📌 Gelecek Geliştirmeler

Rol seçimlerinin admin tarafından yönetilmesi

User ve Premium kullanıcı panellerinin tam işlevsellik kazanması

Ürün yorum sistemi

Mobil uyumlu tasarım

🪪 Lisans
Bu proje kişisel geliştirme amacıyla yapılmıştır. Dilerseniz kaynak kodu inceleyebilir, katkıda bulunabilirsiniz.

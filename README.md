# E-Commerce-Shop

- Bu proje basit E-Ticaret uygulaması içermektedir. 
- Projemin asıl amacı katmanlı mimarinin bir web sitesi arka planını nasıl oluşturduğunu gösterebilmektir.
- Login, Shopping Card, Order ve CRUD operasyonları genel çerçevede ele alınmıştır.

PROJE ÇALIŞTIRILMADAN ÖNCE YAPILACAKLAR:

- Proje de EF Core ORM ve Identity Core Package olarak eklenmiştir. Sürümler .csproj dosyalarından incelenebilir.
- Bu kısımdan sonra projede Database Connection String değerlerini web sitesi için WebUI projesi altındaki appsettings.json dosyasından, WebAPI için ilgili projenin appsettings.json dosyasından değiştirebilirsiniz.
- Migration komutları: (projelerin ana dizininde) 
						* dotnet ef migrations add InitialCreate -s e-commerce-shop.webui -c ShopContext -p e-commerce-shop.dataaccess
						* dotnet ef migrations add InitialIdentity -s e-commerce-shop.webui -c ApplicationContext -p e-commerce-shop.webui
- Web projesinde View kısımları için Bootstrap ve Jquery validation dosyaları ilgili dizinde npm install komutu ile eklenmelidir.  

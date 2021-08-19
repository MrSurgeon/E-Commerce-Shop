# E-Commerce-Shop

- Bu proje basit E-Ticaret uygulamasý içermektedir. 
- Projemin asýl amacý katmanlý mimarinin bir web sitesi arka planýný nasýl oluþturduðunu gösterebilmektir.
- Login, Shopping Card, Order ve CRUD operasyonlarý genel çerçevede ele alýnmýþtýr.

PROJE ÇALIÞTIRILMADAN ÖNCE YAPILACAKLAR:

- Proje de EF Core ORM ve Identity Core Package olarak eklenmiþtir. Sürümler .csproj dosyalarýndan incelenebilir.
- Bu kýsýmdan sonra projede Database Connection String deðerlerini web sitesi için WebUI projesi altýndaki appsettings.json dosyasýndan, WebAPI için ilgili projenin appsettings.json dosyasýndan deðiþtirebilirsiniz.
- Migration komutlarý: (projelerin ana dizininde) 
						dotnet ef migrations add InitialCreate -s e-commerce-shop.webui -c ShopContext -p e-commerce-shop.dataaccess
						dotnet ef migrations add InitialIdentity -s e-commerce-shop.webui -c ApplicationContext -p e-commerce-shop.webui
- Web projesinde View kýsýmlarý için Bootstrap ve Jquery validation dosyalarý ilgili dizinde npm install komutu ile eklenmelidir.  

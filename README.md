# E-Commerce-Shop

- Bu proje basit E-Ticaret uygulamas� i�ermektedir. 
- Projemin as�l amac� katmanl� mimarinin bir web sitesi arka plan�n� nas�l olu�turdu�unu g�sterebilmektir.
- Login, Shopping Card, Order ve CRUD operasyonlar� genel �er�evede ele al�nm��t�r.

PROJE �ALI�TIRILMADAN �NCE YAPILACAKLAR:

- Proje de EF Core ORM ve Identity Core Package olarak eklenmi�tir. S�r�mler .csproj dosyalar�ndan incelenebilir.
- Bu k�s�mdan sonra projede Database Connection String de�erlerini web sitesi i�in WebUI projesi alt�ndaki appsettings.json dosyas�ndan, WebAPI i�in ilgili projenin appsettings.json dosyas�ndan de�i�tirebilirsiniz.
- Migration komutlar�: (projelerin ana dizininde) 
						dotnet ef migrations add InitialCreate -s e-commerce-shop.webui -c ShopContext -p e-commerce-shop.dataaccess
						dotnet ef migrations add InitialIdentity -s e-commerce-shop.webui -c ApplicationContext -p e-commerce-shop.webui
- Web projesinde View k�s�mlar� i�in Bootstrap ve Jquery validation dosyalar� ilgili dizinde npm install komutu ile eklenmelidir.  

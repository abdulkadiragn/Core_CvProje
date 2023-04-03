# Core_CvProje
Proje kişisel bilgilerin yayınlandığı ve bu bilgilerin anlık olarak değiştirilebilmesini sağlayan bir web sitesi olarak gözükmektedir. frontend kısmı hazır olarak 
kullanılmış, backend kısmı .Net Core ile geliştirilmiş, Veri tabanı olarak MsSQL kullanılmıştır.
Projenin 3 temel paneli bulunmaktadır.
Default panelinde kişisel bilgiler bulunmaktadır.
Yazar panelinde sisteme kaydolup bu sistem üzerinden diğer üyeler ile haberleşecek, üyelerin duyuruları 
görebilecekleri ve üye olarak yöneticiye mesaj atabilecekleri bir panel oluşturuldu. 
Admin panelinde ise default sayfasında bulunan bilgilerin veritabanından çekilmesi ve değiştirilebilmesi, 
yazarlardan ve ana sayfadan gelen mesajların görüntülenebilmesi, Ajax ile veri çekme gibi özellikler 
bulunmaktadır.
Proje’de Asp.Net Core 5.0, EntityFramework Core, Repository Desing Pattern, Unit of Work, Fluent 
Validation, Restful Api, MVC, Identity, rolleme, Code-First, Ajax teknolojileri kullanıldı. 

# ArticleApi

-Veri tabanı kurulumu için sadece Core.Service uygulama içerisindeki appsettings dosyasında
ConnectionString altındaki HtosunLocal içerisndeki Server alanına kendi Server adınızı yazmanız 
yeterli uygulama Db i kendisi kuracaktır.Uygulamayı kurulurken default olarak oluşturulacak
userdan token almanız gerekmektedir.(Username:Digiturk Password:Qwer!234)

-Uygulamada aktif olarak Repository pattern ve Mvc patternlerini kullandım

-.Net üzerinde daha önceden de Api tecrübem olmuştu

-Daha fazla vaktim olsaydı

1)Dto olan kısımlar için Crud işlemleri için ayrı veri yapıları hazırlardım

2)Loglama için belki Nlog kullanılabilirdi.

3)Article modeli için Api Controller larında direk servisleri kullanmak yerine Business katmanında Manager içerisinde repoya ulaşmayı sağlayabilirdim

4)Article içerisine eklediğim Comment kısmı içinde yapı oluştururdum

5)User oluşturmak içinde yapı ekleyebilirdim

Api Dökümantasyon

Listeleme
Get https://localhost:44358/api/Articles/GetArticles

Id üzerinden çekme
Get https://localhost:44358/api/Articles/GetById/{id}

Başlık üzerinden arama 
Get https://localhost:44358/api/Articles/SearchInTitle/{title}
 
İçerik üzerinden arama 
Get https://localhost:44358/api/Articles/SearchInContent/{content}

Makale ekleme
Post https://localhost:44358/api/Articles/Add

{
    "title": "başlık içeriği",
    "content": "makale içeriği",
}

Makale güncelleme
Post https://localhost:44358/api/Articles/Update

{
    "Id":{id}
    "title": "başlık içeriği",
    "content": "makale içeriği",
}

Makale silme
Post https://localhost:44358/api/Articles/Delete/{id}


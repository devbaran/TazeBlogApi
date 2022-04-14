# Blog Api Projesi

Bu uygulama staj programına katılabilme fırsatı için verilen bir projedir. Uygulamada istenen önemli noktalar Dapper kullanılması, katmanlı mimari(n-tier architecture) ve generic controller yapısının bulunmasıdır. 

Projemizde makaleler ve kategori varlıklarımızın temel CRUD işlemlerini Restful API kullanarak generic bir controller üzerinden gerçekleştirmekteyiz.

Canlı demo için ```https://blogapitest.azurewebsites.net``` adresine Postman veya farklı bir uygulama yardımıyla istekler gönderilebilir.

## Kullanılan Paketler/Teknolojiler
Uygulama .NET 6 ile geliştirildi. Veritabanı olarak MSSQL kullanıldı.

Uygulama içerisinde bulunan paketler: 

- Autofac, Autofac.DependencyInjection
- Dapper
- FluentValidation
- Mapster


## Kurulum

Web Uygulamamızın kurulumu oldukça pratiktir. Bütün süreçler Microsoft Azure kullanılarak yönetilmiştir.

### Microsoft Azure Web App ve Database Deploy/Kurulumları
#### • Web App Deploy
Öncelikle Azure tarafında bir App Service/Web App oluşturulmalı. Publish yöntemi olarak 'code' seçilmeli, runtime stack ise proje .NET 6 ile geliştirildiği için '.NET 6 (LTS)' olarak belirlenmeli. 

Diğer kalan konfigurasyonlar(operating system, region, app service plan) isteğe bağlı olarak değişebilir. Bu projede biz temel ücretsiz bir servis planı kullandık.

Konfigurasyonlar tamamlandıktan sonra Web App deploy edilmeli.

#### • Database Deploy

Uygulamamızın veritabanı için yine Azure tarafında SQL Database kurulmalı (elbette farklı database'ler bağlanabilir, zorunlu değil). Burada kurulumda ekstra gerekli bir konfigurasyon mevcut değil. Ek olarak database kısmında ücretsiz bir plan yok, projenin küçük olması sebebiyle en basit SQL planı fazlasıyla yeterli olacaktır. Ardından deploy işlemi başlatılmalıdır.

Deploy tamamlandıktan sonra eğer SSMS kullanacaksanız, SSMS üzerinden erişim sağlayabilmek için oluşturduğumuz database üzerinde firewall ayarlanmalıdır. Set server firewall kısmına girerek durumu etkin hale getiriyoruz ve Add client IP kısmından mevcut IP değerimizi ekliyoruz. Ardından SSMS üzerinden erişim sağlanabilecektir.

Bu aşamalardan sonra Azure tarafında Database ve Web App deploy işlemleri tamamlanmış olacaktır. Mevcut proje ve eğer istenirse localde bulunan database artık publish edilebilir.

### Proje ve Database Publish İşlemleri

#### • Web App/Proje Publish

Öncelikle Azure tarafında bulunan Database'in connection string'i projemize entegre edilmelidir. Tamamen hazır olan projemiz connection string eklendikten sonra publish edilebilir. Uygulamamızı publish etmek için Visual Studio üzerinde projemizi açıyoruz.

Projenin Web App katmanı üzerinden sağ tıklayarak Publish kısmına geçiyoruz. Öncelikle bir Publish profili yaratıyoruz, Azure seçeneği ile devam ediyoruz. Burada gelen sorular ve seçenekler üst kısımda deploy yaparken verilen konfigurasyonlarla aynı olmalıdır. Ardından uygulamamız Azure'a publish edilmeye hazırdır. Butona tıklayarak publish edilebilir. 

#### • Database Publish (opsiyonel)

Database publish edilmek isteniyorsa, en kolay yolu SSMS üzerinden olacaktır. SSMS ile local bağlantı kurduktan sonra projemizin database'ine sağ tıklayarak Tasks > Deploy Database to Microsoft Azure SQL Database seçeneğine tıklanmalıdır. Bu kısımda bizden Server connection bilgisi istenecektir, veritabanımızı Azure' a deploy ederken oluşturduğumuz login user ve password ile erişim sağlamamız gerekiyor. Erişimi sağladıktan sonra tek tıklama ile localde bulunan database'i Azure'a aktarmış olacaksınız.

Bütün bu süreçlerin ardından uygulama tamamen çalışıyor halde olacaktır.



## Nasıl Kullanılır

API istekleri için istek linklerini bu kısımda belirtiyor olacağız. Örnekler 'articles' üzerinden verilmiştir. 

Ayrıca 'articles' yerine 'categories' yazılarak kategoriler için aynı sorgular elde edilebilir.

#### Örnek Yapılar


```bash
https://blogapitest.azurewebsites.net/api/articles/getall
```

| Domain        | Endpoint       | Request Method  |
| -------------  | -------------  | --------------- |
| https://blogapitest.azurewebsites.net/        | api/articles/**GetAll**        | HttpGet         | 
| https://blogapitest.azurewebsites.net/       | api/articles/**Get/{id}**      |HttpGet       | 
| https://blogapitest.azurewebsites.net/        | api/articles/**Add**           | HttpPost         | 
| https://blogapitest.azurewebsites.net/        | api/articles/**Update**        | HttpPut         | 
| https://blogapitest.azurewebsites.net/        | api/articles/**Delete**        | HttpDelete         | 




Her isteğin ardından Json olarak bir veri dönecektir.
Bu Json içerisinde mutlaka success ve message verileri de bulunacaktır. Bu değerler dikkate alınarak varsa hatalar belirlenebilir veya success durumu sorgulanabilir.

#### İstek Örneği ve Geri Dönüş Değerleri
```/api/Articles/Get/1002```

```json
#Dönen Veriler.
{
    "data": {
        "id": 1002,
        "categoryId": 1,
        "title": "Kararlılık",
        "content": "Kararlı olmak ve sürekli çalışıp üretmek, bizleri başarıya götüren tek yol olacaktır.",
        "creationDate": "2022-04-12T00:00:00",
        "status": true
    },
    "success": true,
    "message": null
}
```

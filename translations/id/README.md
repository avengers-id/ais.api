# dotnet-api-boilerplate
<p align="center">
  <a href="../en/README.md">English</a> |
  <span>Bahasa Indonesia</span>
</p>

Sebuah proyek boilerplate / template WebApi ``.Net 9.0``. MediatR, Swagger, ~~AutoMapper~~ Mapster, Serilog, dan banyak lagi telah diterapkan.

[![Build](https://github.com/yanpitangui/dotnet-api-boilerplate/actions/workflows/build.yml/badge.svg)](https://github.com/yanpitangui/dotnet-api-boilerplate/actions/workflows/build.yml)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=yanpitangui_dotnet-api-boilerplate&metric=coverage)](https://sonarcloud.io/dashboard?id=yanpitangui_dotnet-api-boilerplate)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=yanpitangui_dotnet-api-boilerplate&metric=alert_status)](https://sonarcloud.io/dashboard?id=yanpitangui_dotnet-api-boilerplate)

Tujuan dari proyek ini adalah menjadi titik awal untuk WebApi .Net Anda dengan menerapkan pola dan teknologi yang paling umum digunakan untuk API restful di .Net, sehingga mempermudah pekerjaan Anda.

# Cara menjalankan
- Gunakan template ini (GitHub) atau clone/unduh ke lingkungan lokal Anda.
- Unduh .Net SDK terbaru dan Visual Studio/Code/Rider.

## Mandiri
1. Anda memerlukan instance Postgres yang sedang berjalan dengan migrasi yang sesuai sudah diinisialisasi.
        - Anda bisa menjalankan hanya basis data di docker. Untuk itu, jalankan perintah berikut: ``docker-compose up -d db-server``. Dengan begitu, aplikasi akan dapat menjangkau container server basis data.
2. Masuk ke folder src/Api dan jalankan ``dotnet run``, atau di Visual Studio setel proyek API sebagai startup dan jalankan sebagai console/docker/IIS.
3. Kunjungi http://localhost:7122/api-docs atau https://localhost:7123/api-docs untuk mengakses swagger aplikasi.

## Docker
1. Jalankan ``docker-compose up -d`` di direktori root, atau di Visual Studio setel proyek docker-compose sebagai startup dan jalankan. Ini akan memulai aplikasi dan basis data.
 - 1. Untuk docker-compose, Anda harus menjalankan perintah ini di folder root: ``dotnet dev-certs https -ep https/aspnetapp.pfx -p yourpassword``
                Ganti "yourpassword" dengan kata lain pada perintah ini dan di file docker-compose.override.yml.
Perintah ini membuat sertifikat https.
2. Kunjungi http://localhost:7122/api-docs atau https://localhost:7123/api-docs untuk mengakses swagger aplikasi.

## Menjalankan pengujian
**Penting**: Anda perlu memastikan docker terpasang dan berjalan. Pengujian integrasi akan meluncurkan container Postgres dan menggunakannya untuk menguji API.

Di folder root, jalankan ``dotnet test``. Perintah ini akan mencoba menemukan semua proyek pengujian yang terkait dengan file sln.
Jika Anda menggunakan Visual Studio, Anda juga bisa membuka menu Test dan membuka Test Explorer, tempat Anda dapat melihat semua pengujian dan menjalankan semuanya atau salah satunya saja.

## Autentikasi
Dalam proyek ini, beberapa rute memerlukan autentikasi/otorisasi. Untuk itu, Anda harus menggunakan rute ``api/identity/register`` untuk membuat akun.
Setelah itu, Anda dapat masuk menggunakan ``/api/identity/login`` tanpa menggunakan cookie lalu gunakan accessToken yang diterima pada lock (jika menggunakan swagger) atau melalui header Authorization pada permintaan HTTP.
Untuk informasi selengkapnya, silakan lihat dokumentasi swagger.

# Proyek ini mencakup:
- SwaggerUI
- EntityFramework
- Postgres
- Minimal APIs
- Strongly Typed Ids
- Pengumpulan cakupan pengujian
- ~~AutoMapper~~ Mapster
- MediatR
- Feature slicing
- Serilog dengan pencatatan permintaan dan sink yang mudah dikonfigurasi
- Dependency Injection .Net
- Resource filtering
- Kompresi respons
- Paginasi respons
- CI (Github Actions)
- Autentikasi
- Otorisasi
- Pengujian unit
- Pengujian integrasi dengan testcontainers
- Dukungan container dengan [docker](../../src/Api/dockerfile) dan [docker-compose](../../docker-compose.yml)
- Dukungan OpenTelemetry (dengan OLTP sebagai eksportir default)
- Manajemen paket terpusat NuGet (CPM)

# Struktur proyek
1. Services
        - Folder ini menyimpan API Anda dan proyek apa pun yang mengirimkan data ke pengguna Anda.
     1. Api
                - Ini adalah proyek API utama. Di sinilah semua controller dan inisialisasi untuk API yang akan digunakan berada.
        2. docker-compose
                - Proyek ini ada untuk memungkinkan Anda menjalankan docker-compose dengan Visual Studio. Ia berisi referensi ke file docker-compose dan akan membangun semua dependensi proyek lalu menjalankannya.
2. Application
        -  Folder ini menyimpan semua transformasi data antara API dan lapisan domain Anda. Ia juga berisi logika bisnis Anda.
        1. Auth
                - Folder ini berisi implementasi Session login.
3. Domain
        - Folder ini berisi model bisnis, enum, dan antarmuka umum Anda.
        1. Domain
                - Berisi model bisnis dan enum.
                1. Auth
                        - Folder ini berisi antarmuka Session login.
4. Infra
        - Folder ini berisi semua konfigurasi akses data, konteks basis data, apa pun yang terhubung ke data eksternal.
        1. Infrastructure
                - Proyek ini berisi dbcontext, konfigurasi entitas, dan migrations.


# Mengadopsi ke proyek Anda
1. Hapus/ganti nama semua hal yang terkait dengan "Hero" sesuai kebutuhan Anda.
2. Ganti nama solusi, proyek, namespace, dan ruleset sesuai keperluan Anda.
3. Ubah dockerfile dan docker-compose.yml agar sesuai dengan nama folder/csproj baru Anda.
3. Beri bintang repository ini!

# Migrasi
Untuk menjalankan migrasi di proyek ini, Anda memerlukan tool dotnet-ef.
- Jalankan ``dotnet tool install --global dotnet-ef``
- Sekarang, bergantung pada sistem operasi Anda, perintahnya berbeda:
    1. Untuk Windows: ``dotnet ef migrations add InitialCreate --startup-project .\src\Api\ --project .\src\Infrastructure\``
    2. Untuk Linux/Mac: ``dotnet ef migrations add InitialCreate --startup-project ./src/Api/ --project ./src/Infrastructure/``
# Jika Anda menyukainya, beri bintang
Jika template ini berguna bagi Anda, atau jika Anda mempelajari sesuatu, mohon beri bintang! :star:

# Terima kasih
Proyek ini sangat dipengaruhi oleh https://github.com/lkurzyniec/netcore-boilerplate dan https://github.com/EduardoPires/EquinoxProject. Jika Anda punya waktu, kunjungi repositori ini dan beri mereka bintang juga!

# Tentang
Boilerplate/template ini dikembangkan oleh Yan Pitangui di bawah [lisensi MIT](../../LICENSE).

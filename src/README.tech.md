🧱 0️⃣ Pré-requis (une seule fois)

Vérifie que le SDK est bien installé :
dotnet --version


🧱 1️⃣ Créer le dossier du projet + Git
mkdir dotnet-clean-api-template
cd dotnet-clean-api-template
git init


🧱 2️⃣ Créer le dossier src
mkdir src
cd src


🧱 3️⃣ Créer la solution .NET
dotnet new sln -n MyApp


🧱 4️⃣ Créer les projets
API
dotnet new webapi -n MyApp.Api

Application
dotnet new classlib -n MyApp.Application

Domain
dotnet new classlib -n MyApp.Domain

Infrastructure
dotnet new classlib -n MyApp.Infrastructure


🧱 5️⃣ Ajouter les projets à la solution
dotnet sln add MyApp.Api/MyApp.Api.csproj
dotnet sln add MyApp.Application/MyApp.Application.csproj
dotnet sln add MyApp.Domain/MyApp.Domain.csproj
dotnet sln add MyApp.Infrastructure/MyApp.Infrastructure.csproj


🧱 6️⃣ Ajouter les références entre projets (TRÈS IMPORTANT)
Application → Domain
dotnet add MyApp.Application/MyApp.Application.csproj reference MyApp.Domain/MyApp.Domain.csproj

Infrastructure → Application + Domain
dotnet add MyApp.Infrastructure/MyApp.Infrastructure.csproj reference MyApp.Application/MyApp.Application.csproj
dotnet add MyApp.Infrastructure/MyApp.Infrastructure.csproj reference MyApp.Domain/MyApp.Domain.csproj

API → Application + Infrastructure
dotnet add MyApp.Api/MyApp.Api.csproj reference MyApp.Application/MyApp.Application.csproj
dotnet add MyApp.Api/MyApp.Api.csproj reference MyApp.Infrastructure/MyApp.Infrastructure.csproj


🧱 7️⃣ Créer les dossiers internes (manuellement ou via commandes)
API
mkdir MyApp.Api/Controllers

Application
mkdir MyApp.Application/DTOs
mkdir MyApp.Application/Interfaces
mkdir MyApp.Application/Services

Domain
mkdir MyApp.Domain/Entities

Infrastructure
mkdir MyApp.Infrastructure/Repositories

🧱 8️⃣ Supprimer les fichiers inutiles
rm MyApp.Application/Class1.cs
rm MyApp.Domain/Class1.cs
rm MyApp.Infrastructure/Class1.cs
rm MyApp.Api/WeatherForecast.cs
rm MyApp.Api/Controllers/WeatherForecastController.cs


(Sous Windows PowerShell, remplace rm par del)

🧱 9️⃣ Mettre le Program.cs minimal (manuel)

👉 Ici tu colles le code que je t’ai donné, pas une commande.


🧱 🔟 Vérifier que tout compile
dotnet clean
dotnet build


🧱 1️⃣1️⃣ Lancer l’API (optionnel)
dotnet run --project MyApp.Api


🧱 1️⃣2️⃣ Revenir à la racine et ajouter .gitignore
cd ..
dotnet new gitignore


🧱 1️⃣3️⃣ Créer le README (manuel)

👉 Crée README.md et mets un texte simple.


🧱 1️⃣4️⃣ Premier commit Git
git status
git add .
git commit -m "Initial clean .NET API template"

🧱 1️⃣5️⃣ Push vers GitHub
git branch -M main
git remote add origin https://github.com/TON_USER/dotnet-clean-api-template.git
git push -u origin main



✅ Checklist finale 

📁 src/

🧩 4 projets : Api / Application / Domain / Infrastructure

🔗 dépendances dans un seul sens

🧠 Controller → Service → Repository

🚫 pas de code inutile



*********AJOUT EF CORE *****************



🎯 Objectif EF Core (clair)

EF Core dans Infrastructure
DbContext propre
Repository EF Core
Configuration simple
In-Memory par défaut (parfait pour test)
SQL Server facilement activable


🧱 1️⃣ Installer les packages EF Core

Depuis src/ :

dotnet add MyApp.Infrastructure package Microsoft.EntityFrameworkCore
dotnet add MyApp.Infrastructure package Microsoft.EntityFrameworkCore.InMemory
dotnet add MyApp.Infrastructure package Microsoft.EntityFrameworkCore.SqlServer
dotnet add MyApp.Infrastructure package Microsoft.EntityFrameworkCore.Tools

🧱 2️⃣ Créer le DbContext

📄 Nouveau fichier
MyApp.Infrastructure/Data/AppDbContext.cs


🧱 3️⃣ Modifier le Repository pour EF Core

📄 MyApp.Infrastructure/Repositories/ProductRepository.cs


🧱 4️⃣ Modifier Program.cs (API)

📄 MyApp.Api/Program.cs


🧱 5️⃣ (Optionnel) Préparer SQL Server (sans l’activer)

📄 MyApp.Api/appsettings.json

Ajoute :

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=MyAppDb;Trusted_Connection=True;"
  }
}

👉 Si un jour on te demande SQL Server :

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


🧱 6️⃣ Vérifier que tout compile

Depuis src/ :

dotnet clean
dotnet build

🧱 7️⃣ Tester rapidement l’API
dotnet run --project MyApp.Api


Puis :

POST /api/products

GET /api/products


⚠️ IMPORTANT : EF Core doit être installé UNIQUEMENT dans Infrastructure
(Clean Architecture respectée)

1️⃣ Va dans le projet Infrastructure

Depuis la racine du repo :

cd src/MyApp.Infrastructure

2️⃣ Installe EF Core (minimum requis)
dotnet add package Microsoft.EntityFrameworkCore

3️⃣ Choisis un provider (OBLIGATOIRE)
👉 Pour un test technique (rapide, sans DB réelle)

👉 RECOMMANDÉ

dotnet add package Microsoft.EntityFrameworkCore.InMemory

OU si tu veux SQL Server (optionnel)
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

**********si version EF Core incompatible***************
1️⃣ Supprimer le mauvais package (sécurité)

Dans src/MyApp.Infrastructure :

dotnet remove package Microsoft.EntityFrameworkCore.InMemory
dotnet remove package Microsoft.EntityFrameworkCore

2️⃣ Installer LES BONNES versions (EF Core 8)
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 8.0.0






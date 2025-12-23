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



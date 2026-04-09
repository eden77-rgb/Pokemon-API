# 🔴 Pokemon API — Pokedex 1G (.NET + Blazor)

Une application complète en **.NET 10** permettant de consulter un **Pokédex de la 1ère génération** avec des fonctionnalités de **recherche** et de **filtrage par type**.

Le projet est structuré selon une **Clean Architecture** et entièrement **containerisé avec Docker** (API, Frontend et base de données).

---

## ✨ Fonctionnalités

- 🔍 **Recherche de Pokémon** (par nom)
- 🧬 **Filtrage par type** (feu, eau, plante, etc.)
- 📖 **Affichage type Pokédex** (liste + détails)
- ⚡ **API REST** pour exposer les données
- 🖥️ **Interface utilisateur en Blazor**

---

## 🧰 Stack technique

### ⚙️ Backend
- 🟣 .NET 10
- 🌐 ASP.NET Core Web API
- 🧠 Clean Architecture
- 🗄️ Microsoft SQL Server 2022

### 🎨 Frontend
- ⚡ Blazor

### 🐳 DevOps / Infra
- 🐳 Docker
- 📦 Docker Compose

---

## 🚀 Installation & Lancement

### ✅ Prérequis
- Docker installé
- Un terminal à la racine du repo

### ▶️ Lancer le projet
Dans le terminal à la racine du projet :
```bash
docker-compose up --build
```

### 🌐 Accès aux services
- API → `http://localhost:5000/api/pokemon`
- Frontend (Blazor) → `http://localhost:8080/`
- Microsoft SQL Server → exposé via Docker

---

## 🗂️ Structure du projet
```text
Pokemon-API/
│
├── ServiceRequestApp.Api/            → Exposition des endpoints + controllers API
├── ServiceRequestApp.Application/    → Cas d’usage & logique métier
├── ServiceRequestApp.Domain/         → Entités principales & règles métier
├── ServiceRequestApp.Infrastructure/ → Accès base de données
├── ServiceRequestApp.Service/        → Services métier
├── ServiceRequestApp.Blazor/         → Interface utilisateur
│
├── .env
├── docker-compose.yml
└── README.md
```

---

## 📑 Structure de l'API
L'application communique avec les points de terminaison suivants :
| Méthode       | Endpoint                   | Description                                                                    |
|---------------|----------------------------|--------------------------------------------------------------------------------|
| **GET**       | `/health`                  | Vérifie l'état interne du serveur                                              |
| **GET**       | `/api/pokemon`             | Récupère tous les pokemons présents dans la DB                                 |
| **GET**       | `/api/pokemon/{id:int}`    | Récupère un pokemon spécifique présent dans la DB                              |
| **POST**      | `/api/pokemon`             | Créer un pokemon et l'ajoute dans la DB                                        |
| **PUT**       | `/api/pokemon/{id:int}`    | Mise à jour d'un pokemon présent dans la DB en fonction de l'id                |
| **DELETE**    | `/api/pokemon/{id:int}`    | Supprime définitivement un pokemon présent dans la DB en fonction de l'id      |

---

## 🐳 Containerisation
Le projet est entièrement dockerisé :
- 🧩 API .NET10
- 🖥️ Frontend Blazor
- 🗄️ Base de données Microsoft SQL Server 

Tout est orchestré via docker-compose pour un lancement rapide.

--- 

## 📸 Screenshots

### 🌍 Tous les Pokémon
<img width="1920" height="1200" alt="image" src="https://github.com/user-attachments/assets/00e188d1-04d7-4f9a-bf5c-ccd3af2fcb21" />

### 🔍 Page détail d’un Pokémon
<img width="1920" height="1200" alt="image" src="https://github.com/user-attachments/assets/9244ad61-69c2-464f-b020-41f31959ef2f" />

### 🧠 Recherche par nom
<img width="1920" height="1200" alt="image" src="https://github.com/user-attachments/assets/c169b64d-bf1e-4ac9-95e1-5420076bf3dc" />

### 🧬 Recherche par type
<img width="1920" height="1200" alt="image" src="https://github.com/user-attachments/assets/f067a402-37d4-40b2-a5a7-13bd9b7a19e9" />

---

## 👥 Auteurs
- **Eden** • [eden77-rgb](https://github.com/eden77-rgb/)
- **Enzo** • [enzzo95](https://github.com/enzzo95)

---

## 📄 Licence
MIT — voir `LICENSE`.












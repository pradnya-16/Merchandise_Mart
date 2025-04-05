# 🛍️ Merchandise Mart

Merchandise Mart is a full-stack e-commerce web application that allows users to browse products, view details, and proceed with checkout. It features user authentication, JWT-based protected routes, and a polished frontend built with React. The backend is powered by ASP.NET Core with a SQLite database and RESTful APIs.

🌐 **Live Demo:** [[https://merchandise-mart-udib.onrender.com](https://merchandise-mart-udib.onrender.com)](https://merchandise-mart-o1s9.onrender.com/)

---

## 📌 Features

### 🖼️ Frontend (React)
- Product listings with images and details
- Add to cart and checkout functionality
- Responsive design with clean UI
- Protected routes using context/auth
- Google OAuth integration (optional)

### ⚙️ Backend (.NET Core 8.0)
- RESTful API using ASP.NET Core Web API
- SQLite database with Entity Framework Core
- JWT-based authentication system
- Swagger API documentation
- CORS configured for frontend/backend communication

---

## 🧱 Tech Stack

| Layer      | Technology                          |
|------------|-------------------------------------|
| Frontend   | React, Context API, JSX, CSS        |
| Backend    | ASP.NET Core 8.0, Web API           |
| Database   | SQLite, Entity Framework Core       |
| Auth       | JWT, Google OAuth                   |
| Deployment | Render.com (Docker + Blueprint)     |
| API Docs   | Swagger                             |

---

## 🚀 Setup Instructions

### 🔧 Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download)
- [Node.js + npm](https://nodejs.org/)
- Git

### 🛠️ Clone the repository

```bash
git clone https://github.com/pradnya-16/Merchandise_Mart.git
cd Merchandise_Mart
```

---

### 🖥️ Frontend

```bash
cd frontend
npm install
npm start
```

Runs on: [http://localhost:3000](http://localhost:3000)

---

### 🔙 Backend

```bash
cd backend
dotnet restore
dotnet build
dotnet run
```

Runs on: [https://localhost:5001](https://localhost:5001) or [http://localhost:5000](http://localhost:5000)

---

## 🐳 Deployment (Render)

This project uses **Render + Docker** for deployment. It uses:

- `backend/Dockerfile` to containerize the app
- `.render.yaml` to configure a single-service blueprint

Deployment includes both the frontend (built into `wwwroot`) and the backend in a single containerized app.

---

## 📂 Project Structure

```
Merchandise_Mart/
│
├── frontend/            # React frontend
│   ├── public/
│   └── src/
│
├── backend/             # ASP.NET Core backend
│   ├── Controllers/
│   ├── Models/
│   ├── Data/
│   ├── wwwroot/         # Contains built frontend
│   └── Program.cs
│
├── .render.yaml         # Render blueprint configuration
└── README.md
```

---

## 📸 Screenshots

| Page | Preview |
|------|---------|
| Home | *(Add screenshot here)* |
| Product Details | *(Add screenshot here)* |
| Cart/Checkout | *(Add screenshot here)* |

---

## 👩‍💻 Developed By

**Pradnya**  
Graduate Presidential Scholar  
M.S. in Computer Science @ DePaul University  
GitHub: [@pradnya-16](https://github.com/pradnya-16)

---

## 📫 Contact

- 📧 pradnya@example.com *(replace with your email)*
- 💼 [LinkedIn](https://www.linkedin.com/in/yourprofile)

---

## ⭐ If You Liked This Project

Please consider giving it a ⭐ on GitHub! It helps others discover it too ✨

# 🤖 AI Customer Support Platform

> A scalable AI-powered customer support platform built with **ASP.NET Core**, **Clean Architecture**, **Microservices**, **PostgreSQL**, **RabbitMQ**, **Redis**, and **React**.

---

## 📌 Overview

AI Customer Support Platform is a production-inspired customer support system that enables organizations to manage customer tickets efficiently while leveraging Artificial Intelligence to automate repetitive tasks such as:

- Ticket categorization
- Ticket summarization
- AI-powered response suggestions
- Knowledge base retrieval
- Smart ticket assignment
- Analytics & reporting

The project is designed following enterprise software engineering principles including:

- Clean Architecture
- Domain Driven Design (DDD)
- CQRS
- MediatR
- Repository Pattern
- Event Driven Architecture
- Microservices

---

# 🏗️ System Architecture

```
                    React Frontend
                           │
                           ▼
                    API Gateway (Future)
                           │
     ┌─────────────────────┼─────────────────────┐
     ▼                     ▼                     ▼
 Auth Service         Ticket Service      Notification Service
     │                     │                     │
     ├──────────────┐      │                     │
     ▼              ▼      ▼                     ▼
 PostgreSQL      Redis   PostgreSQL         RabbitMQ
                        │
                        ▼
                  AI Service
                        │
         Ollama / OpenAI / Gemini (Future)
```

---

# 🛠 Tech Stack

## Backend

- ASP.NET Core (.NET 10)
- Entity Framework Core
- PostgreSQL
- MediatR
- FluentValidation
- JWT Authentication
- BCrypt
- Serilog

---

## Frontend

- React
- TypeScript
- Vite
- Tailwind CSS
- React Query

---

## Infrastructure

- Docker
- Docker Compose
- Redis
- RabbitMQ

---

## AI

- Ollama
- OpenAI API
- Vector Database (Future)

---

# 📂 Project Structure

```
Customer_Support_Platform/

services/
│
├── auth-service/
│
├── ticket-service/
│
├── notification-service/
│
├── ai-service/
│
└── gateway/

frontend/

docker-compose.yml
README.md
```

---

# 📁 Auth Service Structure

```
AuthService.Api

AuthService.Application

AuthService.Domain

AuthService.Infrastructure

tests
```

---

# ✨ Features

## Authentication

- User Registration
- Login
- JWT Authentication
- Refresh Tokens
- Role Based Authorization

---

## Ticket Management

- Create Ticket
- Update Ticket
- Assign Ticket
- Close Ticket
- Ticket Status Workflow

---

## AI Features

- AI Response Suggestions
- Ticket Summarization
- Ticket Classification
- Knowledge Base Search

---

## Notifications

- Email Notifications
- Real-time Notifications
- RabbitMQ Events

---

## Dashboard

- Agent Dashboard
- Customer Dashboard
- Admin Dashboard

---

# 🚀 Getting Started

## Clone Repository

```bash
git clone https://github.com/Akasht3010/Customer_support_platform.git

cd Customer_support_platform
```

---

## Start Infrastructure

```bash
docker compose up -d
```

---

## Run Auth Service

```bash
cd services/auth-service

dotnet restore

dotnet build

dotnet run --project AuthService.Api
```

---

# Database Migration

```bash
dotnet ef database update \
--project AuthService.Infrastructure \
--startup-project AuthService.Api
```

---

# Current Progress

| Module | Status |
|---------|--------|
| Repository | ✅ |
| Docker Setup | ✅ |
| PostgreSQL | ✅ |
| Redis | ✅ |
| RabbitMQ | ✅ |
| Clean Architecture | ✅ |
| Auth Service Foundation | ✅ |
| Entity Framework | ✅ |
| Authentication | 🚧 |
| Ticket Service | ⏳ |
| AI Service | ⏳ |
| Frontend | ⏳ |
| CI/CD | ⏳ |

---

# Roadmap

## Phase 1

- [x] Repository Setup
- [x] Docker Setup
- [x] PostgreSQL
- [x] Redis
- [x] RabbitMQ
- [x] Clean Architecture

---

## Phase 2

- [ ] User Registration
- [ ] Login
- [ ] JWT Authentication
- [ ] Refresh Tokens

---

## Phase 3

- [ ] Ticket Service
- [ ] CQRS
- [ ] Event Publishing

---

## Phase 4

- [ ] AI Integration
- [ ] Ticket Summarization
- [ ] Smart Replies

---

## Phase 5

- [ ] Notification Service
- [ ] RabbitMQ
- [ ] SignalR

---

## Phase 6

- [ ] Frontend
- [ ] Dashboard
- [ ] Authentication UI

---

## Phase 7

- [ ] CI/CD
- [ ] Kubernetes
- [ ] Azure Deployment

---

# 📚 Learning Objectives

This project demonstrates knowledge of:

- Clean Architecture
- Microservices
- CQRS
- MediatR
- Repository Pattern
- Dependency Injection
- JWT Authentication
- Event Driven Architecture
- Docker
- PostgreSQL
- Redis
- RabbitMQ
- AI Integration
- Production-grade Backend Design

---

# 👨‍💻 Author

**Akash Thakkar**

GitHub:
https://github.com/Akasht3010

---

# ⭐ Star the Repository

If you find this project interesting, consider giving it a ⭐.

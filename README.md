# WT-6 ASP.NET Core Minimal API

Лабораторная работа WT-6 — Разработка REST API на ASP.NET Core Minimal API.

## Таблица API
| Метод | URL | Назначение |
|---|---|---|
| GET | /api/properties | получить список |
| GET | /api/properties/{id} | получить объект |
| POST | /api/properties | создать объект |
| PUT | /api/properties/{id} | изменить объект |
| DELETE | /api/properties/{id} | удалить объект |

## Swagger
После запуска документация доступна по адресам:

- Swagger UI: `http://localhost:5064/swagger`
- OpenAPI JSON: `http://localhost:5064/swagger/v1/swagger.json`

## Запуск локально
```bash
dotnet run
```

## Опубликованное приложение
https://wt-lab6-6minimalapi-kobzeva.onrender.com

# WT-6 ASP.NET Core Minimal API

Лабораторная работа WT-6 — Разработка REST API на ASP.NET Core Minimal API и публикация на Render.

**Предметная область:** недвижимость (агентство недвижимости).  
**Основная сущность:** `Property` (объект недвижимости).

## Содержание

- [Структура проекта](#структура-проекта)
- [Таблица API](#таблица-api)
- [HTTP-статусы](#http-статусы)
- [Swagger / OpenAPI](#swagger--openapi)
- [Примеры JSON-запросов и ответов](#примеры-json-запросов-и-ответов)
- [Запуск локально](#запуск-локально)
- [Запуск в Docker](#запуск-в-docker)
- [Ссылки](#ссылки)

## Структура проекта

```
wt-lab6-6minimalapi-kobzeva/
├── Models/
│   └── Property.cs          # модель предметной области
├── Data/
│   └── PropertyStore.cs     # хранилище данных в памяти
├── Program.cs               # endpoints Minimal API
├── Dockerfile               # многоэтапная сборка Docker-образа
├── .dockerignore
├── README.md
├── .gitignore
└── wt-lab6-6minimalapi-kobzeva.csproj
```

## Таблица API

| Метод | URL | Назначение |
|---|---|---|
| GET | `/` | проверить работу приложения |
| GET | `/api/info` | получить информацию о приложении |
| GET | `/api/properties` | получить список объектов |
| GET | `/api/properties/{id}` | получить объект по идентификатору |
| GET | `/api/properties?search=...` | найти объекты по адресу или типу |
| POST | `/api/properties` | создать объект |
| PUT | `/api/properties/{id}` | изменить объект |
| DELETE | `/api/properties/{id}` | удалить объект |

## HTTP-статусы

| Ситуация | Статус |
|---|---|
| Успешный GET | `200 OK` |
| Успешный POST | `201 Created` |
| Успешный PUT | `200 OK` |
| Успешный DELETE | `204 No Content` |
| Некорректные данные | `400 Bad Request` |
| Объект не найден | `404 Not Found` |

## Swagger / OpenAPI

После запуска документация доступна по адресам:

- Swagger UI: `http://localhost:10000/swagger`
- OpenAPI JSON: `http://localhost:10000/swagger/v1/swagger.json`

## Примеры JSON-запросов и ответов

### POST `/api/properties`

Запрос:

```json
{
  "address": "Минск, ул. Немига, 5, кв. 10",
  "type": "Квартира",
  "price": 150000,
  "area": 72.5,
  "rooms": 3,
  "isAvailable": true
}
```

Ответ `201 Created` (заголовок `Location: /api/properties/7`):

```json
{
  "id": 7,
  "address": "Минск, ул. Немига, 5, кв. 10",
  "type": "Квартира",
  "price": 150000,
  "area": 72.5,
  "rooms": 3,
  "isAvailable": true
}
```

### GET `/api/properties/1`

Ответ `200 OK`:

```json
{
  "id": 1,
  "address": "Тридевятое царство, замок принцессы",
  "type": "Замок",
  "price": 999999,
  "area": 500,
  "rooms": 20,
  "isAvailable": true
}
```

### PUT `/api/properties/1`

Запрос:

```json
{
  "address": "Тридевятое царство, замок принцессы",
  "type": "Замок",
  "price": 1200000,
  "area": 520,
  "rooms": 22,
  "isAvailable": false
}
```

Ответ `200 OK` — обновлённый объект.

### DELETE `/api/properties/1`

Ответ `204 No Content` (тело ответа отсутствует).

### Ошибки

`404 Not Found` — объект с указанным `id` не найден.

`400 Bad Request` — некорректные данные:

```json
{
  "error": "Price must be greater than zero."
}
```

## Запуск локально

```bash
dotnet restore
dotnet run
```

Приложение слушает порт `10000` (или значение переменной окружения `PORT`):

- `http://localhost:10000/`
- `http://localhost:10000/api/info`
- `http://localhost:10000/api/properties`
- `http://localhost:10000/swagger`

## Запуск в Docker

```bash
docker build -t wt-lab6-6minimalapi .
docker run -p 10000:10000 wt-lab6-6minimalapi
```

Проверка:

```bash
curl http://localhost:10000/
curl http://localhost:10000/api/properties
```

## Ссылки

- GitHub: https://github.com/VictoriaKobzeva/wt-lab6-6minimalapi-kobzeva
- Render: https://wt-lab6-6minimalapi-kobzeva.onrender.com
- Swagger на Render: https://wt-lab6-6minimalapi-kobzeva.onrender.com/swagger

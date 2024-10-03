## Contexto

Sistema gerenciador de tarefas, onde você poderá cadastrar uma lista de tarefas que permitirá organizar melhor a sua rotina.

## Métodos

**Endpoints**


| Verbo  | Endpoint                | Parâmetro | Body          |
|--------|-------------------------|-----------|---------------|
| GET    | /Task/{id}              | id        | N/A           |
| PUT    | /Task/{id}              | id        | Schema Task   |
| DELETE | /Task/{id}              | id        | N/A           |
| GET    | /Task                   | N/A       | N/A           |
| GET    | /Task/FindByTitle       | title     | N/A           |
| GET    | /Task/FindByDate        | date      | N/A           |
| GET    | /Task/FindByStatus      | status    | N/A           |
| POST   | /Task                   | N/A       | Schema Task   |

Esse é o schema Task

```json
{
  "id": 0,
  "title": "string",
  "description": "string",
  "date": "2022-06-08T01:31:07.056Z",
  "status": "Pendente"
}
```

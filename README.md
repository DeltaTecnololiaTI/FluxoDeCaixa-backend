# FluxoDeCaixa-backend
Fornecer uma aplicação para controle de fluxo de caixa diário, permitindo lançamentos de débitos e créditos e a geração de relatórios consolidados de saldo.

Fluxo de Caixa API - Guia de Implementação

 Pré-requisitos
- .NET 8 SDK instalado
- SQL Server (local ou em container Docker)
- Entity Framework Core CLI

 Configuração Inicial

 1. Migrações do Banco de Dados

Para criar e aplicar as migrações, execute os seguintes comandos no terminal:

```bash
 Criar nova migration
dotnet ef migrations add InitialCreate --project FluxoDeCaixa.Infra --startup-project FluxoDeCaixa.API

 Aplicar migração ao banco de dados
dotnet ef database update --project FluxoDeCaixa.Infra --startup-project FluxoDeCaixa.API
```

 Autenticação

Para acessar endpoints protegidos, primeiro obtenha um token JWT:

**Endpoint:** `POST /api/auth/login`

**Request Body:**
```json
{
  "username": "admin",
  "password": "123456"
}
```

Use o token retornado no header `Authorization: Bearer {token}` das requisições subsequentes.

 Inserção de Lançamentos

**Endpoint:** `POST /api/lancamentos`

**Request Body:**
```json
{
    "valor": 100.00,
    "tipo": "Credito",
    "data": "2025-03-29",
    "categoria": "Vendas"
}
```

**Valores aceitos para `tipo`:**
- "Credito" para lançamentos positivos
- "Debito" para lançamentos negativos

 Consulta de Saldo Diário

**Endpoint:** `GET /api/saldodiario/{data}`

**Exemplo:**
```
GET /api/saldodiario/2025-03-29
```

**Response:**
```json
{
  "data": "2025-03-29",
  "totalCreditos": 1500.50,
  "totalDebitos": 750.25,
  "saldoDiario": 750.25
}
```

 🐋 Executando com Docker

1. Construa a imagem:
```bash
docker-compose build
```

2. Inicie os containers:
```bash
docker-compose up -d
```

O container do SQL Server será configurado automaticamente com as migrações aplicadas.

Testando a API

1. Inicie a aplicação:
```bash
dotnet run --project FluxoDeCaixa.API
```

2. Acesse a documentação interativa:
```
http://localhost:5000/swagger
```

3. Utilize os exemplos de request fornecidos no Swagger UI para testar os endpoints.
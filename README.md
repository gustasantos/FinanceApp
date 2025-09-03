# FinanceApp

**FinanceApp** é um projeto de estudo em .NET com foco em boas práticas de arquitetura, explorando **Domain-Driven Design (DDD)**, **CQRS com MediatR**, **Entity Framework Core** e **separação de contextos**.

## Objetivo

Este repositório serve como laboratório para praticar conceitos avançados de arquitetura de software aplicados a APIs .NET, com ênfase em **organização de domínios** e **clareza na separação de responsabilidades**.

## Arquitetura

O projeto segue princípios de **Clean Architecture** e **DDD**:

-   **Domínios isolados** → Cada contexto de negócio possui sua própria camada de **Domain**, **Application** e **Infrastructure**.
    
    -   Exemplo: `Usuario` e `Financeiro` são separados, cada qual com seu **DbContext** e suas **migrations independentes**.
        
-   **CQRS + MediatR** →  
    A comunicação entre a API e a lógica de aplicação é feita por **Commands** e **Queries**, tratados por **Handlers** através do **MediatR**.  Isso elimina acoplamento da API com as regras de negócio.
    
-   **Entity Framework Core** →  
    Persistência é realizada com **mapeamentos via Fluent API** e **DbContexts específicos** por domínio, mantendo a independência entre contextos.
    
-   **Shared Kernel** →  
    Módulo compartilhado que contém utilitários comuns, como o padrão `Result<T>` para padronizar retornos de sucesso/erro.
    
## Como executar

1.  Clone o repositório:
	```
	git clone https://github.com/gustasantos/FinanceApp.git
	```

2.   Configure a **connection string** no `appsettings.json`, `FinanceiroDbContextFactory` e `UsuarioDbContextFactory`.

3. Aplique as migrations para cada contexto:
	```
	dotnet ef database update --context UsuarioDbContext
	dotnet ef database update --context FinanceiroDbContext
	```

4. Rode a API:
	```
	dotnet run --project FinanceApp.Api
	```

5. Acesse o Swagger em:
	```
	https://localhost:5001/swagger
	```

##  Conceitos praticados

-    **DDD** → Separação clara de domínios e responsabilidades.
    
-    **CQRS/MediatR** → Commands e Queries desacoplados da API.
    
-    **EF Core** → Persistência com migrations e DbContexts distintos.
    
-    **Clean Architecture** → Divisão em camadas (`Domain`, `Application`, `Infrastructure`, `Api`).
    
-    **Shared Kernel** → Reuso de utilitários comuns entre contextos.

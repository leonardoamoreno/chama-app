# Chama Signup Courses

## Ambientes:

- Azure Api Management: https://github.com/leonardoamoreno/chama-app/
- Imagem da api: 

## Teste:

Para testar a API basta acessar: https://coursesignupapi.azurewebsites.net/swagger/index.html

#### - Courses
- GET /Courses/{id}: funciona com o repositorio e banco de dados SQL
- POST /Courses/create: funciona com o repositorio e banco de dados SQL
- POST /Courses/sign-up: mocado e comentado no codigo a estratégia

#### - Lecturers

- POST /Lecturers/create: Mocado e comentado no codigo

#### - Statistics

- GET /Statistics

## Tecnologias implementadas:

- ASP.NET Core 3.1 (with .NET Core 3.1) 
- SQL Azure
- Entity Framework Core 3.1
- .NET Core Native DI
- AutoMapper
- FluentValidator
- MediatR
- Swagger UI 

## Arquitetura:

- Arquitetura completa com questões de separação de responsabilidades, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Events
- Domain Notification
- Domain Validations
- CQRS (Imediate Consistency)
- Event Sourcing
- Unit of Work
- Repository

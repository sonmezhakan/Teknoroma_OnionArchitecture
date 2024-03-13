# Teknoroma Project

This project has been developed for the Bilgeadam Academy Full Stack Developer Training success certification. Teknoroma is a project designed for companies engaged in retail, dealership, and alternative sales processes. The project includes features that allow comprehensive tracking of suppliers, personnel, inventory, and sales. Multiple branches can be created, enabling control over all branches through this system. The project is developed following the principles of "Onion Architecture."

## Onion Architecture

Onion Architecture was designed by Jeffrey Palermo in 2008. The name comes from its layered structure, resembling the layers of an onion. The main goal of this architecture is to ensure that the core business logic of the application remains independent of other layers and to prevent external dependencies from penetrating inward.

The inside-out approach helps organize the responsibilities of the layers in a specific order, facilitating the development of the application as a cohesive whole. This architecture comprises five fundamental layers. These are:

1. Domain
2. Application
3. Persistence
4. Infrastructure
5. Presentation

<p align="center">
    <img width="400" height="300" alt="Object Relational Mapping (ORM)" src="https://miro.medium.com/v2/resize:fit:640/format:webp/1*0Pg6_UsaKiiEqUV3kf2HXg.png">
</p>

### Domain

This layer, as seen in the diagram, resides at the innermost part of the structure, representing the core business logic of the system. Entities are created within this layer. According to the Onion Architecture, this layer should only have a reference to the Application layer.

### Application

It is positioned above the Domain layer. Within this layer, structures such as Repository, Service, Mapping, Dto are created. It assumes similar responsibilities to the Business Logic (BLL) layer found in N-tier Architecture.

When reviewing Onion Architecture projects, you might encounter a folder named "Core" containing both the Domain and Application layers.

### Persistence

The Persistence layer is located in the outermost layer. It is the layer where we perform operations related to the database. It undertakes tasks similar to the Data Access (DAL) layer in the N-tier Architecture structure. Operations such as Context, Configuration, Seeding, Repository are included in this layer.

### Infrastructure

The Infrastructure layer is situated in the outermost layer. It manages external dependencies and facilitates the application's interaction with the outside world. Operations such as Email, SMS, notifications, and payments, which are independent of the database, occur in this layer.

When examining Onion Architecture projects, you may encounter both Persistence and Infrastructure layers under the name Infrastructure. In some projects, the Persistence layer may not be explicitly created, and the Infrastructure layer may assume the responsibilities of the Persistence layer.

### Presentation

The Presentation layer is located in the outermost layer. It creates the user interface and serves as the layer facilitating the interaction between the user and the application. Projects such as Web API, Console, Windows Form, and MVC are created in this layer.

## Technologies

### BackEnd
- .Net
- MsSql
- Asp.Net
- Restful Api
- FluentValidation
- AutoMapper

### FrontEnd
- Jquery
- Bootstrap
- Datatables
- Select2
- SweetAlert
- Charts


## Libraries


- [AutoMapper](https://www.nuget.org/packages/AutoMapper/13.0.1)
- [FluentValidation](https://www.nuget.org/packages/FluentValidation/11.9.0)
- [FluentValidation.DependencyInjectionExtensions](https://www.nuget.org/packages/FluentValidation.DependencyInjectionExtensions/11.9.0)
- [MediatR](https://www.nuget.org/packages/MediatR/12.1.1)
- [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer/7.0.16)
- [Microsoft.AspNetCore.Identity](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity/2.2.0)
- [Microsoft.AspNetCore.Identity.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore/7.0.15)
- [Microsoft.EntityFrameworkCore.Proxies](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Proxies/7.0.16)
- [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/7.0.15)
- [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/7.0.15)
- [Microsoft.Extensions.DependencyInjection.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Abstractions/7.0.0)
- [Microsoft.Extensions.Http](https://www.nuget.org/packages/Microsoft.Extensions.Http/7.0.0)
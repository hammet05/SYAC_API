# Nombre de la Aplicación
PEDIDOS MANAGER SYAC
Sistema de información que permita la creación y edición de ORDENES DE PEDIDO por cliente.

Aplicación desarrollada en .NET 9 con arquitectura hexagonal que implementa Entity Framework Core (Code First), AutoMapper, Fluent API para configuración de modelos y Swagger para documentación de la API.

---


## Características

- Arquitectura Hexagonal para una mejor separación de responsabilidades y escalabilidad.
- Entity Framework Core con enfoque Code First para modelado y migraciones de base de datos.
- Configuración avanzada de modelos usando Fluent API.
- Mapeo de objetos con AutoMapper para facilitar la transformación entre entidades y DTOs.
- Documentación automática y prueba de la API con Swagger.

---

## Arquitectura

La aplicación sigue el patrón de **Arquitectura Hexagonal**  con las siguientes capas principales:

- **Core (Domain):** Contiene las entidades de dominio, interfaces y lógica de negocio.
- **Application:** Contiene servicios de aplicación, casos de uso y lógica de negocio.
- **Infrastructure:** Implementaciones específicas para acceso a datos, integración con bases de datos, etc.
- **API (Adapters):** Controladores y configuración para exponer la API REST.

---

## Tecnologías

- [.NET 9](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) (Code First + Fluent API)
- [AutoMapper](https://automapper.org/)
- [Swagger / Swashbuckle](https://swagger.io/tools/swagger-ui/)
- [Fluent API](https://docs.microsoft.com/en-us/ef/core/modeling/)

---

## USO
API: http://localhost:5234/index.html

## Instalación

1. Clona el repositorio:

   ```bash
   git clone https://github.com/hammet05/SYAC_API
   cd repositorio


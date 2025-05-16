# Proyecto ASP.NET Core de prueba para vacante Desarrollador Junior - Dito Sas

Este proyecto es una aplicación web construida con **ASP.NET Core**, siguiendo el patrón de **Clean Architecture** para promover la separación de responsabilidades y facilitar el mantenimiento.

---

## 🧱 Estructura del Proyecto

- **TestDito.WebApi**: Proyecto principal (punto de entrada).
- **TestDito.Application**: Lógica de negocio y casos de uso.
- **TestDito.Domain**: Entidades del dominio.
- **TestDito.Infrastructure**: Acceso a datos y servicios externos.

---

## 🚀 Requisitos Previos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- Visual Studio 2022 o superior (con soporte para ASP.NET y EF Core)
- SQL Server LocalDB o SQL Server

---

## ⚙️ Primeros pasos

1. Clona el repositorio:

```bash
git clone https://github.com/tu-usuario/tu-repo.git
cd tu-repo
```

2. Restaura paquetes NuGet:

```bash
dotnet restore
```

3. Revisa la cadena de conexión en appsettings.json.

4. Ejecuta Scripts de SQL ubicado en el archivo .sql en la raiz de este proyecto

5. Ejecuta la aplicación:

```bash
dotnet run --project WebApi
```
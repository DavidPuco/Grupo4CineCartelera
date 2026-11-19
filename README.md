# Grupo 4 — Sistema Web de Cartelera de Cine (`Grupo4CineCartelera`)

## Tema y problema asignado
**Problema 7:** Un cine necesita gestionar su cartelera mediante una aplicación web en ASP.NET Core MVC con Entity Framework Core, SQL Server, Identity y control de acceso por roles.

- **Entidad principal:** `Genero` (`Id`, `Nombre`, `Descripcion?`)
- **Entidad dependiente:** `Pelicula` (`Id`, `Titulo`, `Director`, `DuracionMinutos`, `GeneroId`)
- **Rol de gestión:** `Curador` (puede crear, editar y eliminar registros en ambas entidades)
- **Rol de consulta:** `Espectador` (solo puede visualizar listas y detalles)

---

## Integrantes, orden de turnos y aportes

| Turno | Integrante | Fase | Aporte principal |
| :---: | :--- | :--- | :--- |
| 1 | **David Puco** | Fase 1 | Creación del proyecto base y repositorio, entidad dependiente `Pelicula` con CRUD, configuración de conexión y migración `InitialCreate`. |
| 2 | **Alejandro Sánchez** | Fase 2 y Vistas por rol | Validaciones `DataAnnotations` en español para `Pelicula`, migración `ValidacionesPelicula`, ocultamiento de enlaces Crear/Editar/Eliminar según rol `Curador` y visualización del rol en `_LoginPartial`. |
| 3 | **Vanesa Chiriguaya** | Fase 3 | Entidad principal `Genero` con validaciones, relación 1:N (`GeneroId` y navegación), CRUD de géneros, lista desplegable y migración `AgregarGenero`. |
| 4 | **Israel Portilla** | Fase 4 | Integración de Identity con `ApplicationUser`, migración `AgregarIdentity`, integración de `_LoginPartial` en el menú y protección inicial con `[Authorize]` / `[AllowAnonymous]`. |
| 5 | **Alexander Jácome** | Fase 5 | Activación de roles con `AddRoles<IdentityRole>()`, creación automática de roles (`Curador`, `Espectador`) y usuarios de prueba al iniciar, restricción por rol en controladores y documentación en `README.md`. |

---

## Usuarios de prueba
Los roles y usuarios se crean automáticamente al iniciar la aplicación por primera vez:

| Rol | Correo | Contraseña | Permisos |
| :--- | :--- | :--- | :--- |
| **Curador** | `curador@cine.com` | `Curador123!` | Gestión completa (Crear, Editar, Eliminar) en Géneros y Películas |
| **Espectador** | `espectador@cine.com` | `Espectador123!` | Solo consulta (Ver listas y detalles) |

---

## Pasos para ejecutar el proyecto
1. **Clonar el repositorio:** Abrir Visual Studio y seleccionar **Git > Clonar repositorio** con la URL de este proyecto.
2. **Ajustar la cadena de conexión:** Abrir `appsettings.json` y verificar que `DefaultConnection` apunte a tu instancia local de SQL Server (por ejemplo, `localhost\SQLEXPRESS`).
3. **Aplicar las migraciones:** Abrir la Consola del Administrador de paquetes (*Herramientas > Administrador de paquetes NuGet*) y ejecutar:
   ```powershell
   Update-Database -Context ApplicationDbContext
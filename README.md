# Gym Management

Estoy desarrollando una aplicación de escritorio para gestionar socios y pagos de membresías de un gimnasio. La solución usa .NET MAUI Blazor, Entity Framework Core y PostgreSQL.

## Estado del proyecto

El código incluye el registro y la búsqueda de socios, filtros por estado, edición de datos y registro de pagos. También calcula fechas de vencimiento según el tipo de membresía. La solución aún conserva algunas páginas y recursos de la plantilla de MAUI; no la presento como un producto terminado.

## Estructura

- Gym Management/src/GymManagement.Core: modelos de clientes y pagos.
- Gym Management/src/GymManagement.Infrastructure: contexto de Entity Framework y mapeo de tablas.
- Gym Management/src/GymManagement.Desktop: interfaz MAUI Blazor.
- Diagramas de casos de uso, flujo y entidades en la raíz.

## Configuración local

La solución apunta a .NET 9 y necesita la carga de trabajo de .NET MAUI. Para usar la base de datos, copio Gym Management/src/GymManagement.Desktop/appsettings.example.json como appsettings.json en la misma carpeta y sustituyo los valores de ejemplo por los de mi PostgreSQL.

El archivo real appsettings.json está excluido de Git porque contiene credenciales. La aplicación lo incorpora al ejecutable durante la compilación; por eso esta configuración sirve para desarrollo local, pero no para distribuir un binario a terceros con credenciales reales.

Abro Gym Management/GymManagement.sln en Visual Studio con las herramientas de MAUI instaladas y selecciono el destino de Windows para compilar y ejecutar. No he verificado aquí la conexión con una base de datos nueva ni todos los flujos de la interfaz.

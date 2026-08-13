# 📦 InventPro

**InventPro** es un sistema de gestión de inventario simple, rápido y organizado. Permite controlar existencias, movimientos y reportes desde un solo lugar, pensado para adaptarse tanto a pequeñas y medianas empresas como a negocios más grandes.

Este proyecto nació de la curiosidad por explorar interfaces simples y claras, y de las ganas de adentrarme en el mundo de la gestión de inventarios para negocios de cualquier tamaño.

---

## ✨ Características

- 🏠 Panel principal con navegación clara e intuitiva
- 📊 Módulo de reportes para visualizar movimientos y rotación de productos
- 📦 Control de existencias en tiempo real
- 🎨 Interfaz limpia con Bootstrap Icons y diseño personalizado
- 🔒 Página de política de privacidad incluida

> Este proyecto está en desarrollo activo — nuevas funcionalidades se irán agregando progresivamente.

---

## 🛠️ Tecnologías utilizadas

- **[.NET 10](https://dotnet.microsoft.com/)** — Framework principal
- **ASP.NET Core MVC** — Arquitectura Modelo-Vista-Controlador
- **C#** — Lenguaje de programación
- **Bootstrap Icons** — Iconografía
- **CSS personalizado** — Diseño propio (paleta verde/teal `#0f766e`)
- **JetBrains Rider** — IDE de desarrollo

---

## 🚀 Cómo ejecutar el proyecto

### Requisitos previos
- [SDK de .NET 10](https://dotnet.microsoft.com/download) instalado
- Git

### Pasos

1. Clona el repositorio:
   ```bash
   git clone https://github.com/KevinGo24/InventPro.git
   ```

2. Entra a la carpeta del proyecto:
   ```bash
   cd InventPro/InventPro
   ```

3. Restaura las dependencias:
   ```bash
   dotnet restore
   ```

4. Ejecuta la aplicación:
   ```bash
   dotnet run
   ```

   O, si quieres recarga automática mientras desarrollas:
   ```bash
   dotnet watch run
   ```

5. Abre tu navegador en la URL que aparezca en la terminal (por ejemplo `http://localhost:5270`).

---

## 📁 Estructura del proyecto

```
InventPro/
├── Controllers/       # Controladores MVC
├── Models/             # Modelos de datos
├── Views/              # Vistas Razor (.cshtml)
│   ├── Home/
│   └── Shared/          # Layout compartido (_Layout.cshtml)
├── wwwroot/            # Archivos estáticos
│   ├── css/              # Estilos (StyleMain.css, site.css)
│   ├── js/
│   └── Icons/
├── Program.cs          # Punto de entrada de la aplicación
└── appsettings.json    # Configuración de la aplicación
```

---

## 🗺️ Roadmap

- [ ] CRUD completo de productos
- [ ] Autenticación de usuarios
- [ ] Dashboard con gráficos de rotación de inventario
- [ ] Exportación de reportes (PDF/Excel)
- [ ] Alertas de stock bajo

---

## 👤 Autor

Desarrollado por **[KevinGo24](https://github.com/KevinGo24)**

---

## 📄 Licencia

Este proyecto está disponible bajo la licencia que definas (MIT, por ejemplo). Si aún no tienes una, puedes agregar un archivo `LICENSE` a tu repositorio.
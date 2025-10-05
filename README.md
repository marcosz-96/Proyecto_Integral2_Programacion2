# DeliveryGo

**DeliveryGo** es un mini-ecommerce en consola desarrollado en C# puro, diseñado como una demostración educativa de patrones de diseño de software. Implementa un sistema de checkout simple donde los usuarios pueden gestionar un carrito de compras, seleccionar métodos de envío y pago, confirmar pedidos y recibir notificaciones de cambios de estado. El proyecto está dividido en etapas para simular el trabajo en equipo, enfocándose en patrones como Command, Strategy, Singleton, Factory, Adapter, Decorator, Builder, Observer y Facade.

Este proyecto es ideal para estudiantes o desarrolladores que quieran aprender sobre patrones de diseño en un contexto práctico, sin dependencias externas ni complejidades de UI web/móvil.

## ¿Qué hace el programa?

DeliveryGo simula un flujo completo de compra en una aplicación de delivery de productos electrónicos y accesorios. El programa permite a los usuarios:

- **Gestionar un carrito de compras:** Agregar, quitar o modificar cantidades de ítems, con soporte para deshacer (Undo) y rehacer (Redo) acciones.
- **Calcular envíos dinámicos:** Elegir métodos de envío (moto, correo o retiro en tienda) y aplicar reglas como envío gratis por umbral de compra.
- **Procesar pagos:** Seleccionar métodos de pago (tarjeta, transferencia o Mercado Pago), aplicar impuestos (IVA) y descuentos (cupones).
- **Confirmar pedidos:** Construir pedidos paso a paso, simular cambios de estado (pendiente, pagado, enviado) y notificar a observadores (cliente, logística, auditoría).
- **Interactuar vía menú:** Una interfaz de consola intuitiva guía al usuario a través de todas las etapas del checkout.

Todo se ejecuta en una aplicación de consola, mostrando resultados en tiempo real (subtotales, totales, notificaciones) para una experiencia interactiva.

## ¿Qué tecnologías usa?

- **Lenguaje principal:** C# (.NET 9).
- **Entorno de ejecución:** Aplicación de consola pura (sin frameworks web como ASP.NET).
- **Herramientas de desarrollo:** Visual Studio 2022.
- **Control de versiones:** Git y GitHub para colaboración en equipo.
- **Otras dependencias:** Ninguna externa (sin NuGet packages, bases de datos o APIs reales; usa simulaciones para pagos y envíos).

El proyecto es liviano y portable, compilable con `dotnet build` y ejecutable con `dotnet run`.

## ¿Qué necesidad satisface?

DeliveryGo satisface la necesidad educativa de demostrar cómo aplicar patrones de diseño en un sistema realista de e-commerce, sin la complejidad de un proyecto comercial completo. En un contexto de desarrollo de software:

- **Para estudiantes/desarrolladores:** Proporciona un ejemplo práctico y modular para aprender SOLID principles y patrones GoF (Gang of Four), facilitando la comprensión de cómo desacoplar componentes para mantenerabilidad y extensibilidad.
- **Para equipos de desarrollo:** Muestra cómo dividir un proyecto en etapas colaborativas, usando interfaces y fachadas para integrar subsistemas independientes.
- **Para prototipado rápido:** Ofrece una base para simular flujos de negocio (como checkouts) en entornos educativos o de prueba, evitando costos de infraestructura.

En resumen, resuelve la brecha entre teoría de patrones y práctica, permitiendo experimentar con refactorizaciones y extensiones sin riesgos.

## ¿En qué rubros/actividades podría ser aplicado?

DeliveryGo puede adaptarse o extenderse en varios rubros y actividades:

- **Educación y Formación:** Como material didáctico en cursos de programación orientada a objetos, diseño de software o ingeniería de software. Ideal para talleres sobre patrones de diseño o metodologías ágiles.
- **Prototipado de E-commerce:** En startups o consultorías para crear demos rápidas de sistemas de ventas online, delivery de comida/productos o marketplaces (ej. para más adelante, agregar integración con bases de datos reales).
- **Desarrollo de Software Educativo:** En rubros como fintech (simulación de pagos), logística (optimización de envíos) o retail (gestión de inventarios), para entrenar equipos en patrones escalables.
- **Actividades de Colaboración:** En hackathons, proyectos universitarios o equipos remotos, para practicar Git workflows, code reviews y división de tareas.
- **Extensiones Comerciales:** Podría evolucionar a una app web/móvil para rubros como delivery de groceries, e-learning (cursos pagos) o servicios on-demand, integrando APIs reales como Stripe o UPS.

Su modularidad lo hace versátil para cualquier escenario donde se necesite un flujo transaccional simple y extensible.

## 🚀 Cómo usar la aplicación

1. **Clonar o descargar el repositorio:**  
   Abre una terminal y ejecuta:  
  $ git clone git@github.com:Briancourel/Actividad-DeliveryGo.git

  
2. **Abrir el proyecto en Visual Studio**  
- Instala .NET SDK 9 desde [dotnet.microsoft.com](https://dotnet.microsoft.com/download).  
  - Abre la carpeta del proyecto en tu IDE.

3. **Compilar el proyecto:**  
En la terminal:  
O usa el botón de "Build" en tu IDE (Ctrl + Shift + B en Visual Studio).

4. **Ejecutar en consola (o ejecutar el debug del IDE):**  
5. O presiona F5 en el IDE para modo debug.

5. **Seguir las opciones del menú:**  
Se abrirá un menú interactivo en consola. Usa números para navegar:  
- Agrega ítems al carrito (opción 1).  
- Elige método de envío (opción 7).  
- Paga y confirma el pedido (opciones 8 y 9).  
- Prueba Undo/Redo (opciones 5 y 6).  
- Sal con la opción 0.

El programa simula todo el flujo; no requiere conexión a internet ni datos reales.

## 👥 Integrantes del equipo

- **Alumno A:
Nombre: Courel Brian - GitHub: (https://github.com/Briancourel)

- **Alumno B:
Nombre: Gomez Marco - GitHub: (https://github.com/marcosz-96)

## 👥 Trabajos realizados

- **Alumno A (Etapa 1 - Carrito & Command)**
- Trabajo realizado: Implementé la gestión del carrito con patrón Command, incluyendo comandos para agregar/quitar/modificar ítems, soporte Undo/Redo y la clase EditorCarrito. También creé pruebas unitarias aisladas para esta etapa.

- **Alumno B (Etapa 2 - Envío & Strategy + Singleton)**
- Trabajo realizado: Desarrollé las estrategias de envío (EnvioMoto, EnvioCorreo, RetiroEnTienda) y el Singleton ConfigManager para manejar umbrales de envío gratis e IVA. Integré cálculos dinámicos en la Facade.

- **Alumno A (Etapa 3 - Pago + Pedido + Facade)**
- Trabajo realizado: Implementé Factory para pagos, Adapter para Mercado Pago (SDK falsa), Decorators para IVA/cupones, Builder para Pedido, Observer para notificaciones y la CheckoutFacade para unir todo.

- **Alumno B: (Etapa 4 - UI y Refinamientos)**
- Trabajo realizado: Creación del menú interactivo en AppRunner, revisiones de código, integración final y documentación. Usando Git para merges y PRs.

## 🧩 Patrones aplicados

El proyecto utiliza patrones de diseño GoF para hacer el código modular, extensible y mantenible. Cada uno se aplica en funcionalidades específicas:

- **Command:** En la gestión del carrito (Etapa 1). Permite encapsular acciones como agregar/quitar ítems o cambiar cantidades en objetos ejecutables, con historial para Undo/Redo. Ejemplo: `AgregarItemCommand` ejecuta `_carrito.Agregar(item)` y guarda el estado previo para revertir.

- **Strategy:** Para calcular costos de envío (Etapa 2). Define un familia de algoritmos intercambiables (EnvioMoto, EnvioCorreo, RetiroEnTienda) que se seleccionan dinámicamente según la elección del usuario, evitando condicionales complejos.

- **Singleton:** En la configuración global (Etapa 2). Asegura una única instancia de `ConfigManager` para valores como umbral de envío gratis o IVA (21%), accesible desde cualquier parte sin duplicación.

- **Factory:** En la creación de pagos (Etapa 3). `PagoFactory` genera instancias de `IPago` según el tipo (tarjeta, transferencia, MercadoPago), ocultando la lógica de instanciación.

- **Adapter:** Para integrar SDK externa de pago (Etapa 3). `PagoAdapterMp` adapta la interfaz de una "SDK falsa" de Mercado Pago a `IPago`, permitiendo compatibilidad sin cambiar código cliente.

- **Decorator:** En modificadores de pagos (Etapa 3). Clases como `PagoConImpuesto` o `PagoConCupon` envuelven un pago base para agregar IVA o descuentos dinámicamente, sin alterar la clase original.

- **Builder:** Para construir pedidos complejos (Etapa 3). `PedidoBuilder` permite armar objetos `Pedido` paso a paso (agregar ítems, dirección, estado), ideal para objetos con muchos parámetros opcionales.

- **Observer:** En notificaciones de pedidos (Etapa 3). `PedidoService` notifica a observadores (ClienteObserver, LogisticaObserver) de cambios de estado (ej. "Pagado" → "Enviado"), implementando el patrón Publish-Subscribe.

- **Facade:** Para integrar subsistemas (Etapa 3). `CheckoutFacade` simplifica el acceso a carrito, envío, pago y pedido, ocultando complejidades internas y orquestando el flujo completo.

Estos patrones siguen principios SOLID, facilitando pruebas y extensiones.

## 📖 Caso narrado de uso

**Ejemplo: Compra de una Laptop y Accesorios con Envío y Pago**

1. **Inicio y Agregar Ítem:** El usuario ejecuta `dotnet run` y ve el menú principal. Selecciona opción 1 ("Agregar ítem al carrito"). Ingresa: SKU="LPT001", Nombre="Laptop Gaming", Precio=1200, Cantidad=1. El sistema confirma: "Ítem agregado. Subtotal: $1200.00".

2. **Agregar Otro Ítem y Error:** Selecciona opción 1 de nuevo: SKU="MOU002", Nombre="Mouse", Precio=25, Cantidad=3. Subtotal actualizado: $1275.00. El usuario se equivoca en la cantidad del mouse y selecciona opción 2 ("Cambiar cantidad"): Cambia a 1. Pero decide revertir: Opción 5 ("Undo") restaura la cantidad a 3.

3. **Ver Resumen y Elegir Envío:** Selecciona opción 4 ("Ver subtotal y total"). Muestra: Subtotal $1275.00, Envío (por defecto: $50), Total $1325.00. Luego, opción 7 ("Elegir método de envío"): Elige "2 - Correo" (costo $80, pero gratis si subtotal > $500? No aplica aquí). Actualiza total a $1355.00.

4. **Aplicar Descuento y Pagar:** Opción 8 ("Pagar pedido"). Elige "3 - Mercado Pago". El sistema aplica Decorator: IVA 21% ($284.55) y un cupón de 10% (-$135.50). Total final: $1504.05. Simula procesamiento exitoso: "Pago aprobado".

5. **Confirmar Pedido y Notificaciones:** Opción 9 ("Confirmar pedido"). Ingresa dirección: "Calle Falsa 123". El Builder arma el Pedido. Cambia estado a "Pagado" → Observer notifica: "Cliente: Su pedido #001 ha sido pagado." → "Logística: Preparando envío." El usuario ve el resumen final y puede salir (opción 0).

Este flujo demuestra la integración de patrones: Command para Undo, Strategy para envío, Decorator para pagos y Observer para notificaciones. ¡Prueba variaciones para ver errores manejados!

## 🔮 Retos futuros

Para una versión 2.0 de DeliveryGo, consideramos agregar funciones vitales que escalen el proyecto:

- **Persistencia de Datos:** Integrar Entity Framework con SQLite para guardar carritos, pedidos e historial de usuarios, permitiendo sesiones persistentes.
- **Autenticación de Usuarios:** Agregar login/register con JWT simple, para perfiles personalizados (historial de compras, direcciones guardadas).
- **Integración Real de APIs:** Reemplazar simulaciones con APIs como Stripe para pagos, Google Maps para distancias de envío o Twilio para notificaciones SMS.
- **UI Avanzada:** Migrar a una app Blazor WebAssembly para una interfaz web responsive, manteniendo los patrones backend.
- **Análisis y Reportes:** Usar Strategy para generar reportes (ventas diarias, métricas de envío) y Observer para alertas en tiempo real (ej. stock bajo).
- **Testing Automatizado:** Agregar xUnit para pruebas unitarias/integración, cubriendo >80% del código, y CI/CD con GitHub Actions.

Estos retos harían de DeliveryGo una base para un e-commerce real, enfocándonos en escalabilidad y seguridad.

## 📌 Notas finales

**Resumen del Trabajo Realizado:** DeliveryGo fue desarrollado en 4 etapas colaborativas, cubriendo desde la gestión básica del carrito hasta un flujo completo de checkout. Aprendimos a aplicar patrones de diseño para resolver problemas reales como Undo/Redo, cálculos dinámicos y notificaciones, manteniendo el código limpio y testable. El proyecto totaliza 100% cobertura de interfaces y cero dependencias externas.

**Información Extra:** 
- El IVA y umbrales son configurables vía Singleton; modifícalos en `ConfigManager` para pruebas.
- Para depuración, activa logs en `PedidoService` imprimiendo estados en consola.
- Si encuentras bugs, abre un issue en GitHub. 
- 
- ¡Gracias por explorar DeliveryGo – un gran ejercicio en patrones de diseño! 🚀

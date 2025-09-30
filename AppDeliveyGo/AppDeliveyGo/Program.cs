// Asegúrate de tener los using necesarios
using AppDeliveyGo;

namespace DeliveryGo
{
    class Program
    {
        static void Main(string[] args)
        {
            TestEtapa1Command();
            Console.WriteLine("\nPrueba de Etapa 1 finalizada. Presione cualquier tecla para salir.");
            Console.ReadKey();
        }

        static void TestEtapa1Command()
        {
            Console.WriteLine("--- INICIANDO PRUEBA DE ETAPA 1: CARRITO CON COMMAND ---");

            // 1. Inicializar CarritoPort
            ICarritoPort carritoPort = new CarritoPort();
            // Necesitamos la instancia de Carrito real para los comandos
            // Esto es un cast para la prueba, en la Facade ya está manejado
            Carrito carritoReceiver = ((CarritoPort)carritoPort).GetCurrentCarritoInstance();

            // Función auxiliar para mostrar el estado actual del carrito
            Action mostrarEstadoCarrito = () =>
            {
                Console.WriteLine("\n--- Estado Actual del Carrito ---");
                var items = ((CarritoPort)carritoPort).GetCurrentItems().ToList();
                if (!items.Any())
                {
                    Console.WriteLine("El carrito está vacío.");
                }
                else
                {
                    foreach (var item in items)
                    {
                        Console.WriteLine($"- SKU: {item.Sku}, Nombre: {item.Name}, Precio: ${item.Price:N2}, Cantidad: {item.Amount}");
                    }
                }
                Console.WriteLine($"Subtotal: ${carritoPort.Subtotal():N2}");
                Console.WriteLine("---------------------------------");
            };

            mostrarEstadoCarrito();

            // --- Escenario de Prueba ---

            Console.WriteLine("\n1. Agregando 'Laptop' (SKU: LPT001, Precio: 1200, Cant: 1)");
            carritoPort.Run(new AgregarItemCommand(carritoReceiver, new Item { Sku = "LPT001", Name = "Laptop", Price = 1200m, Amount = 1 }));
            mostrarEstadoCarrito();

            Console.WriteLine("\n2. Agregando 'Mouse' (SKU: MOU002, Precio: 25, Cant: 2)");
            carritoPort.Run(new AgregarItemCommand(carritoReceiver, new Item { Sku = "MOU002", Name = "Mouse", Price = 25m, Amount = 2 }));
            mostrarEstadoCarrito();

            Console.WriteLine("\n3. Agregando 'Laptop' de nuevo (SKU: LPT001, Precio: 1200, Cant: 1) - Debería sumar cantidad");
            carritoPort.Run(new AgregarItemCommand(carritoReceiver, new Item { Sku = "LPT001", Name = "Laptop", Price = 1200m, Amount = 1 }));
            mostrarEstadoCarrito(); // Laptop debería tener Cantidad: 2

            Console.WriteLine("\n4. Cambiando cantidad de 'Mouse' a 5 (SKU: MOU002)");
            carritoPort.Run(new SetCantidadCommand(carritoReceiver, "MOU002", 5));
            mostrarEstadoCarrito(); // Mouse debería tener Cantidad: 5

            Console.WriteLine("\n5. Deshaciendo última acción (cambio de cantidad de Mouse)");
            carritoPort.Undo();
            mostrarEstadoCarrito(); // Mouse debería volver a Cantidad: 2

            Console.WriteLine("\n6. Deshaciendo acción anterior (agregar Laptop por segunda vez)");
            carritoPort.Undo();
            mostrarEstadoCarrito(); // Laptop debería volver a Cantidad: 1

            Console.WriteLine("\n7. Rehaciendo acción (agregar Laptop por segunda vez)");
            carritoPort.Redo();
            mostrarEstadoCarrito(); // Laptop debería volver a Cantidad: 2

            Console.WriteLine("\n8. Quitando 'Mouse' (SKU: MOU002)");
            carritoPort.Run(new QuitarItemCommand(carritoReceiver, "MOU002"));
            mostrarEstadoCarrito(); // Mouse debería desaparecer

            Console.WriteLine("\n9. Deshaciendo la eliminación de 'Mouse'");
            carritoPort.Undo();
            mostrarEstadoCarrito(); // Mouse debería reaparecer con Cantidad: 2

            Console.WriteLine("\n10. Intentando deshacer sin más acciones");
            carritoPort.Undo(); // Deshace agregar Laptop (segunda vez)
            carritoPort.Undo(); // Deshace agregar Mouse
            carritoPort.Undo(); // Deshace agregar Laptop (primera vez)
            carritoPort.Undo(); // No hay más acciones para deshacer
            mostrarEstadoCarrito(); // Carrito vacío

            Console.WriteLine("\n11. Rehaciendo todas las acciones");
            carritoPort.Redo(); // Agrega Laptop (primera vez)
            carritoPort.Redo(); // Agrega Mouse
            carritoPort.Redo(); // Agrega Laptop (segunda vez)
            carritoPort.Redo(); // Quita Mouse
            carritoPort.Redo(); // No hay más acciones para rehacer
            mostrarEstadoCarrito(); // Carrito con Laptop (2) y Mouse (0) - ¡Ojo! QuitarItemCommand no restaura la cantidad, solo el item.

            Console.WriteLine("\n--- FIN DE PRUEBA DE ETAPA 1 ---");
        }
    }
}

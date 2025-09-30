using AppDeliveyGo;
//using DeliveryGo.UI; // Asumiendo que AppRunner estará en la carpeta UI

namespace AppDeliveryGo
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new AppRunner();
            app.Run();
        }
    
        public class AppRunner
        {
            private CheckoutFacade _facade;
            private PedidoService _pedidoService;
            private ClienteObserver _clienteObserver;
            private LogisticaObserver _logisticaObserver;
            private AuditoriaObserver _auditoriaObserver;

            public AppRunner()
            {
                // 1. Inicializaciones
                ConfigManager.Instance.EnvioGratisDesde = 50000m;
                ConfigManager.Instance.IVA = 0.21m;

                ICarritoPort carrito = new CarritoPort();
                IEnvioStrategy envioInicial = new EnvioMoto(); // Estrategia inicial
                _pedidoService = new PedidoService();

                _clienteObserver = new ClienteObserver();
                _logisticaObserver = new LogisticaObserver();
                _auditoriaObserver = new AuditoriaObserver();

                _clienteObserver.Suscribir(_pedidoService);
                _logisticaObserver.Suscribir(_pedidoService);
                _auditoriaObserver.Suscribir(_pedidoService);

                _facade = new CheckoutFacade(carrito, envioInicial, _pedidoService);
            }

            public void Run()
            {
                Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("       Bienvenido a DeliveryGo         ");
                Console.WriteLine("=======================================");

                bool running = true;
                while (running)
                {
                    MostrarMenu();
                    string? input = Console.ReadLine();
                    if (int.TryParse(input, out int choice))
                    {
                        try
                        {
                            switch (choice)
                            {
                                case 1: AgregarItem(); break;
                                case 2: CambiarCantidadItem(); break;
                                case 3: QuitarItem(); break;
                                case 4: VerTotales(); break;
                                case 5: _facade.UndoCarrito(); Console.WriteLine("Undo realizado."); break;
                                case 6: _facade.RedoCarrito(); Console.WriteLine("Redo realizado."); break;
                                case 7: ElegirEnvio(); break;
                                case 8: PagarPedido(); break;
                                case 9: ConfirmarPedido(); break;
                                case 10: ToggleLogisticaObserver(); break;
                                case 0: running = false; Console.WriteLine("¡Gracias por usar DeliveryGo!"); break;
                                default: Console.WriteLine("Opción no válida. Intente de nuevo."); break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error: {ex.Message}");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Por favor, ingrese un número.");
                    }
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            private void MostrarMenu()
            {
                Console.WriteLine("\n--- Menú Principal ---");
                Console.WriteLine("1. Agregar ítem al carrito");
                Console.WriteLine("2. Cambiar cantidad de ítem");
                Console.WriteLine("3. Quitar ítem del carrito");
                Console.WriteLine("4. Ver subtotal y total (con envío)");
                Console.WriteLine("5. Deshacer última acción del carrito (Undo)");
                Console.WriteLine("6. Rehacer última acción del carrito (Redo)");
                Console.WriteLine("7. Elegir método de envío");
                Console.WriteLine("8. Pagar pedido");
                Console.WriteLine("9. Confirmar pedido");
                Console.WriteLine($"10. {(IsLogisticaSubscribed() ? "Desuscribir" : "Suscribir")} Logística");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
            }

            // --- Métodos de Ayuda para la UI ---
            private string PedirString(string mensaje)
            {
                string? input;
                do
                {
                    Console.Write(mensaje);
                    input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("La entrada no puede estar vacía.");
                    }
                } while (string.IsNullOrWhiteSpace(input));
                return input;
            }

            private decimal PedirDecimal(string mensaje)
            {
                decimal valor;
                string? input;
                do
                {
                    Console.Write(mensaje);
                    input = Console.ReadLine();
                    if (!decimal.TryParse(input, out valor) || valor <= 0)
                    {
                        Console.WriteLine("Entrada inválida. Por favor, ingrese un número decimal positivo.");
                    }
                } while (!decimal.TryParse(input, out valor) || valor <= 0);
                return valor;
            }

            private int PedirInt(string mensaje)
            {
                int valor;
                string? input;
                do
                {
                    Console.Write(mensaje);
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out valor) || valor <= 0)
                    {
                        Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero positivo.");
                    }
                } while (!int.TryParse(input, out valor) || valor <= 0);
                return valor;
            }

            private bool PedirSiNo(string mensaje)
            {
                string? input;
                do
                {
                    Console.Write($"{mensaje} (s/n): ");
                    input = Console.ReadLine()?.ToLower();
                    if (input != "s" && input != "n")
                    {
                        Console.WriteLine("Entrada inválida. Por favor, ingrese 's' o 'n'.");
                    }
                } while (input != "s" && input != "n");
                return input == "s";
            }

            // --- Implementación de Opciones del Menú ---
            private void AgregarItem()
            {
                Console.WriteLine("\n--- Agregar Ítem ---");
                string sku = PedirString("Ingrese SKU del producto: ");
                string nombre = PedirString("Ingrese Nombre del producto: ");
                decimal precio = PedirDecimal("Ingrese Precio del producto: ");
                int cantidad = PedirInt("Ingrese Cantidad: ");

                _facade.AgregarItem(sku, nombre, precio, cantidad);
            }

            private void CambiarCantidadItem()
            {
                Console.WriteLine("\n--- Cambiar Cantidad ---");
                string sku = PedirString("Ingrese SKU del producto a modificar: ");
                int cantidad = PedirInt("Ingrese Nueva Cantidad: ");

                _facade.CambiarCantidad(sku, cantidad);
            }

            private void QuitarItem()
            {
                Console.WriteLine("\n--- Quitar Ítem ---");
                string sku = PedirString("Ingrese SKU del producto a quitar: ");
                _facade.QuitarItem(sku);
            }

            private void VerTotales()
            {
                Console.WriteLine("\n--- Resumen del Carrito ---");
                var items = _facade.GetItemsCarrito().ToList();
                if (!items.Any())
                {
                    Console.WriteLine("El carrito está vacío.");
                    return;
                }

                Console.WriteLine("Ítems en el carrito:");
                foreach (var item in items)
                {
                    Console.WriteLine($"- SKU: {item.Sku}, Nombre: {item.Name}, Precio: ${item.Price:N2}, Cantidad: {item.Amount}");
                }
                Console.WriteLine($"---------------------------------------");
                Console.WriteLine($"Subtotal: ${_facade.GetSubtotalCarrito():N2}");
                Console.WriteLine($"Envío ({_facade.GetNombreEnvioActual()}): ${_facade.CalcularTotal() - _facade.GetSubtotalCarrito():N2}");
                Console.WriteLine($"Total a pagar: ${_facade.CalcularTotal():N2}");
                Console.WriteLine($"Umbral de envío gratis: ${ConfigManager.Instance.EnvioGratisDesde:N2}");
            }

            private void ElegirEnvio()
            {
                Console.WriteLine("\n--- Elegir Método de Envío ---");
                Console.WriteLine("Opciones: [moto], [correo], [retiro]");
                string tipoEnvio = PedirString("Ingrese el tipo de envío: ").ToLower();

                IEnvioStrategy? estrategia = null;
                switch (tipoEnvio)
                {
                    case "moto": estrategia = new EnvioMoto(); break;
                    case "correo": estrategia = new EnvioCorreo(); break;
                    case "retiro": estrategia = new RetiroEnTienda(); break;
                    default: Console.WriteLine("Tipo de envío no reconocido."); return;
                }

                _facade.ElegirEnvio(estrategia);
                Console.WriteLine($"Envío actual: {_facade.GetNombreEnvioActual()}.");
                Console.WriteLine($"Recordatorio: Envío gratis desde ${ConfigManager.Instance.EnvioGratisDesde:N2} (aplica a Correo).");
            }

            private void PagarPedido()
            {
                Console.WriteLine("\n--- Pagar Pedido ---");
                if (!_facade.GetItemsCarrito().Any())
                {
                    Console.WriteLine("No hay ítems en el carrito para pagar.");
                    return;
                }

                Console.WriteLine($"Total a pagar (sin IVA/cupón aún): ${_facade.CalcularTotal():N2}");

                Console.WriteLine("Métodos de pago: [tarjeta], [mp], [transf], [mp-adapter]");
                string tipoPago = PedirString("Ingrese el método de pago: ").ToLower();

                bool aplicarIVA = PedirSiNo("¿Aplicar IVA?");
                decimal? cupon = null;
                if (PedirSiNo("¿Aplicar cupón?"))
                {
                    decimal porcentaje = PedirDecimal("Ingrese el porcentaje del cupón (ej. 0.10 para 10%): ");
                    if (porcentaje > 0 && porcentaje < 1)
                    {
                        cupon = porcentaje;
                    }
                    else
                    {
                        Console.WriteLine("Porcentaje de cupón inválido. Debe ser entre 0 y 1 (ej. 0.10). No se aplicará.");
                    }
                }

                bool pagoExitoso = _facade.Pagar(tipoPago, aplicarIVA, cupon);

                if (pagoExitoso)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("¡Pago aprobado!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Pago rechazado.");
                    Console.ResetColor();
                }
            }

            private void ConfirmarPedido()
            {
                Console.WriteLine("\n--- Confirmar Pedido ---");
                if (!_facade.GetItemsCarrito().Any())
                {
                    Console.WriteLine("No se puede confirmar un pedido sin ítems en el carrito.");
                    return;
                }

                string direccion = PedirString("Ingrese la dirección de envío: ");
                string tipoPagoRegistrado = PedirString("Ingrese el tipo de pago registrado (ej. 'Tarjeta', 'MP'): ");

                try
                {
                    Pedido pedidoConfirmado = _facade.ConfirmarPedido(direccion, tipoPagoRegistrado);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Pedido {pedidoConfirmado.Id} confirmado exitosamente. Estado final: {pedidoConfirmado.Estado}.");
                    Console.ResetColor();
                }
                catch (InvalidOperationException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error al confirmar pedido: {ex.Message}");
                    Console.ResetColor();
                }
            }

            private bool IsLogisticaSubscribed()
            {
                // Esto es un hack para la demo, ya que no hay un método directo en PedidoService para preguntar
                // En un sistema real, el Subject podría tener un método para listar suscriptores o un flag.
                // Para esta demo, asumimos que si el evento no es null, está suscrito.
                // Una forma más robusta sería mantener una lista de suscriptores en AppRunner y verificar ahí.
                var eventField = typeof(PedidoService).GetField("EstadoCambiado", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                var eventDelegate = (EventHandler<PedidoChangedEventArgs>?)eventField?.GetValue(_pedidoService);
                return eventDelegate != null && eventDelegate.GetInvocationList().Any(d => d.Target == _logisticaObserver);
            }


            private void ToggleLogisticaObserver()
            {
                if (IsLogisticaSubscribed())
                {
                    _logisticaObserver.Desuscribir(_pedidoService);
                    Console.WriteLine("LogisticaObserver desuscrito. Los cambios de estado ya no lo notificarán.");
                }
                else
                {
                    _logisticaObserver.Suscribir(_pedidoService);
                    Console.WriteLine("LogisticaObserver suscrito. Los cambios de estado ahora lo notificarán.");
                }
                Console.WriteLine("Intente confirmar un pedido para ver el efecto.");
            }
        }
    }


}

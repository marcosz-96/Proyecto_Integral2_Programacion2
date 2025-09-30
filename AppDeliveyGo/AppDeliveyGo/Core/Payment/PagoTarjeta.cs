namespace AppDeliveyGo
{
    public class PagoTarjeta : IPago
    {
        public string Nombre => "Tarjeta de Crédito/Débito";
        public bool Procesar(decimal monto)
        {
            System.Console.WriteLine($"Procesando pago con Tarjeta por ${monto:N2}");
            return true;
        }
    }
}

namespace AppDeliveyGo
{
    public class PagoMp : IPago
    {
        public string Nombre => "Mercado Pago (Directo)";
        public bool Procesar(decimal monto)
        {
            System.Console.WriteLine($"Procesando pago con Mercado Pago (Directo) por ${monto:N2}");
            return true;
        }
    }
}

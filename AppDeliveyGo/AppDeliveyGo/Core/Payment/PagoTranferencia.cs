namespace AppDeliveyGo
{
    public class PagoTransferencia : IPago
    {
        public string Nombre => "Transferencia Bancaria";
        public bool Procesar(decimal monto)
        {
            System.Console.WriteLine($"Procesando pago con Transferencia por ${monto:N2}");
            return true;
        }
    }
}

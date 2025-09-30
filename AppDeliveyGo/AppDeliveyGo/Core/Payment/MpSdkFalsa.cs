namespace AppDeliveyGo
{
    public class MpSdkFalsa
    {
        public bool Cobrar(decimal monto)
        {
            System.Console.WriteLine($"Simulando cobro con Mercado Pago SDK Falsa por ${monto:N2}");
            return true; // Siempre exitoso para la demo
        }
    }
}

namespace AppDeliveyGo
{
    public class RetiroEnTienda : IEnvioStrategy
    {
        public string Nombre => "Retiro en Tienda";
        public decimal Calcular(decimal subtotal)
        {
            return 0m;
        }
    }
}

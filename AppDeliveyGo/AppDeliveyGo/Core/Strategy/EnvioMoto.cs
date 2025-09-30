namespace AppDeliveyGo
{
    public class EnvioMoto : IEnvioStrategy
    {
        public string Nombre => "Moto";
        public decimal Calcular(decimal subtotal)
        {
            return 1200m;
        }
    }
}

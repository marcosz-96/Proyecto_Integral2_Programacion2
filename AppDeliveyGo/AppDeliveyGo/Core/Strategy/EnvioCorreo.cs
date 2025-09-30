namespace AppDeliveyGo
{
    public class EnvioCorreo : IEnvioStrategy
    {
        public string Nombre => "Correo";
        public decimal Calcular(decimal subtotal)
        {
            if (subtotal >= ConfigManager.Instance.EnvioGratisDesde)
            {
                return 0m;
            }
            return 3500m;
        }
    }
}

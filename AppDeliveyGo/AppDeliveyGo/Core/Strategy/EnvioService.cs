namespace AppDeliveyGo
{
    public class EnvioService
    {
        private IEnvioStrategy _actualStrategy;

        public EnvioService(IEnvioStrategy initialStrategy)
        {
            _actualStrategy = initialStrategy;
        }

        public void SetStrategy(IEnvioStrategy newStrategy)
        {
            _actualStrategy = newStrategy;
        }

        public decimal Calcular(decimal subtotal)
        {
            return _actualStrategy.Calcular(subtotal);
        }

        public string NombreActual => _actualStrategy.Nombre;
    }
}

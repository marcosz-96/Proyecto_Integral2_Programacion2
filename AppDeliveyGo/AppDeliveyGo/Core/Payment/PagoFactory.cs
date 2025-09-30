namespace AppDeliveyGo
{
    public static class PagoFactory
    {
        public static IPago Create(string tipoPago)
        {
            switch (tipoPago.ToLower())
            {
                case "tarjeta":
                    return new PagoTarjeta();
                case "transf":
                    return new PagoTransferencia();
                case "mp":
                    return new PagoMp();
                // "mp-adapter" se creará directamente en Facade, no aquí
                default:
                    throw new ArgumentException($"Tipo de pago '{tipoPago}' no soportado por la fábrica.");
            }
        }
    }
}

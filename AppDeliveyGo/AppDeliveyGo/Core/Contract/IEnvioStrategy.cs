namespace AppDeliveyGo
{
    public interface IEnvioStrategy
    {
        decimal Calcular(decimal subtotal);
        string Nombre { get; }
    }
}

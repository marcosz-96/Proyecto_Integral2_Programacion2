namespace AppDeliveyGo
{
    public class PagoConCupon : IPago
    {
        private IPago _innerPago;
        private decimal _porcentajeCupon; // Ej: 0.10 para 10%
        public PagoConCupon(IPago innerPago, decimal porcentajeCupon)
        {
            _innerPago = innerPago;
            _porcentajeCupon = porcentajeCupon;
        }
        public string Nombre => $"{_innerPago.Nombre} con Cupón";
        public bool Procesar(decimal monto)
        {
            decimal montoConDescuento = monto * (1 - _porcentajeCupon);
            System.Console.WriteLine($"Aplicando cupón ({_porcentajeCupon * 100}%) al monto: ${monto:N2} -> ${montoConDescuento:N2}");
            return _innerPago.Procesar(montoConDescuento);
        }
    }
}

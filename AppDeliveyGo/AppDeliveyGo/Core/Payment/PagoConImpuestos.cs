namespace AppDeliveyGo
{
    public class PagoConImpuestos : IPago
    {
        private IPago _innerPago;
        public PagoConImpuestos(IPago innerPago)
        {
            _innerPago = innerPago;
        }
        public string Nombre => $"{_innerPago.Nombre} + IVA";
        public bool Procesar(decimal monto)
        {
            decimal iva = ConfigManager.Instance.IVA;
            decimal montoConIVA = monto * (1 + iva);
            System.Console.WriteLine($"Aplicando IVA ({iva * 100}%) al monto: ${monto:N2} -> ${montoConIVA:N2}");
            return _innerPago.Procesar(montoConIVA);
        }
    }
}

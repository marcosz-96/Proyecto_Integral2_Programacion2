namespace AppDeliveyGo
{
    public class PagoAdapterMp : IPago
    {
        private MpSdkFalsa _sdk;
        public PagoAdapterMp(MpSdkFalsa sdk)
        {
            _sdk = sdk;
        }
        public string Nombre => "Mercado Pago (via Adapter)";
        public bool Procesar(decimal monto)
        {
            System.Console.WriteLine("Adaptando llamada a MpSdkFalsa...");
            return _sdk.Cobrar(monto);
        }
    }
}

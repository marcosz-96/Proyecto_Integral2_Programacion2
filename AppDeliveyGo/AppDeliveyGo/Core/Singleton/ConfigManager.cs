namespace AppDeliveyGo
{
    public sealed class ConfigManager
    {
        private static readonly Lazy<ConfigManager> _inst = new Lazy<ConfigManager>(() => new ConfigManager());

        public static ConfigManager Instance => _inst.Value;

        private ConfigManager() { } // Esto asegura una única instancia

        public decimal EnvioGratisDesde { get; set; } = 50000m;
        public decimal IVA { get; set; } = 0.21m;

    }
}

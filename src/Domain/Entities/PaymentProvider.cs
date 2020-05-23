namespace OmniMasterFX.Domain.Entities
{
    public class PaymentProvider
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PaymentGatewayUrl { get; set; }
    }
}
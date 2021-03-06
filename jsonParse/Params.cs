namespace DeserializeExtra
{
    internal class Params
    {
        public Params()
        {
        }

        public string requestDate { get; set; }
        public int countPartner { get; set; }
        public string partnerId { get; set; }
        public bool isValidRules { get; set; }
        public string PaymentMethod { get; set; }
        public string ManagerName { get; set; }
        public string AffType { get; set; }
        public string affName { get; set; }
        public string amount { get; set; }
        public string pBalance { get; set; }
        public string firstUnpaid { get; set; }
    }
}
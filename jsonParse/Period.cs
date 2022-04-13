using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DeserializeExtra
{
    public class Period
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("isActive")]
        public int IsActive { get; set; }

        [JsonPropertyName("paymentsType")]
        public string PaymentsType { get; set; }

        [JsonPropertyName("boSoWebpush")]
        public string BoSoWebpush { get; set; }

        [JsonPropertyName("payoutCompanyName")]
        public string PayoutCompanyName { get; set; }

        [JsonPropertyName("payoutCompanyId")]
        public object PayoutCompanyId { get; set; }

        [JsonPropertyName("paymentComment")]
        public string PaymentComment { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("paymentMinAmount")]
        public string PaymentMinAmount { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("amountExt")]
        public string AmountExt { get; set; }

        [JsonPropertyName("leads")]
        public int Leads { get; set; }

        [JsonPropertyName("pBalance")]
        public string PBalance { get; set; }

        [JsonPropertyName("payout")]
        public string Payout { get; set; }

        [JsonPropertyName("lastUnpaid")]
        public object LastUnpaid { get; set; }

        [JsonPropertyName("paymentInfoId")]
        public int PaymentInfoId { get; set; }

        [JsonPropertyName("paymentMethod")]
        public string PaymentMethod { get; set; }

        [JsonPropertyName("lastPaid")]
        public object LastPaid { get; set; }

        [JsonPropertyName("firstUnpaid")]
        public string FirstUnpaid { get; set; }

        [JsonPropertyName("manager")]
        public string Manager { get; set; }

        [JsonPropertyName("periodFrom")]
        public string PeriodFrom { get; set; }

        [JsonPropertyName("periodTo")]
        public string PeriodTo { get; set; }

        [JsonPropertyName("start_date")]
        public string StartDate { get; set; }

        [JsonPropertyName("isValidPayment")]
        public bool IsValidPayment { get; set; }

        [JsonPropertyName("requestId")]
        public string RequestId { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("periods")]
        public List<Period> Periods { get; set; }
    }


}

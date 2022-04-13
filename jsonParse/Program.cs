using Newtonsoft.Json;
using System;

namespace jsonParse
{
    class Program
    {
        static void Main(string[] args)
        {

            string myJson = @"{
""message"":""OK"",
  ""periods"":[
  {
    ""id"":340125039,
    ""owner_id"":34254853,
    ""artist"":""IOWA"",
    ""title"":""Маршрутка"",
    ""duration"":190,
    ""url"":""http:\/\/cs7-5v4.vk-cdn.net\/p12\/630de313d73392.mp3?extra=fNremCtKgl4pnCbyZ0q-LOBIfvRoUf5QGo8oWwYrOCza6AlSUOdYIImUideFd3hpPa325ckSD_c3zQ5FNluMS80lrSJiM6FC"",
    ""genre_id"":9
  },
  {
    ""id"":340120602,
    ""owner_id"":34254853,
    ""artist"":""Stromae"",
    ""title"":""Tous Les Memes"",
    ""duration"":168,
    ""url"":""http:\/\/cs7-1v4.vk-cdn.net\/p18\/600b1a66ef64d6.mp3?extra=GNP79R4nHR39dY50YJ_ddDxEuX6SQcxtG3nCgzI0LdvxoaLh5lQ2qZqqpABCqPoXOISyNzWOqMZx4_nTL3bQ31i57z-UXl4V"",
    ""lyrics_id"":99395752

  }
  ]
}";

            Period period = new Period()
            {
                type = "",
                status = "",
                isActive = 1,
                paymentsType = "",
                boSoWebpush = "",
                payoutCompanyName = "",
                payoutCompanyId = 1,
                paymentComment = "",
                name = "",
                paymentMinAmount = "",
                id = "",
                amount = "",
                amountExt = "",
                leads = 1,
                pBalance = "",
                payout = "",
                lastUnpaid = "",
                paymentInfoId = 1,
                paymentMethod = "",
                lastPaid = "",
                firstUnpaid = "",
                manager = "",
                periodFrom = "",
                periodTo = "",
                start_date = "",
                isValidPayment = true,
                requestId = "",
            };

            Period periods = JsonConvert.DeserializeObject<Period>(myJson);
            
            Console.WriteLine($"{periods.id}");
        }


        public class Rootobject
        {
            public string message { get; set; }
            public Period[] periods { get; set; }
        }

        public class Period
        {
            public string type { get; set; }
            public string status { get; set; }
            public int isActive { get; set; }
            public string paymentsType { get; set; }
            public string boSoWebpush { get; set; }
            public string payoutCompanyName { get; set; }
            public int? payoutCompanyId { get; set; }
            public string paymentComment { get; set; }
            public string name { get; set; }
            public string paymentMinAmount { get; set; }
            public string id { get; set; }
            public string amount { get; set; }
            public string amountExt { get; set; }
            public int leads { get; set; }
            public string pBalance { get; set; }
            public string payout { get; set; }
            public string lastUnpaid { get; set; }
            public int paymentInfoId { get; set; }
            public string paymentMethod { get; set; }
            public string lastPaid { get; set; }
            public string firstUnpaid { get; set; }
            public string manager { get; set; }
            public string periodFrom { get; set; }
            public string periodTo { get; set; }
            public string start_date { get; set; }
            public bool isValidPayment { get; set; }
            public string requestId { get; set; }

            public override string ToString()
            {
                return string.Format("{0}", id);
            }
        }

    }
}

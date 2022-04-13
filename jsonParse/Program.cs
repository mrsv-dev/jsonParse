using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DeserializeExtra
{
    public class Program : LoggerInfo
    {
 
        public static void Main()
        {
            string jsonString =
                                @"{
                                    ""message"": ""OK"",
                                    ""periods"": [
                                        {
                                            ""type"": ""ps"",
                                            ""status"": ""Approve"",
                                            ""isActive"": 1,
                                            ""paymentsType"": ""vacation"",
                                            ""boSoWebpush"": ""off"",
                                            ""payoutCompanyName"": """",
                                            ""payoutCompanyId"": null,
                                            ""paymentComment"": ""тестовый акк, не платим (с ноября 2021 нет начислений)"",
                                            ""name"": ""Sergey Kruglyi"",
                                            ""paymentMinAmount"": ""0.00"",
                                            ""id"": ""9e9a06c6"",
                                            ""amount"": ""1.65"",
                                            ""amountExt"": ""0.00"",
                                            ""leads"": 165,
                                            ""pBalance"": ""1.65"",
                                            ""payout"": ""1.65"",
                                            ""lastUnpaid"": null,
                                            ""paymentInfoId"": 40640,
                                            ""paymentMethod"": ""No method"",
                                            ""lastPaid"": null,
                                            ""firstUnpaid"": ""2021-10-25"",
                                            ""manager"": ""QUARANTINE INT"",
                                            ""periodFrom"": ""1900-01-01"",
                                            ""periodTo"": ""2022-03-31"",
                                            ""start_date"": ""2021-10-25"",
                                            ""isValidPayment"": true,
                                            ""requestId"": ""6b84e04c-e8d1-4f37-b3da-6349955240a2""
                                        },
                                        {
                                            ""type"": ""tp"",
                                            ""status"": ""Approve"",
                                            ""isActive"": 1,
                                            ""paymentsType"": ""vacation"",
                                            ""boSoWebpush"": ""off"",
                                            ""payoutCompanyName"": """",
                                            ""payoutCompanyId"": null,
                                            ""paymentComment"": ""не платим (с августа 2021 нет начислений)"",
                                            ""name"": ""Account SpCH"",
                                            ""paymentMinAmount"": ""0.00"",
                                            ""id"": ""fe7a6e71"",
                                            ""amount"": ""235.54"",
                                            ""amountExt"": ""235.54"",
                                            ""leads"": 165,
                                            ""pBalance"": ""235.54"",
                                            ""payout"": ""235.54"",
                                            ""lastUnpaid"": null,
                                            ""paymentInfoId"": 40641,
                                            ""paymentMethod"": ""No method"",
                                            ""lastPaid"": null,
                                            ""firstUnpaid"": ""2021-04-05"",
                                            ""manager"": ""QUARANTINE INT"",
                                            ""periodFrom"": ""1900-01-01"",
                                            ""periodTo"": ""2022-03-31"",
                                            ""start_date"": ""2021-04-05"",
                                            ""isValidPayment"": false,
                                            ""requestId"": ""6b84e04c-e8d1-4f37-b3da-6349955240a2""
                                        }
                                    ]
                                }";

            Root root = System.Text.Json.JsonSerializer.Deserialize<Root>(jsonString);
            MyLogger(root);

            Console.ReadKey(true);
        }
    }
}

using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;

namespace DeserializeExtra
{
    public class LoggerInfo
    {
        private static List<Params> myCollection = new List<Params>();
        public static readonly ILogger _logger = new LoggerConfiguration().WriteTo.RollingFile(pathFormat: "Log_request.json")
                                                              .WriteTo.Console()
                                                               .WriteTo.Debug()
                                                             .CreateLogger();

        public static void MyLogger(Root root)
        {
            foreach (var period in root.Periods)
            {
                if (period.IsValidPayment == false)
                {
                    var param = new Params()
                    {
                        requestDate = DateTime.Now.ToString(),
                        countPartner = root.Periods.Count,
                        partnerId = period.Id,
                        isValidRules = period.IsValidPayment,
                        PaymentMethod = period.PaymentMethod
                    };
                    string serializedAnswer = JsonConvert.SerializeObject(param);
                    _logger.Information(serializedAnswer);
                    myCollection.Add(param);
                }
                else
                {

                }
            }
        }
    }
}
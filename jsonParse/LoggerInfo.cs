using Newtonsoft.Json;
using Serilog;
using System;

namespace DeserializeExtra
{
    public class LoggerInfo
    {
        private static Params myCollection;
        public static readonly ILogger _logger = new LoggerConfiguration().WriteTo.RollingFile(pathFormat: "Log_request.json")
                                                              .WriteTo.Console()
                                                               .WriteTo.Debug()
                                                             .CreateLogger();

        public static void MyLogger(Root root, Period period)
        {
            myCollection = new Params()
            {
                requestDate = DateTime.Now.ToString(),
                countPartner = root.Periods.Count,
                partnerId = period.Id,
                isValidRules = period.IsValidPayment,
                PaymentMethod = period.PaymentMethod
            };
            string serializedAnswer = JsonConvert.SerializeObject(myCollection);
            _logger.Information(serializedAnswer);
        }
    }
}
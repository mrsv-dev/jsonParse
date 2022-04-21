using Newtonsoft.Json;
using Npgsql;
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
                       // countPartner = root.Periods.Count,
                        partnerId = period.Id,
                        isValidRules = period.IsValidPayment,
                        PaymentMethod = period.PaymentMethod,
                        ManagerName = period.Manager,
                        AffType = period.Type

                    };

                    string serializedAnswer = JsonConvert.SerializeObject(param);
                    _logger.Information(serializedAnswer);
                    myCollection.Add(param);

                    string connectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=qwsazx12;Database=mrfreemaninc;";
                    NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
                    npgSqlConnection.Open();
                    _logger.Debug("Соединение с БД открыто");

                    using (var command = new NpgsqlCommand("insert into getValidAffiliates(affId, paymentMethod, isValidRules, ManagerName, AffType) VALUES (@n1, @n2, @n3, @n4, @n5)", npgSqlConnection))
                    {
                        command.Parameters.AddWithValue("n1", period.Id);
                        command.Parameters.AddWithValue("n2", period.PaymentMethod);
                        command.Parameters.AddWithValue("n3", period.IsValidPayment);
                        command.Parameters.AddWithValue("n4", period.Manager);
                        command.Parameters.AddWithValue("n5", period.Type);

                        int nRows = command.ExecuteNonQuery();
                        Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                    }
                }
                else
                {
                    
                }
            }
        }
    }
}
using ChoETL;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Npgsql;
using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;

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
                        affName = period.Name,
                        isValidRules = period.IsValidPayment,
                        PaymentMethod = period.PaymentMethod,
                        ManagerName = period.Manager,
                        AffType = period.Type,
                        amount = period.Amount,
                        pBalance = period.PBalance,
                        firstUnpaid = period.FirstUnpaid

                    };

                    string serializedAnswer = JsonConvert.SerializeObject(param);
                    _logger.Information(serializedAnswer);
                    myCollection.Add(param);

                    // NpgsqlConnection npgSqlConnection = ConnectToPostgres();

                    InsertToMysql(period);

                    // InsertToPostgres(period, npgSqlConnection);
                }
                else
                {
                    
                }
            }
        }

        private static void InsertToPostgres(Period period, NpgsqlConnection npgSqlConnection)
        {
            using (var command = new NpgsqlCommand("insert into getValidAffiliates(affId, affName, paymentMethod, isValidRules, ManagerName, AffType, amount,pBalance,firstUnpaid) VALUES (@n1, @n2, @n3, @n4, @n5, @n6, @n7, @n8, @n9)", npgSqlConnection))
            {
                var cultureInfo = new CultureInfo("de-DE");

                command.Parameters.AddWithValue("n1", period.Id);
                command.Parameters.AddWithValue("n2", period.Name);
                command.Parameters.AddWithValue("n3", period.PaymentMethod);
                command.Parameters.AddWithValue("n4", period.IsValidPayment);
                command.Parameters.AddWithValue("n5", period.Manager);
                command.Parameters.AddWithValue("n6", period.Type);
                command.Parameters.AddWithValue("n7", period.Amount);
                command.Parameters.AddWithValue("n8", period.PBalance);
                command.Parameters.AddWithValue("n9", DateTime.Parse(period.FirstUnpaid, cultureInfo));



                int nRows = command.ExecuteNonQuery();
                _logger.Debug(String.Format("Number of rows inserted={0}", nRows));

            }
        }

        private static void InsertToMysql(Period period)
        {
            MySqlConnection conn = connectToMySQL();
            conn.Open();

            try
            {

                string sql = "insert into mrfreemaninc.getvalidaffiliates(affId, affName, paymentMethod, isValidRules, ManagerName, AffType, amount,pBalance,firstUnpaid) " +
                    "VALUES (@n1, @n2, @n3, @n4, @n5, @n6, @n7, @n8, @n9)";


                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                var cultureInfo = new CultureInfo("de-DE");


                cmd.Parameters.AddWithValue("n1", period.Id);
                cmd.Parameters.AddWithValue("n2", period.Name);
                cmd.Parameters.AddWithValue("n3", period.PaymentMethod);
                cmd.Parameters.AddWithValue("n4", period.IsValidPayment);
                cmd.Parameters.AddWithValue("n5", period.Manager);
                cmd.Parameters.AddWithValue("n6", period.Type);
                cmd.Parameters.AddWithValue("n7", period.Amount);
                cmd.Parameters.AddWithValue("n8", period.PBalance);
                cmd.Parameters.AddWithValue("n9", DateTime.Parse(period.FirstUnpaid, cultureInfo));
                // Выполнить Command (использованная для  delete, insert, update).
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }

        private static NpgsqlConnection ConnectToPostgres()
        {
            string connectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=qwsazx12;Database=mrfreemaninc;";
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
            _logger.Debug("Соединение с БД открыто");
            return npgSqlConnection;
        }

        private static MySqlConnection connectToMySQL()
        {
            string connStr = "server=mrsv.site;user=mrsvdev;port=3306;database=mrfreemaninc;password=uf4YUpfhRaPn2G6n;";
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn;
        }
    }
}
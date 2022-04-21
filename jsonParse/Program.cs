using ChoETL;
using Newtonsoft.Json;
using Npgsql;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeserializeExtra
{
    public class Program : LoggerInfo
    {
 
        public static async Task Main()
        {
            _logger.Warning("Start!");
            for (int it = 0; it < 4; it++)
            {
                //string[] affType = { "affType_Topoffers", "affType_AdsEmpire Direct", "affType_AdsEmpire Smartlink", "affType_Adromeda" };
                //string affTypes = affType[it];
                //NpgsqlConnection npgSqlConnection = ConnectToDataBase();
                //await GetDataFromDBAsync(npgSqlConnection, affTypes);
                await requestPayAff(it);
            }
            _logger.Warning("End!");
        }

        private static async Task requestPayAff(int it)
        {
            string[] bodyJson_1 = { @"{""form"":{""dateFrom"":""2022-04-18"",""dateTo"":""2022-04-24"",""name"":"""",""id"":""""},""query"":{},""periodResolve"":true,""filters"":{""paymentsType"":[{""id"":""paymentsType_Monthly""},{""id"":""paymentsType_Weekly""},{""id"":""paymentsType_Bimonthly""},{""id"":""paymentsType_Vacation""},{""id"":""paymentsType_Netting""},{""id"":""paymentsType_All""}],""paymentMethods"":[{""id"":""paymentMethods_Bank Wire Transfer""},{""id"":""paymentMethods_Paxum""},{""id"":""paymentMethods_WebMoney""},{""id"":""paymentMethods_QIWI""},{""id"":""paymentMethods_Bitcoin""},{""id"":""paymentMethods_Yandex.Money""},{""id"":""paymentMethods_capitalist""},{""id"":""paymentMethods_payoneer""},{""id"":""paymentMethods_paypal""},{""id"":""paymentMethods_ePayments e-Wallet""},{""id"":""paymentMethods_Genome""},{""id"":""paymentMethods_Paysera""},{""id"":""paymentMethods_No method""},{""id"":""paymentMethods_All""}],""affStatus"":[{""id"":""affStatus_Approve""},{""id"":""affStatus_Decline""},{""id"":""affStatus_Suspended""},{""id"":""affStatus_All""}],""affType"":[{""id"":""affType_Topoffers""}],""markAsPending"":[],""currentSort"":""amount"",""direction"":null,""counter"":0}}",
                @"{""form"":{""dateFrom"":""2022-04-18"",""dateTo"":""2022-04-24"",""name"":"""",""id"":""""},""query"":{},""periodResolve"":true,""filters"":{""paymentsType"":[{""id"":""paymentsType_Monthly""},{""id"":""paymentsType_Weekly""},{""id"":""paymentsType_Bimonthly""},{""id"":""paymentsType_Vacation""},{""id"":""paymentsType_Netting""},{""id"":""paymentsType_All""}],""paymentMethods"":[{""id"":""paymentMethods_Bank Wire Transfer""},{""id"":""paymentMethods_Paxum""},{""id"":""paymentMethods_WebMoney""},{""id"":""paymentMethods_QIWI""},{""id"":""paymentMethods_Bitcoin""},{""id"":""paymentMethods_Yandex.Money""},{""id"":""paymentMethods_capitalist""},{""id"":""paymentMethods_payoneer""},{""id"":""paymentMethods_paypal""},{""id"":""paymentMethods_ePayments e-Wallet""},{""id"":""paymentMethods_Genome""},{""id"":""paymentMethods_Paysera""},{""id"":""paymentMethods_No method""},{""id"":""paymentMethods_All""}],""affStatus"":[{""id"":""affStatus_Approve""},{""id"":""affStatus_Decline""},{""id"":""affStatus_Suspended""},{""id"":""affStatus_All""}],""affType"":[{""id"":""affType_AdsEmpire Direct""}],""markAsPending"":[],""currentSort"":""amount"",""direction"":null,""counter"":0}}",
                @"{""form"":{""dateFrom"":""2022-04-18"",""dateTo"":""2022-04-24"",""name"":"""",""id"":""""},""query"":{},""periodResolve"":true,""filters"":{""paymentsType"":[{""id"":""paymentsType_Monthly""},{""id"":""paymentsType_Weekly""},{""id"":""paymentsType_Bimonthly""},{""id"":""paymentsType_Vacation""},{""id"":""paymentsType_Netting""},{""id"":""paymentsType_All""}],""paymentMethods"":[{""id"":""paymentMethods_Bank Wire Transfer""},{""id"":""paymentMethods_Paxum""},{""id"":""paymentMethods_WebMoney""},{""id"":""paymentMethods_QIWI""},{""id"":""paymentMethods_Bitcoin""},{""id"":""paymentMethods_Yandex.Money""},{""id"":""paymentMethods_capitalist""},{""id"":""paymentMethods_payoneer""},{""id"":""paymentMethods_paypal""},{""id"":""paymentMethods_ePayments e-Wallet""},{""id"":""paymentMethods_Genome""},{""id"":""paymentMethods_Paysera""},{""id"":""paymentMethods_No method""},{""id"":""paymentMethods_All""}],""affStatus"":[{""id"":""affStatus_Approve""},{""id"":""affStatus_Decline""},{""id"":""affStatus_Suspended""},{""id"":""affStatus_All""}],""affType"":[{""id"":""affType_AdsEmpire Smartlink""}],""markAsPending"":[],""currentSort"":""amount"",""direction"":null,""counter"":0}}",
                @"{""form"":{""dateFrom"":""2022-04-18"",""dateTo"":""2022-04-24"",""name"":"""",""id"":""""},""query"":{},""periodResolve"":true,""filters"":{""paymentsType"":[{""id"":""paymentsType_Monthly""},{""id"":""paymentsType_Weekly""},{""id"":""paymentsType_Bimonthly""},{""id"":""paymentsType_Vacation""},{""id"":""paymentsType_Netting""},{""id"":""paymentsType_All""}],""paymentMethods"":[{""id"":""paymentMethods_Bank Wire Transfer""},{""id"":""paymentMethods_Paxum""},{""id"":""paymentMethods_WebMoney""},{""id"":""paymentMethods_QIWI""},{""id"":""paymentMethods_Bitcoin""},{""id"":""paymentMethods_Yandex.Money""},{""id"":""paymentMethods_capitalist""},{""id"":""paymentMethods_payoneer""},{""id"":""paymentMethods_paypal""},{""id"":""paymentMethods_ePayments e-Wallet""},{""id"":""paymentMethods_Genome""},{""id"":""paymentMethods_Paysera""},{""id"":""paymentMethods_No method""},{""id"":""paymentMethods_All""}],""affStatus"":[{""id"":""affStatus_Approve""},{""id"":""affStatus_Decline""},{""id"":""affStatus_Suspended""},{""id"":""affStatus_All""}],""affType"":[{""id"":""affType_Adromeda""}],""markAsPending"":[],""currentSort"":""amount"",""direction"":null,""counter"":0}}"};

            var content = new StringContent(bodyJson_1[it], Encoding.UTF8, "application/json"); ;
            var _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("cookie", "connect.sid=s%3AiimryWz6qqkWuHRzifL_v-2LcZ-6tbbW.ncL3n93j1mfNiQTku2u8Wk%2F07GYwJ0gRZ32bKoGPi0U; token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6NzM3MSwiaWF0IjoxNjQ5NDAyMDY1LCJleHAiOjE3MDk3MzYwNjV9.B7L_qBkIY69yp7n1LDD132WoEqsuCEi997_gECNX9H8; AWSALB=kXvnZl/ERP5sX8OVWBkML6og/uQz9a8b6ke5kFjrE3Z/C+qpIf9G75E8VfP999+wjXJHQIa559NBNIjxPUBbDGWwCb7VYlNoiiNw/rWRtJqCSLiC52C5IdvEqUVK; AWSALBCORS=kXvnZl/ERP5sX8OVWBkML6og/uQz9a8b6ke5kFjrE3Z/C+qpIf9G75E8VfP999+wjXJHQIa559NBNIjxPUBbDGWwCb7VYlNoiiNw/rWRtJqCSLiC52C5IdvEqUVK; AWSALB=QIJryvOYFdw0FId0LQ8iLG9opUoeFQXu5jTCNg6U2hvlTCfLd1AOwkmbQ/zJzSau2oWgQL2Cb5wW6gDRx0lwRzrMIgLqzdFbRaPtAsawTOlJzjukpZT/RqNtXrxS; AWSALBCORS=QIJryvOYFdw0FId0LQ8iLG9opUoeFQXu5jTCNg6U2hvlTCfLd1AOwkmbQ/zJzSau2oWgQL2Cb5wW6gDRx0lwRzrMIgLqzdFbRaPtAsawTOlJzjukpZT/RqNtXrxS; connect.sid=s%3A8up6LhkyUZ3F23c75ZihoY-iSfjxIybu.IyI6ntD6pIUwymMBq50nOpfWEj2m9ordZXziLZnvUAc");

            var request = await _httpClient.PostAsync("https://admin-dmp.insigit.com/cpa/payments", content);
            Root root = System.Text.Json.JsonSerializer.Deserialize<Root>(await request.Content.ReadAsStringAsync());
            MyLogger(root);
            string ans = await request.Content.ReadAsStringAsync();
        }

        private static async Task GetDataFromDBAsync(NpgsqlConnection npgSqlConnection, string affTypes)
        {

            using var command = new NpgsqlCommand($"SELECT * FROM requestPayAff where affType = '{affTypes}' ", npgSqlConnection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var content = new StringContent(reader.GetString(2), Encoding.UTF8, "application/json"); ;
                var _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Add("cookie", "connect.sid=s%3AiimryWz6qqkWuHRzifL_v-2LcZ-6tbbW.ncL3n93j1mfNiQTku2u8Wk%2F07GYwJ0gRZ32bKoGPi0U; token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6NzM3MSwiaWF0IjoxNjQ5NDAyMDY1LCJleHAiOjE3MDk3MzYwNjV9.B7L_qBkIY69yp7n1LDD132WoEqsuCEi997_gECNX9H8; AWSALB=kXvnZl/ERP5sX8OVWBkML6og/uQz9a8b6ke5kFjrE3Z/C+qpIf9G75E8VfP999+wjXJHQIa559NBNIjxPUBbDGWwCb7VYlNoiiNw/rWRtJqCSLiC52C5IdvEqUVK; AWSALBCORS=kXvnZl/ERP5sX8OVWBkML6og/uQz9a8b6ke5kFjrE3Z/C+qpIf9G75E8VfP999+wjXJHQIa559NBNIjxPUBbDGWwCb7VYlNoiiNw/rWRtJqCSLiC52C5IdvEqUVK; AWSALB=QIJryvOYFdw0FId0LQ8iLG9opUoeFQXu5jTCNg6U2hvlTCfLd1AOwkmbQ/zJzSau2oWgQL2Cb5wW6gDRx0lwRzrMIgLqzdFbRaPtAsawTOlJzjukpZT/RqNtXrxS; AWSALBCORS=QIJryvOYFdw0FId0LQ8iLG9opUoeFQXu5jTCNg6U2hvlTCfLd1AOwkmbQ/zJzSau2oWgQL2Cb5wW6gDRx0lwRzrMIgLqzdFbRaPtAsawTOlJzjukpZT/RqNtXrxS; connect.sid=s%3A8up6LhkyUZ3F23c75ZihoY-iSfjxIybu.IyI6ntD6pIUwymMBq50nOpfWEj2m9ordZXziLZnvUAc");

                var request = await _httpClient.PostAsync("https://admin-dmp.insigit.com/cpa/payments", content);
                Root root = System.Text.Json.JsonSerializer.Deserialize<Root>(await request.Content.ReadAsStringAsync());
                MyLogger(root);
                string ans = await request.Content.ReadAsStringAsync();
                //writeToCSV(ans);

            }
            reader.Close();
        }

        private static void writeToCSV(string ans)
        {
            using (var readJson = new ChoJSONReader(ans))
            {
                using (var writeCsv = new ChoCSVWriter($"sample_{DateTime.Now.Ticks}.csv").WithFirstLineHeader())
                {
                    writeCsv.Write(readJson);
                    _logger.Debug("Done!");
                }
            }
        }
        private static NpgsqlConnection ConnectToDataBase()
        {
            String connectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=qwsazx12;Database=mrfreemaninc;";
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
            _logger.Debug("Соединение с БД открыто");
            return npgSqlConnection;
        }
    }
}

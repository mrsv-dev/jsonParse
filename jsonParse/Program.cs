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
            for (int it = 0; it < 4; it++)
            {
                string[] affType = { "affType_Topoffers", "affType_AdsEmpire Direct", "affType_AdsEmpire Smartlink", "affType_Adromeda" };
                string affTypes = affType[new Random().Next(1, affType.Length)];
                NpgsqlConnection npgSqlConnection = ConnectToDataBase();
                await GetDataFromDBAsync(npgSqlConnection, affTypes);
            }
        }

        private static async Task GetDataFromDBAsync(NpgsqlConnection npgSqlConnection, string affTypes)
        {
           

            using (var command = new NpgsqlCommand($"SELECT * FROM requestPayAff where affType = '{affTypes}' ", npgSqlConnection))
            {

                var reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    string abs = reader.GetString(2)  ;

                    var content = new StringContent(abs, Encoding.UTF8, "application/json"); ;
                    var _httpClient = new HttpClient();
                    _httpClient.DefaultRequestHeaders.Add("cookie", "connect.sid=s%3AiimryWz6qqkWuHRzifL_v-2LcZ-6tbbW.ncL3n93j1mfNiQTku2u8Wk%2F07GYwJ0gRZ32bKoGPi0U; token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6NzM3MSwiaWF0IjoxNjQ5NDAyMDY1LCJleHAiOjE3MDk3MzYwNjV9.B7L_qBkIY69yp7n1LDD132WoEqsuCEi997_gECNX9H8; AWSALB=kXvnZl/ERP5sX8OVWBkML6og/uQz9a8b6ke5kFjrE3Z/C+qpIf9G75E8VfP999+wjXJHQIa559NBNIjxPUBbDGWwCb7VYlNoiiNw/rWRtJqCSLiC52C5IdvEqUVK; AWSALBCORS=kXvnZl/ERP5sX8OVWBkML6og/uQz9a8b6ke5kFjrE3Z/C+qpIf9G75E8VfP999+wjXJHQIa559NBNIjxPUBbDGWwCb7VYlNoiiNw/rWRtJqCSLiC52C5IdvEqUVK; AWSALB=QIJryvOYFdw0FId0LQ8iLG9opUoeFQXu5jTCNg6U2hvlTCfLd1AOwkmbQ/zJzSau2oWgQL2Cb5wW6gDRx0lwRzrMIgLqzdFbRaPtAsawTOlJzjukpZT/RqNtXrxS; AWSALBCORS=QIJryvOYFdw0FId0LQ8iLG9opUoeFQXu5jTCNg6U2hvlTCfLd1AOwkmbQ/zJzSau2oWgQL2Cb5wW6gDRx0lwRzrMIgLqzdFbRaPtAsawTOlJzjukpZT/RqNtXrxS; connect.sid=s%3A8up6LhkyUZ3F23c75ZihoY-iSfjxIybu.IyI6ntD6pIUwymMBq50nOpfWEj2m9ordZXziLZnvUAc");

                    var request = await _httpClient.PostAsync("https://admin-dmp.insigit.com/cpa/payments", content);
                    Root root = System.Text.Json.JsonSerializer.Deserialize<Root>(await request.Content.ReadAsStringAsync());
                    MyLogger(root);
                }
                reader.Close();
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

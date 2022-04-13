using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
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
            var content = new StringContent("{\"form\":{\"dateFrom\":\"2022 - 04 - 11\",\"dateTo\":\"2022 - 04 - 17\",\"name\":\"\",\"id\":\"\"},\"query\":{},\"periodResolve\":true,\"filters\":{\"paymentsType\":[{\"id\":\"paymentsType_Monthly\"}],\"paymentMethods\":[{\"id\":\"paymentMethods_Bank Wire Transfer\"}],\"affStatus\":[{\"id\":\"affStatus_Approve\"}],\"affType\":[{\"id\":\"affType_AdsEmpire Direct\"}],\"markAsPending\":[],\"currentSort\":\"amount\",\"direction\":null,\"counter\":0}}", Encoding.UTF8, "application/json"); ;
            var _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("cookie", "connect.sid=s%3AiimryWz6qqkWuHRzifL_v-2LcZ-6tbbW.ncL3n93j1mfNiQTku2u8Wk%2F07GYwJ0gRZ32bKoGPi0U; token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6NzM3MSwiaWF0IjoxNjQ5NDAyMDY1LCJleHAiOjE3MDk3MzYwNjV9.B7L_qBkIY69yp7n1LDD132WoEqsuCEi997_gECNX9H8; AWSALB=kXvnZl/ERP5sX8OVWBkML6og/uQz9a8b6ke5kFjrE3Z/C+qpIf9G75E8VfP999+wjXJHQIa559NBNIjxPUBbDGWwCb7VYlNoiiNw/rWRtJqCSLiC52C5IdvEqUVK; AWSALBCORS=kXvnZl/ERP5sX8OVWBkML6og/uQz9a8b6ke5kFjrE3Z/C+qpIf9G75E8VfP999+wjXJHQIa559NBNIjxPUBbDGWwCb7VYlNoiiNw/rWRtJqCSLiC52C5IdvEqUVK; AWSALB=QIJryvOYFdw0FId0LQ8iLG9opUoeFQXu5jTCNg6U2hvlTCfLd1AOwkmbQ/zJzSau2oWgQL2Cb5wW6gDRx0lwRzrMIgLqzdFbRaPtAsawTOlJzjukpZT/RqNtXrxS; AWSALBCORS=QIJryvOYFdw0FId0LQ8iLG9opUoeFQXu5jTCNg6U2hvlTCfLd1AOwkmbQ/zJzSau2oWgQL2Cb5wW6gDRx0lwRzrMIgLqzdFbRaPtAsawTOlJzjukpZT/RqNtXrxS; connect.sid=s%3A8up6LhkyUZ3F23c75ZihoY-iSfjxIybu.IyI6ntD6pIUwymMBq50nOpfWEj2m9ordZXziLZnvUAc");

            var request = await _httpClient.PostAsync("https://admin-dmp.insigit.com/cpa/payments", content); 
            Root root = System.Text.Json.JsonSerializer.Deserialize<Root>(await request.Content.ReadAsStringAsync());
            MyLogger(root);

            Console.ReadKey(true);
        }
    }
}

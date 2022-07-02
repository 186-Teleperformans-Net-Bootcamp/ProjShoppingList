using Application.CQS.ShopListR.Commands.AddShopListAdmin;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServices
{
    public class ConsumerOperations
    {
        public async Task Do()
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "Berengaar", Password = "Berengaar123" };
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                var consumer = new AsyncEventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var json = System.Text.Json.JsonSerializer.Serialize(body);
                    var entity = System.Text.Json.JsonSerializer.Deserialize<AddShopListAdminCommandRequest>(json);

                    HttpClient client = new HttpClient();

                    HttpResponseMessage response = await client.PostAsJsonAsync(
                            "https://localhost:7004/api/shoplists/adding-admin", entity);
                };
                channel.BasicConsume(queue: "CompletedList",
                    autoAck: true, consumer: consumer);
            }
        }
    }
}

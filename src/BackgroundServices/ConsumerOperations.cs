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
        public void Consume()
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "Berengaar", Password = "Berengaar123" };
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                var consumer = new AsyncEventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    try
                    {
                        var body = ea.Body.ToArray();
                        var strEntity = Encoding.UTF8.GetString(body);
                        var entity = System.Text.Json.JsonSerializer.Deserialize<AddShopListAdminCommandRequest>(strEntity);
                        HttpClient client = new HttpClient();

                        HttpResponseMessage response = await client.PostAsJsonAsync(
                                "https://localhost:7004/api/shoplists/adding-admin", entity);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                };
                channel.BasicConsume(queue: "CompletedList",
                    autoAck: true, consumer: consumer);
            }
        }
    }
}

using Application.Common.Interfaces;
using Domain.Entities.AdminEntities;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.RabbitMq
{
    public class ProducerOperations :IProducer
    {

        private readonly IRabbitMqService _rabbitService;

        public ProducerOperations(IRabbitMqService rabbitService)
        {
            _rabbitService = rabbitService;
        }

        public void SendDataToQueue(CompletedList list)
        {
            var factory = new ConnectionFactory() { HostName = _rabbitService.HostName, UserName = _rabbitService.UserName, Password = _rabbitService.Password };
            using (IConnection connection=factory.CreateConnection())
            using(IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "CompletedList",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var json = JsonSerializer.Serialize(list);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "",
                    routingKey: "CompletedList",
                    body: body);
            }
           
        }
    }
}

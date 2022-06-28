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
    public class ProducerOperations : IRabbitMqService
    {
        public string HostName { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public ProducerOperations()
        {
            GetSettings();
        }

        public void SendDataToQueue(CompletedList list)
        {
            var factory = new ConnectionFactory() { HostName = this.HostName, UserName = this.UserName, Password = this.Password };
            using (IConnection connection=factory.CreateConnection())
            using(IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "CompletedList",
                    durable: true,
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
        private void GetSettings()
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../UI"));
            configurationManager.AddJsonFile("appsettings.json");
            HostName = configurationManager["RabbitMqOptions:HostName"];
            UserName = configurationManager["RabbitMqOptions:UserName"];
            Password = configurationManager["RabbitMqOptions:Password"];
        }

     
    }
}

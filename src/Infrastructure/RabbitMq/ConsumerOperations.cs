using Application.Common.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RabbitMq
{
    public class ConsumerOperations
    {
        private readonly IRabbitMqService _rabbitService;

        public ConsumerOperations(IRabbitMqService rabbitService)
        {
            _rabbitService = rabbitService;
        }

        public void ReadQueue()
        {
            var factory=new ConnectionFactory() { HostName=_rabbitService.HostName,UserName=_rabbitService.UserName,Password=_rabbitService.Password};
            using(IConnection connection=factory.CreateConnection())
            using (IModel channel=connection.CreateModel())
            {
                var consumer = new EventingBasicConsumer(channel);
                //consumer.Received += (model,ea)
            }
        }
    }
}

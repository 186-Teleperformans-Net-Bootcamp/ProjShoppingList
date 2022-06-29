using Application.Common.Interfaces;
using Domain.Entities;
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
        private readonly IUnitOfWork _unitOfWork;

        public ConsumerOperations(IRabbitMqService rabbitService, IUnitOfWork unitOfWork)
        {
            _rabbitService = rabbitService;
            _unitOfWork = unitOfWork;
        }

        public async Task ReadQueue()
        {
            var factory = new ConnectionFactory() { HostName = _rabbitService.HostName, UserName = _rabbitService.UserName, Password = _rabbitService.Password };
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (sender, args) =>
                {
                    var body = args.Body;
                    var json = System.Text.Json.JsonSerializer.Serialize(body);
                    var model = System.Text.Json.JsonSerializer.Deserialize<ShopList>(json);
                    await _unitOfWork.ShopListWriteRepository.AddShopListAdminAsync(model);
                };
            }
        }
    }
}

// See https://aka.ms/new-console-template for more information
using Application.CQS.ShopListR.Commands.AddShopListAdmin;
using BackgroundServices;
using Domain.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net.Http.Json;
using System.Text;
ConsumerOperations consume = new ConsumerOperations();
consume.Consume();



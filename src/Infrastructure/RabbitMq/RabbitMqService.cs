using Application.Common.Interfaces;
using Domain.Entities.AdminEntities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RabbitMq
{
    public class RabbitMqService : IRabbitMqService
    {
        public string HostName { get; private set; } = "";
        public string UserName { get; private set; } = "";
        public string Password { get; private set; } = "";
        public RabbitMqService()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../UI"));
            configurationManager.AddJsonFile("appsettings.json");
            HostName = configurationManager["RabbitMqOptions:HostName"];
            UserName = configurationManager["RabbitMqOptions:UserName"];
            Password = configurationManager["RabbitMqOptions:Password"];
        }

        public string[] GetSettings()
        {
            string[] settingsList = new string[3];
            settingsList[0] = this.HostName;
            settingsList[1] = this.UserName;
            settingsList[2] = this.Password;
            return settingsList;
        }
    }
}

using Domain.Entities.AdminEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IRabbitMqService
    {
        public string HostName { get; }
        public string UserName { get; }
        public string Password { get; }
        string[] GetSettings();
    }
}

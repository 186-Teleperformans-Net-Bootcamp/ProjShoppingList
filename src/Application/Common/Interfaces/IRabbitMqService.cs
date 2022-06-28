﻿using Domain.Entities.AdminEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IRabbitMqService
    {
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        void SendDataToQueue(CompletedList list);
    }
}
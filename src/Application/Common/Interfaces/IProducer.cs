using Domain.Entities.AdminEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IProducer
    {
        void SendDataToQueue(CompletedList list);
    }
}

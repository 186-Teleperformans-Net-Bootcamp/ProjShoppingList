using Domain.Entities.MongoDbEntities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IMongoDbService
    {
        Task<List<Log>> GetAsync();
        Task CreateAsync(Log log);
    }
}

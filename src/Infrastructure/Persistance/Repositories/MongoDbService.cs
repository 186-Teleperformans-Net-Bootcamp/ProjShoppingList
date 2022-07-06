using Application.Common.Interfaces;
using Application.Common.Models.MongoDb;
using Domain.Entities.MongoDbEntities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class MongoDbService : IMongoDbService
    {
        private readonly IMongoCollection<Log> _logsCollection;

        public MongoDbService(IOptions<MongoDbSettings> mongoDbSettings/*,IMongoCollection<Log> logs*/)
        {
            MongoClient client = new MongoClient(mongoDbSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _logsCollection = database.GetCollection<Log>(mongoDbSettings.Value.CollectionName);
            //_logs = logs;
        }

        public async Task CreateAsync(Log log)
        {
            await _logsCollection.InsertOneAsync(log);
        }

        public async Task<List<Log>> GetAsync()
        {
            return await Task.Run(() => _logsCollection.Find(log => true).ToList());
        }
    }
}

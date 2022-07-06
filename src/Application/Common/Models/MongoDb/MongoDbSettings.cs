using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models.MongoDb
{
    public class MongoDbSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
    }
}

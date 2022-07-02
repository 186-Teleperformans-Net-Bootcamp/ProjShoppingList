using Application.Common.Interfaces;
using Application.Common.Repositories.ShopListRepo;
using Domain.Entities;
using Domain.Entities.AdminEntities;
using Infrastructure.Persistance.Contexts;
using Infrastructure.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories.ShopListRepo
{
    public class ShopListWriteRepository : WriteRepository<ShopList>, IShopListWriteRepository
    {
        private readonly ProjShoppingListMsDbContext _context;
        private readonly ProjShoppingListPostgreSqlDbContext _postgreContext;
        private readonly IProducer _producer;
        public ShopListWriteRepository(ProjShoppingListMsDbContext context, ProjShoppingListPostgreSqlDbContext postgreContext, IProducer producer) : base(context) =>
            (_context, _postgreContext,_producer) = (context, postgreContext,producer);

        public async Task<bool> AddShopListAdminAsync(CompletedList completedShopList)
        {
            if (completedShopList != null)
            {
                await _postgreContext.AddAsync(completedShopList);
                await _postgreContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> CompleteAsync(string id)
        {
            var completedList = await Task.Run(() => _context.ShopLists.SingleOrDefault(s => s.Id == id));
            completedList.IsCompleted = true;
            _context.SaveChanges();
            CompletedList adminCompletedList = new CompletedList
            {
                Title = completedList.Title,
                CreatedDate = completedList.CreatedDate,
                Description=completedList.Description,
                Id = id,
                IsActive = completedList.IsActive,
                ModifiedDate= completedList.ModifiedDate,
                UserId=completedList.UserId,
            };
            _producer.SendDataToQueue(adminCompletedList);
            return true;
        }
    }
}

using Domain.Entities.AdminEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IProjShoppingListAdminDbContext
    {
        DbSet<CompletedList> CompletedLists { get; set; }
    }
}

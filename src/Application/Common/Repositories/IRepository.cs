using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories
{
    public interface IRepository<T> where T : BaseEditableEntity
    {
        DbSet<T> Table { get; }
    }
}

using Nbuy_Getir.Core.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Core.Repositories
{
    /// <summary>
    /// Okuma ve select özelliği
    /// </summary>
    interface IReadOnlyRepository<TEntity> where TEntity : IAggregateRoot
    {
        TEntity Find(string key);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

        IQueryable<TEntity> List(); // order, include, take, skip gibi işlemler için ıqurablae yaptık.

        IQueryable Select(string query); // select * from products join
 
    }
}

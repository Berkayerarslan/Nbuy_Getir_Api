using Nbuy_Getir.Core.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Core.Repositories
{
    interface IWriteOnlyRepository<TEntity> where TEntity : IAggregateRoot
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(string Id);
        void Save();
    }
}

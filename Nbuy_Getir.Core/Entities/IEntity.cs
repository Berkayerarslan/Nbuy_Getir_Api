using Nbuy_Getir.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Core.Entities
{
    public interface IEntity
    {
        IReadOnlyList<IDomainEvent> DomainEvents { get; }
    }
}

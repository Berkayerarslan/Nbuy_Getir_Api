using Nbuy_Getir.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Core.Entities
{
    public abstract class Entity : IEntity
    {
        public string Id { get; set; }

        private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

        // sınıfa atadığımız event
        public void AddEvents(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }

        public Entity()
        {
            Id = Guid.NewGuid().ToString();
        }

    }
}

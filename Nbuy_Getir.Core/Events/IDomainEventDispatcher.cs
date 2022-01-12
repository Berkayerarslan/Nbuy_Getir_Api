using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Core.Events
{
    public interface IDomainEventDispatcher
    {
        /// <summary>
        /// IDomainEvent tipindeki tüm eventleri sevk et
        /// </summary>
        /// <param name="devent"></param>
        void Dispatch(IDomainEvent devent);
    }
}

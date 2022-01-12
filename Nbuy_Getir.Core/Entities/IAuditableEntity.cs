using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Core.Entities
{
    /// <summary>
    /// Denetlenebilir Enitity kimin tarafından Updated Created yapıldığı bilgisini tutacağız
    /// </summary>
    public interface IAuditableEntity
    {
        // Bu entity önemli ürün gibi bir nesne ise bu alanları kesinlikle tutarız.

        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
    }
}

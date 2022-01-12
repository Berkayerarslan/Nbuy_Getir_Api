using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Core.Services
{
    public interface IApplicationService<TRequestDto,TResultDto>
    {
        /// <summary>
        /// Front end tarafından gelen bir isteğin frontend tarafına işlenip bir sonucun döndürülmesi için yaptık. Api de Input Model ve View Model yerine artık Dto(DAta Transfer Object) terimini Kullnacağız.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<TResultDto> HandleAsync(TRequestDto dto);
    }
}

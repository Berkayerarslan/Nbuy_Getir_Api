using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Core.Security
{
    public interface IDecryptService
    {
        /// <summary>
        /// byte[] olarak şifrelenmiş datayı byte[] olarak şifresi çzülmüş bir şekilde geriye döndürebiliriz.
        /// </summary>
        /// <param name="chiper"></param>
        /// <returns></returns>
        byte[] Decrypt(byte[] chiper);
    }
}

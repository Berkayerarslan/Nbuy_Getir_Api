using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Core.Security
{
    public interface IEncyptService
    {
        /// <summary>
        /// MD% ile SHA,DES,3DES gibi algoritmalar ile şifreleme işlemleri yapan bir servis olarak kullanabilir.MD5 Hash algoritması geriye çevrilemez.
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        string Encrypt(string plainText);
    }
}

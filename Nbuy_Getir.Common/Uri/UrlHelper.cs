using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nbuy_Getir.Common.Uri
{
    public static class UrlHelper
    {
        public static bool IsUrl(string url)
        {
            string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            var regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (!regex.IsMatch(url))
            {
                throw new Exception("");
            }
            return regex.IsMatch(url);
        }
    }
}

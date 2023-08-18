using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliderMenuDUI.Base.Token.Abstract
{
    public interface IResultToken
    {
        string Token { get; set; }
        DateTime Expiration { get; set; }
    }
}

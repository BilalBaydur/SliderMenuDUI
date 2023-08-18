using SliderMenuDUI.Base.Token.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliderMenuDUI.Base.Token
{
    public class ResultToken : IResultToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}

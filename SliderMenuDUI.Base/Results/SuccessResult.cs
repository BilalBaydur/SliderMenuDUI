using System;
using System.Collections.Generic;
using System.Text;

namespace SliderMenuDUI.Base.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true)
        {

        }

        public SuccessResult(string message) : base(true, message)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SliderMenuDUI.Base.Results.Abstract
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace SliderMenuDUI.Base.Results.Abstract
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }

    }
}

﻿using SliderMenuDUI.Base.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SliderMenuDUI.Base.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.Core.Utilities.Results.Concrete
{
    public class ErrorDataResult<T> : DataResult<T> where T : class
    {
        public ErrorDataResult() : base(default, false)
        { }
        public ErrorDataResult(string message) : base(default, false, message)
        { }
        public ErrorDataResult(T data, string message) : base(data, false, message)
        { }
    }
}

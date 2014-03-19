﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLinearity.Interfaces
{
    public interface ICompute<T>
    {
        double Compute(T input);
    }
}

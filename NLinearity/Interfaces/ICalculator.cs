using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLinearity.Interfaces
{
    public interface ICalculator<T> where T : class, IMainObject<T>
    {
        double Calculate(double value, int index, T mainObject, ICompute<T> computer);
    }
}

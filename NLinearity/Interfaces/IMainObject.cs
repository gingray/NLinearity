using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLinearity.Interfaces
{
    public interface IMainObject<T> where T : class, IMainObject<T>
    {
        List<double> Attributes { get; }
        DataFrame<T> DataFrame { get; set; }
        double Weight { get; set; }
    }
}

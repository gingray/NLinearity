using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLinearity.Interfaces;

namespace NLinearity.Common
{
    public class AppliedPropertyEventArgs<T>:EventArgs where T :class, IMainObject<T>
    {
        private readonly double _value;
        private readonly T _mainObject;
        private readonly ICompute<T> _computer;

        public AppliedPropertyEventArgs(double value,T mainObject,ICompute<T> computer)
        {
            _value = value;
            _mainObject = mainObject;
            _computer = computer;
        }

        public double Value { get { return _value; }}
        public T MainObject { get { return _mainObject; } }
        public ICompute<T> Computer { get { return _computer; } }
    }
}

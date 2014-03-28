using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLinearity.Common;
using NLinearity.Interfaces;

namespace NLinearity
{
    public class DataFrame<TMainObject> where TMainObject : class, IMainObject<TMainObject>
    {
        private readonly List<TMainObject> _rows;
        private readonly List<ICompute<TMainObject>> _computers;
        private readonly ICalculator<TMainObject> _calculator;

        public event EventHandler<AppliedPropertyEventArgs<TMainObject>> AppliedProperty;

        protected virtual void OnAppliedProperty(AppliedPropertyEventArgs<TMainObject> e)
        {
            EventHandler<AppliedPropertyEventArgs<TMainObject>> handler = AppliedProperty;
            if (handler != null) handler(this, e);
        }

        public DataFrame(List<TMainObject> rows, List<ICompute<TMainObject>> computers,ICalculator<TMainObject> calculator)
        {
            _rows = rows;
            foreach (var mainObject in _rows)
            {
                mainObject.DataFrame = this;
            }
            _computers = computers;
            _calculator = calculator;
        }

        public void Process()
        {
            foreach (var mainObject in _rows)
            {
                for (var index = 0; index < _computers.Count; index++)
                {
                    var computer = _computers[index];
                    var value = computer.Compute(mainObject);
                    mainObject.Attributes.Add(value);
                    mainObject.Weight += _calculator.Calculate(value, index, mainObject, computer);
                    OnAppliedProperty(new AppliedPropertyEventArgs<TMainObject>(value,mainObject,computer));
                }
            }
        }

        public double this[int x, int y]
        {
            get
            {
                return _rows[x].Attributes[y];
            }
        }

        public Dictionary<TMainObject,double> GetAttributeVector(int i)
        {
            return _rows.ToDictionary(k => k, v => v.Attributes[i]);
        }
    }
}

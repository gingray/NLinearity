using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLinearity.Interfaces;

namespace NLinearity
{
    public class DataFrame<TMainObject> where TMainObject : IMainObject
    {
        private readonly List<TMainObject> _rows;
        private readonly List<ICompute<TMainObject>> _computers;

        public DataFrame(List<TMainObject> rows, List<ICompute<TMainObject>> computers)
        {
            _rows = rows;
            _computers = computers;
        }

        public void Process()
        {
            foreach (var mainObject in _rows)
            {
                foreach (var computer in _computers)
                {
                    mainObject.Attributes.Add(computer.Compute(mainObject));
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

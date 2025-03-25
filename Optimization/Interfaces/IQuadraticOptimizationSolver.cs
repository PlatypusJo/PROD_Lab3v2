using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization.Interfaces
{
    public interface IQuadraticOptimizationSolver
    {
        public double[] Optimize(string func, double firstLimitX, double firstLimitY, double firstLimit, double secondLimitX, double secondLimitY, double secondLimit);
    }
}

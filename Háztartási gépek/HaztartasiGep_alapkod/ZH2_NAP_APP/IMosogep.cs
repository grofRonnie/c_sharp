using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_NAP_APP
{
    internal interface IMosogep
    {
        public int MaxToltotomeg { get; }

        public int MaxFordulat { get; }

        double VizFelhasznalas(MosogepProgram program, double tomeg)
        {
            return 0;
        }
    }
}

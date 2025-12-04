using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_NAP_APP
{
    internal class Mosogep : Nagygep, IMosogep
    {
        private int maxToltoTomeg = 0;

        public Mosogep(string gyarto, string tipus) : base(gyarto, tipus)
        {
        }

        public override int Relevancia => throw new NotImplementedException();

        public int MaxToltotomeg
        {
            get => maxToltoTomeg;
            private set
            {
                if (value >= 5 && value <= 11)
                {
                    maxToltoTomeg = value;
                }
                else if( value > 11)
                {
                    throw new NagyMaximalisToltotomegException();
                }
            }
        }

        public int MaxFordulat
        {
            get => MaxFordulat;

            private set
            {
                if (value % 100 == 0)
                {
                    if (value >= 800 && value <= 1400)
                    {
                        MaxFordulat = value;
                    }
                }
                else
                {
                    throw new MaximalisFordulatszamNemErvenyesException();
                }
            }
        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }

        public override double Hatekonysag()
        {
            throw new NotImplementedException();
        }
    }
}

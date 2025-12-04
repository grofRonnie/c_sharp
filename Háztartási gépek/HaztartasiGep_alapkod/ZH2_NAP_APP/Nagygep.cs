using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_NAP_APP
{
    internal abstract class Nagygep:ICloneable
    {
        protected Nagygep(string gyarto, string tipus)
        {
            Gyarto = new Gyarto(gyarto);
            Tipus = tipus ?? throw new ArgumentNullException(nameof(tipus));
        }

        public Gyarto Gyarto { get; set; }
        public string Tipus { get; private set; }

        public abstract int Relevancia { get; }

        public abstract double Hatekonysag();

        public override bool Equals(object? obj)
        {
            Nagygep masik = obj as Nagygep;
            if (this.Gyarto == masik.Gyarto && this.Tipus == masik.Tipus)
            {
                return true;
            }
            return false;
        }

        public abstract object Clone();

        //public override string ToString()
        //{
        //    return $"{Gyarto} {Tipus}, {Relevancia}, {Hatekonysag() * 100}%";
        //}
    }
}

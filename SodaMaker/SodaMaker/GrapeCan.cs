using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMaker
{
    public class GrapeCan : Can
    {
        public GrapeCan(string flavor, double value)
        {
            this.flavor = "Grape";
            this.value = .35;
        }
    }
}

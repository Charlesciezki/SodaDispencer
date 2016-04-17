using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMaker
{
    public class MeatCan : Can
    {
        public MeatCan(string flavor, double value)
        {
            this.flavor = "Tasty Meat";
            this.value = .06;
        }
    }
}

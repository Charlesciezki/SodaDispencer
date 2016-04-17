using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMaker
{
    public class OrangeCan : Can
    {
       public OrangeCan(string flavor, double value)
        {
            this.flavor = "Orange";
            this.value = .6;
        }
    }
}

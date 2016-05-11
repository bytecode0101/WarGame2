using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs18.Units
{
    public class Zeppelin : AbstractUnit, IAirUnit
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying!");
        }
    }
}

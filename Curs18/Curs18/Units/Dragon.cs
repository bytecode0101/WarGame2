using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs18.Units
{
    public class Dragon : AbstractUnit, IAirUnit, IGroundUnit
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying!");
        }

        public void Run()
        {
            Console.WriteLine("I'm flying!");
        }

        public void Walk()
        {
            Console.WriteLine("I'm flying!");
        }
    }
}

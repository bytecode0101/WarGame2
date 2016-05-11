using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs18.Buildings.Upgrades
{
    public class GrandHouseUpgrade: AbstractUpgrade
    {
        public override int GetCost()
        {         
            return Cost + Component.Cost; 
        }

        public GrandHouseUpgrade()
        {
            Cost = 20;
            Life = 60;
        }
    }
}

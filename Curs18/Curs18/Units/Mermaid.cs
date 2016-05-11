using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs18.Units
{
    public class Mermaid: AbstractUnit
    {
        public Mermaid()
        {
            Name = "Mermaid";
            ownTerrainType = Enums.TerrainType.WATER;
        }
    }
}

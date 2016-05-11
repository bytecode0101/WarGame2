using Curs18.Common;
using Curs18.Enums;
using System.Collections.Generic;

namespace Curs18.Units
{
    public abstract class AbstractUnit: AbstractBuildable
    {
        protected int speed;
        protected int damage;
        protected Dictionary<TerrainType, int> terrainSpeedPenalty;
        protected Dictionary<TerrainType, int> terrainDamagePenalty;
    }
}

using Curs18.Enums;
using System;
using System.Collections.Generic;

namespace Curs18.Units.Attacks
{
    public abstract class AbstractAttack
    {
        #region Private Fields
        protected TerrainType necessaryTerrain;
        protected Dictionary<TerrainType, int> terrainDamagePenalty;
        protected AbstractUnit ownerUnit; 
        #endregion


    }
}

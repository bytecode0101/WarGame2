using System;

namespace Curs18.Units
{
    public class Swordman : AbstractUnit, IGroundUnit
    {
        public Swordman()
        {
            Name = "Swordman";
            ownTerrainType = Enums.TerrainType.GROUND;
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public void Walk()
        {
            throw new NotImplementedException();
        }
    }
}
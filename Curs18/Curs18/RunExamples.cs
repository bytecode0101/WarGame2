using System;

using Curs18.Common;
using Curs18.Buildings.Upgrades;
using Curs18.Models.Buildings;

namespace Curs18
{
    public class RunExamples
    {
        public static void Run()
        {
            AbstractBuildable myBuilding = new Farm();
            myBuilding.Cost = 16;

            Console.WriteLine("inainte de upgrade costul era: {0}", myBuilding.Cost);

            AbstractUpgrade myUpgrade = new GrandHouseUpgrade();
            myUpgrade.Component = (AbstractBuilding)myBuilding;
            //myUpgrade.GetCost();

            Console.WriteLine("dupa upgrade costul este: {0}", myUpgrade.GetCost());
            Console.WriteLine("dupa upgrade costul este: {0}", myUpgrade.GetCost());
            Console.ReadLine();
        }
    }
}

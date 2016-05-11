using Curs18.Buildings.Upgrades;
using Curs18.Common;
using Curs18.Models.Buildings;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGameTest
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void TestCost()
        {
            AbstractBuildable farm = new Farm();
            Assert.AreEqual(10, farm.GetCost());
            var upgarde = new GrandHouseUpgrade();
            upgarde.Component = farm;
            farm = upgarde;
            Assert.AreEqual(30, farm.GetCost());
        }
    }
}

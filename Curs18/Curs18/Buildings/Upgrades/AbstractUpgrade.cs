using Curs18.Common;

namespace Curs18.Buildings.Upgrades
{
    /// <summary>
    /// The Decorator
    /// </summary>
    public class AbstractUpgrade: AbstractBuildable
    {
        public AbstractBuildable Component { get; set; }

        public override int GetCost()
        {
            int total = Cost;

            if (Component!=null)
            {
                total += Component.GetCost();
            }

            return total;
        }

        public override int GetLife()
        {
            int total = Life;

            if (Component != null)
            {
                total += Component.GetLife();
            }

            return total;
        }
    }
}

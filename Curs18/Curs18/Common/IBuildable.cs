namespace Curs18.Common
{
    public interface IBuildable
    {
        int PercentageBuilt { get; set; }
        void StartBuilding();
        void Ready(int percentage);
        int GetCost();
        int GetLife();
    }
}

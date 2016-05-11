namespace Curs18.Units
{
    public interface IUnit
    {
    }

    public interface IGroundUnit: IUnit
    {
        void Walk();
        void Run();
    }

    public interface IAirUnit : IUnit
    {
        void Fly();
    }

    public interface IWaterUnit : IUnit
    {
        void Swim();
    }
}
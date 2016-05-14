public class Ship
{
    private TypeOfShip type;
    private Coordinate headCoordinate = new Coordinate();
    private Orientation orientation;
    private ShipState state;
    private int length;

    public TypeOfShip Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
        }
    }

    public Coordinate HeadCoordinate
    {
        get
        {
            return headCoordinate;
        }

        set
        {
            headCoordinate = value;
        }
    }

    public int Length
    {
        get
        {
            return length;
        }

        set
        {
            length = value;
        }
    }

    public ShipState State
    {
        get
        {
            return state;
        }

        set
        {
            state = value;
        }
    }

    public Orientation Orientation
    {
        get
        {
            return orientation;
        }

        set
        {
            orientation = value;
        }
    }

    public AttackResult TakeHit(Coordinate coordinate)
    {
        throw new System.NotImplementedException();
    }

    public void Shoot(Coordinate coordinate)
    {
        throw new System.NotImplementedException();
    }
}

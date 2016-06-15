public class Player
{
    public string Name
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }

    private Grid ownGrid;
    public Grid OwnGrid
    {
        get
        {
            return ownGrid;
        }

        set
        {
            ownGrid = value;
        }
    }

    public Grid OpponentGrid
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }

    private Fleet fleet;
    public Fleet Fleet
    {
        get
        {
            return fleet;
        }

        set
        {
            fleet = value;
        }
    }

    //TODO: implement this
    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Attack(Ship ship, Coordinate coordinate)
    {
        throw new System.NotImplementedException();
    }

    public Player()
    {
        OwnGrid = new Grid(10, 10);
        GenerateFleet();
    }

    private void GenerateFleet()
    {
        Fleet = new Fleet();

        Minesweeper m = new Minesweeper();
        m.HeadCoordinate.X = 0;
        m.HeadCoordinate.Y = 1;
        Minesweeper m2 = new Minesweeper();
        m2.HeadCoordinate.X = 0;
        m2.HeadCoordinate.Y = 9;
        m2.Orientation = Orientation.LEFT;

        Destroyer d = new Destroyer();
        d.HeadCoordinate.X = 2;
        d.HeadCoordinate.Y = 2;
        Battleship b = new Battleship();
        b.HeadCoordinate.X = 4;
        b.HeadCoordinate.Y = 3;
        b.Orientation = Orientation.LEFT;

        Fleet.AddShip(m);
        Fleet.AddShip(d);
        Fleet.AddShip(b);
        Fleet.AddShip(m2);
    }
}

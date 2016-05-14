public class Grid
{
    private int width;
    private int height;
    private Fleet fleet;

    public int Width
    {
        get
        {
            return width;
        }

        set
        {
            width = value;
        }
    }

    public int Height
    {
        get
        {
            return height;
        }

        set
        {
            height = value;
        }
    }

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

    public AttackResult TakeHit(Coordinate coordinate)
    {
        throw new System.NotImplementedException();
    }
    public Grid(int width, int height)
    {
        Width = width;
        Height = height;
        Fleet = new Fleet();
    }
}

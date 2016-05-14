using System;
using System.Collections.Generic;

public class Fleet
{
    private List<Ship> ships;
    public List<Ship> Ships
    {
        get
        {
            return ships;
        }

        set
        {
            ships = value;
        }
    }

    public bool IsSunk()
    {
        throw new System.NotImplementedException();
    }

    public void AddShip(Ship s)
    {
        Ships.Add(s);
    }

    public Fleet()
    {
        Ships = new List<Ship>();
    }
}

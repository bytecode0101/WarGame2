using System;
using System.Collections.Generic;

public class Game
{
    #region Properties
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

    private List<Player> players;
    public List<Player> Players
    {
        get
        {
            return players;
        }

        set
        {
            players = value;
        }
    }

    public int Turn
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }
    #endregion

    #region Constructors
    /// <summary>
    /// Creates a new Game
    /// </summary>
    public Game()
    {
        Players = new List<Player>();
        var player1 = new Player();
        Players.Add(player1);
    }

    /// <summary>
    /// Creates a new Game and loads a file
    /// </summary>
    /// <param name="filePath">The file where the game was saved</param>
    //TODO: implement at home
    public Game(string filePath)
    {

    }
    #endregion

    #region Public Methods
    public void ChangeTurn()
    {
        throw new System.NotImplementedException();
    }

    public void LoadGame()
    {
        throw new System.NotImplementedException();
    }

    public void SaveGame()
    {
        throw new System.NotImplementedException();
    }

    public void Start(bool autoPlay)
    {
        if (autoPlay)
        {
            while (!GameOver())
            {
                foreach (var player in Players)
                {
                    player.Attack();
                }
            }
        }
        else
        {

        }
    }
    #endregion

    #region Private Methods
    //TODO: implement this
    private bool GameOver()
    {
        var res = true;
        foreach (var player in Players)
        {
            if (player.Fleet.IsSunk())
            {
                res = false;
            }
        }
        return res;

        //foreach (var player in Players)
        //{
        //    if (player.Fleet.IsSunk())
        //    {
        //        return false;
        //    }
        //}
        //return true;
    }
    #endregion
}

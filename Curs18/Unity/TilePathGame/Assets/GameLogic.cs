using UnityEngine;
using System.Collections;
using System;

public class GameLogic : MonoBehaviour
{
    private Game game;

    #region Visual Objects
    public TileType[] map;
    public TileType[] tileTypes;
    public GameObject[] visualShips;
    #endregion

    // Use this for initialization
    void Start()
    {
        game = new Game();

        GenerateMap();
        GenerateShips();
    }

    private void GenerateShips()
    {
        for (int i = 0; i < game.Players[0].Fleet.Ships.Count; i++)
        {
            var ship = game.Players[0].Fleet.Ships[i];
            var xCorrection = 0f; 
            var yCorrection = 0f; 
            var rotationVector = new Vector3(0, 0, 0);

            switch (ship.Orientation)
            {
                case Orientation.UP:
                    yCorrection = -ship.Length / 2f + 0.5f;
                    break;
                case Orientation.DOWN:
                    break;
                case Orientation.LEFT:
                    xCorrection = ship.Length / 2f - 0.5f;
                    rotationVector = new Vector3(0, 0, 90);
                    break;
                case Orientation.RIGHT:
                    break;
                default:
                    break;
            }
            GameObject go = (GameObject)Instantiate(visualShips[(int)ship.Type], new Vector3(ship.HeadCoordinate.X + xCorrection,
               ship.HeadCoordinate.Y + yCorrection, -0.75f), Quaternion.identity);
            Quaternion quaternion = Quaternion.identity;
            go.transform.Rotate(rotationVector);

            //GameObject go = (GameObject)Instantiate(visualShips[(int)ship.Type], new Vector3(ship.HeadCoordinate.X,
            //       ((ship.Length % 2) == 0) ? ship.HeadCoordinate.Y : (ship.HeadCoordinate.Y - ship.Length / 2f - 0.5f), -0.75f), Quaternion.identity);
        }
    }

    private void GenerateMap()
    {
        var width = game.Players[0].OwnGrid.Width;
        var height = game.Players[0].OwnGrid.Height;
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GameObject go = (GameObject)Instantiate(tileTypes[0].tileVisualPrefab, new Vector3(x, z, 0), Quaternion.identity);
                ClickableTile ct = go.GetComponent<ClickableTile>();
                ct.tileX = x;
                ct.tileY = z;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

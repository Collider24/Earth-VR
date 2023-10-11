using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solution : MonoBehaviour
{
    private SceneManager manager;

    public Solution(SceneManager manager)
    {
        this.manager = manager;
    }

    public Vector2 SpawnCoordinates()
    {
        Vector2 player1GameCoords = manager.GetFirstPlayerPosition();
        double[] player1GeoCoords = manager.GetEarthCoordsOfFirstPlayer();
        double[] player2GeoCoords = manager.GetEarthCoordsOfSecondPlayer();
        Vector2 result = player1GameCoords + new Vector2(0, 100);
        return result;
    }
}

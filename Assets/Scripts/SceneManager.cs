using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private Vector3 playerPosition;
    private double[] firstPlayerEarthCoords = new double[2];
    private double[] secondPlayerEarthCoords = new double[2];
    [SerializeField]
    private GameObject PlayerPrefab;
    private GameObject firstPlayer;
    private GameObject secondPlayer;

    private void Start()
    {
        GameObject Location = GameObject.Find("Location");
        string[] input = File.ReadAllText("input.txt").Split('\n');
        string[] unityCoords = input[0].Split(' ');
        string[] earthCoordsOfFirstPlayer = input[1].Split(' ');
        string[] earthCoordsOfSecondPlayer = input[2].Split(' ');

        playerPosition = new Vector2(Convert.ToSingle(unityCoords[0].Replace('.', ',')), Convert.ToSingle(unityCoords[1].Replace('.', ',')));
        firstPlayerEarthCoords[0] = Convert.ToDouble(earthCoordsOfFirstPlayer[0].Replace('.', ','));
        firstPlayerEarthCoords[1] = Convert.ToDouble(earthCoordsOfFirstPlayer[1].Replace('.', ','));
        secondPlayerEarthCoords[0] = Convert.ToDouble(earthCoordsOfSecondPlayer[0].Replace('.', ','));
        secondPlayerEarthCoords[1] = Convert.ToDouble(earthCoordsOfSecondPlayer[1].Replace('.', ','));
        firstPlayer = Instantiate(PlayerPrefab);
        firstPlayer.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.green;
        firstPlayer.name = "First Player";
        firstPlayer.transform.position = new Vector3(playerPosition.x, 0, playerPosition.y);

        Solution sol = new Solution(this);
        secondPlayer = Instantiate(PlayerPrefab);
        secondPlayer.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
        secondPlayer.name = "Second Player";
        Location.SetActive(false);
        Vector2 secondPlayerPosition = sol.SpawnCoordinates();
        Location.SetActive(true);
        secondPlayer.transform.position = new Vector3(secondPlayerPosition.x, 0, secondPlayerPosition.y);
        string[] answer = new string[1];
        answer[0] = $"{secondPlayerPosition.x} {secondPlayerPosition.y}".Replace(',', '.');
        File.WriteAllLines("output.txt", answer);
    }

    public double[] GetEarthCoordsOfFirstPlayer()
    {
        return firstPlayerEarthCoords;
    }

    public double[] GetEarthCoordsOfSecondPlayer()
    {
        return secondPlayerEarthCoords;
    }
    
    public Vector2 GetFirstPlayerPosition()
    {
        return new Vector3(firstPlayer.transform.position.x, firstPlayer.transform.position.z); 
    }

}

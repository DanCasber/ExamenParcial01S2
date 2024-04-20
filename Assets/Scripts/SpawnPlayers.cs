using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject player3;
    [SerializeField] private GameObject player4;
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    private void Start()
    {
        //Get the number of players already in the room
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

        spawnRotation = Quaternion.Euler(0f, -180f, 0f);

        if (playerCount == 1) 
        { 
            spawnPosition = new Vector3(8.08f, 0.131f, -2.6f);
            PhotonNetwork.Instantiate(player1.name, spawnPosition, spawnRotation); 
        }
        if (playerCount == 2) 
        { 
            spawnPosition = new Vector3(4.67f, 0.131f, -7.59f); 
            PhotonNetwork.Instantiate(player2.name, spawnPosition, spawnRotation); 
        }
        if (playerCount == 3) 
        { 
            spawnPosition = new Vector3(8.08f, 0.131f, -12.57f); 
            PhotonNetwork.Instantiate(player3.name, spawnPosition, spawnRotation); 
        }
        if (playerCount == 4) 
        { 
            spawnPosition = new Vector3(4.67f, 0.131f, -17.62f); 
            PhotonNetwork.Instantiate(player4.name, spawnPosition, spawnRotation); 
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Material[] playerMaterials;
    private Vector3 spawnPosition;

    private void Start()
    {
        //Get the number of players already in the room
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

        if (playerCount == 1) spawnPosition = new Vector3(8.12f, 0.53f, -2.58f);
        if (playerCount == 2) spawnPosition = new Vector3(4.64f, 0.53f, -7.42f);
        if (playerCount == 3) spawnPosition = new Vector3(8.12f, 0.53f, -12.44f);
        if (playerCount == 4) spawnPosition = new Vector3(4.64f, 0.53f, -17.55f);

        PhotonNetwork.Instantiate(player.name, spawnPosition, Quaternion.identity);

        //Assign material based on player count
        Renderer renderer = player.GetComponent<Renderer>();
        if (playerCount == 1) renderer.material = playerMaterials[0];
        if (playerCount == 2) renderer.material = playerMaterials[1];
        if (playerCount == 3) renderer.material = playerMaterials[2];
        if (playerCount == 4) renderer.material = playerMaterials[3];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ExitRestartGame : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }
}

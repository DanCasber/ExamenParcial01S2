using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviourPunCallbacks
{

    [SerializeField] private float speed;
    [SerializeField] private PhotonView view;
    [SerializeField] private TextMeshProUGUI lapText;
    [SerializeField] private GameObject placementCanvas;
    [SerializeField] private TextMeshProUGUI placementText;
    [SerializeField] private TextMeshProUGUI placementShadowText;

    private int lapsCompleted = 0;
    private int totalLaps = 3;

    void Start()
    {
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            placementCanvas = GameObject.FindGameObjectWithTag("PlacementCanvas");
            lapText = GameObject.FindGameObjectWithTag("NumLaps").GetComponent<TextMeshProUGUI>();
            UpdateLapText();
        }

        // Reset placement to 0 when the scene starts
        if (PhotonNetwork.IsMasterClient)
        {
            ResetPlacement();
        }
    }

    private void ResetPlacement()
    {
        // Reset placement in room properties
        ExitGames.Client.Photon.Hashtable customProps = new ExitGames.Client.Photon.Hashtable();
        customProps["Placement"] = 0;
        PhotonNetwork.CurrentRoom.SetCustomProperties(customProps);
    }

    void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKey("d")) transform.position += Vector3.right * speed * Time.deltaTime;
            if (Input.GetKey("a")) transform.position += Vector3.left * speed * Time.deltaTime;
            if (Input.GetKey("w")) transform.position += Vector3.forward * speed * Time.deltaTime;
            if (Input.GetKey("s")) transform.position += Vector3.back * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (view.IsMine && other.gameObject.CompareTag("Goal"))
        {
            lapsCompleted++;
            UpdateLapText();
            if (lapsCompleted > totalLaps)
            {
                // Increment placement and get the updated value
                int placement = IncrementPlacement(); 
                SetChildrenActive(placementCanvas, true);
                placementText = GameObject.FindGameObjectWithTag("Placement").GetComponent<TextMeshProUGUI>();
                placementShadowText = GameObject.FindGameObjectWithTag("PlacementShadow").GetComponent<TextMeshProUGUI>();
                placementText.text = GetPlacementText(placement);
                placementShadowText.text = GetPlacementText(placement);
            }
        }
    }

    private void UpdateLapText()
    {
        if (lapText != null)
        {
            // Display lap counts for all players
            lapText.text = lapsCompleted + "/" + totalLaps;
        }
    }

    private int IncrementPlacement()
    {
        // Increment placement for all players
        int currentPlacement = PhotonNetwork.CurrentRoom.CustomProperties["Placement"] != null ? (int)PhotonNetwork.CurrentRoom.CustomProperties["Placement"] : 0;
        ExitGames.Client.Photon.Hashtable customProps = new ExitGames.Client.Photon.Hashtable();
        customProps["Placement"] = currentPlacement + 1;
        PhotonNetwork.CurrentRoom.SetCustomProperties(customProps);

        return currentPlacement + 1;
    }

    private string GetPlacementText(int placement)
    {
        switch (placement)
        {
            case 1:
                return "1st";
            case 2:
                return "2nd";
            case 3:
                return "3rd";
            default:
                return placement + "th";
        }
    }

    private void SetChildrenActive(GameObject parent, bool active)
    {
        foreach (Transform child in parent.transform)
        {
            child.gameObject.SetActive(active);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class RaceFinishedDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI placementText;
    private static int playerPlacement;

    void Start()
    {
        playerPlacement = PlayerMovement.placement;
        placementText.text = GetPlacementText(playerPlacement);
    }

    private string GetPlacementText(int placement)
    {
        switch (playerPlacement)
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
}

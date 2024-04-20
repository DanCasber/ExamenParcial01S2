using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private PhotonView view;
    [SerializeField] private TextMeshProUGUI lapText;

    private int lapsCompleted = 0;
    private int totalLaps = 3;
    public static int placement = 0;

    void Start()
    {
        if (view.IsMine)
        {
            lapText = GameObject.FindGameObjectWithTag("NumLaps").GetComponent<TextMeshProUGUI>();
            UpdateLapText();
        }
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
            Debug.Log("Goal Reached");
            if (lapsCompleted > totalLaps)
            {
                placement++;
                Debug.Log("Race Finished In " + placement + " Place.");
                PhotonNetwork.LoadLevel("RaceFinished");
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
}

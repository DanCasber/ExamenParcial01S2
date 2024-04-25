using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NewBehaviourScript : MonoBehaviourPunCallbacks
{
    private PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        if (!view.IsMine)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Camera camera = (Camera) FindObjectOfType(typeof(Camera));
        if (camera)
        {
            Debug.Log("Found");
            transform.LookAt(camera.gameObject.transform);
        }
    }
}

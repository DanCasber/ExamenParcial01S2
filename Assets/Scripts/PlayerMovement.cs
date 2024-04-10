using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private PhotonView view;

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
}

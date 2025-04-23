using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = Vector3.forward;

    void Start()
    {
        //offset = transform.position - player.transform.position;
        offset = new Vector3(0, 0, -10);
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

    }
}

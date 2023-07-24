using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    AudioSource bgSound;
    public AudioClip backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        //The difference of the camera and player position initially
        offset = transform.position - player.transform.position;
        //TODO proper place
        bgSound = GetComponent<AudioSource> ();
        bgSound.clip = backgroundMusic;
        bgSound.Play();
    }

    // LateUpdate is called after update
    void LateUpdate()
    {
        //Position the camera
        transform.position = player.transform.position + offset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 20;
    private float startX;
    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (Mathf.Abs(transform.position.x) - Mathf.Abs(startX) > 50)
        {
            Destroy(gameObject);
        }
    }
}

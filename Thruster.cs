using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody rb;
    void Start()
    {
        rb.velocity = new Vector3(0f,0.5f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") == 1)
        {
            rb.AddForce(new Vector3(0f, 0.2f, 0f));
        }
        if (Input.GetAxis("Vertical") == -1)
        {
            rb.AddForce(new Vector3(0f, -0.2f, 0f));
        }
        if (Input.GetAxis("Horizontal") == 1)
        {
            rb.AddForce(new Vector3(0.2f, 0f, 0f));
        }
        if (Input.GetAxis("Horizontal") == -1)
        {
            rb.AddForce(new Vector3(-0.2f, 0f, 0f));
        }
    }
}

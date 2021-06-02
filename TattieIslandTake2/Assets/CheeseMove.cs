using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseMove : MonoBehaviour
{

    public float force = 5f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Moves object up
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * force * 3, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.AddForce(-Vector3.up * force * 3, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-Vector3.forward * force, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * force, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * force, ForceMode.Impulse);
        }
    }
}

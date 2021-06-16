using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float speed;
    public float thrust;
    private Rigidbody rb;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * speed);
            rb.AddForce(0, 0, thrust, ForceMode.Impulse);
        }
    }
}
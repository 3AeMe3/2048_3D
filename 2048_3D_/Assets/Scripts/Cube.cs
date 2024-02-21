using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Rigidbody rb;
    private void Awake()
    {
        rb= GetComponent<Rigidbody>();

    }

    public void Throw(float force)
    {
        rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
    }

}

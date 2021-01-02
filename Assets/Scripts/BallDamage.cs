using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDamage : MonoBehaviour
{
    Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Debug.Log("velocity"+ rigidbody.velocity.magnitude);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Car")&& rigidbody.velocity.magnitude>1.5f)
        {
            //Nesne'yi terse doğru uçur.
            collision.rigidbody.AddForce((collision.transform.position-transform.position+Vector3.up) *30);
        }
    }
}

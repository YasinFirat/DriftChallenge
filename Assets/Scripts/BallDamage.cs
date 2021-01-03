using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDamage : DriftGame
{
    string tagOfPlayers;
    Rigidbody rigidbody;
    private void Start()
    {
        tagOfPlayers = gameManager.tagOfPlayers;
        rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals(tagOfPlayers))
        {
            //Nesne'yi terse doğru uçur.
           collision.rigidbody.AddForce((collision.transform.position-transform.position+Vector3.up) * rigidbody.velocity.magnitude*20);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class ParachuteCollider : DriftGame
{
    string tagOfPlayers;
    
    bool anyTouch;
    private void Start()
    {
        tagOfPlayers = gameManager.tagOfPlayers;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals(tagOfPlayers)&&!anyTouch)
        {
            anyTouch = true;
            if (collision.transform.TryGetComponent(typeof(Move), out Component move))
            {

                collision.transform.GetComponent<Move>().StartBonus();
            }
            else
            {
                
                collision.transform.GetComponent<AI_Move>().StartBonus();
            }
            gameObject.SetActive(false);
            
        }
    }
}

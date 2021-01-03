using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathControl : DriftGame
{
    string tagOfPlayers;

    private void Awake()
    {
        tagOfPlayers = gameManager.tagOfPlayers;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals(tagOfPlayers))
        {
            other.transform.parent.gameObject.SetActive(false);
        }
    }
}

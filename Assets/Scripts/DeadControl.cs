using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Car"))
        {
            other.transform.parent.gameObject.SetActive(false);
        }
    }
}

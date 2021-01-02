using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float moveSpeed = 2;
    public float turnSpeed = 5;

    public void FixRotate()
    {
       
        if (transform.localPosition.y < .2f && Mathf.Abs(transform.rotation.eulerAngles.z) > 60)
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
    }
}

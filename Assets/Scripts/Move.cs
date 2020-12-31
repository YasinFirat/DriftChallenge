using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public VariableJoystick movePoint;
    public float moveSpeed = 2;
    public float turnSpeed = 5;
    float xWay, yWay;

    private void FixedUpdate()
    {
        xWay = movePoint.Horizontal;

        transform.Rotate(xWay*Vector3.up* turnSpeed, Space.World);
        transform.Translate(Vector3.right*Time.deltaTime*moveSpeed,Space.Self);
    }
}

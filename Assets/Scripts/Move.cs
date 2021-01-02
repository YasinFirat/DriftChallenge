using UnityEngine;

public class Move : Car
{
    public VariableJoystick movePoint;
    
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * movePoint.Horizontal* turnSpeed, Space.World);
        transform.Translate(Vector3.right*Time.deltaTime*moveSpeed,Space.Self);
    }
}

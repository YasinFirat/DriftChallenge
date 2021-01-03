using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Car:DriftGame
{
    public Transform Ball;
    public float moveSpeed = 2;
    public float turnSpeed = 5;
    SpringJoint springJoint;
    TrailRenderer trail;
    private void Awake()
    {
        springJoint= Ball.GetComponent<SpringJoint>();
        trail=Ball.GetComponent<TrailRenderer>();
    }

    /// <summary>
    /// Karakter ters döndüğünde eski haline geri döndürülür.
    /// </summary>
    public void FixRotate()
    {
       
        if (transform.localPosition.y < .2f && Mathf.Abs(transform.rotation.eulerAngles.z) > 60)
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
    }

    public void StartBonus()
    {
        StartCoroutine(Bonus());
    }
     IEnumerator Bonus()
    {
        float speedOfBall = gameManager.bonus.ballSpeed;
        float time = gameManager.bonus.time;
        
        moveSpeed += gameManager.bonus.moveSpeed;
        turnSpeed += gameManager.bonus.turnSpeed;
        Vector3 statusTransform = transform.position;
        statusTransform.z = .5f;
        Ball.position = statusTransform;

        springJoint.spring = 1;
        trail.enabled = true;

      
        while (time>0)
        {
            Ball.transform.RotateAround(transform.position, Vector3.up, speedOfBall*Time.deltaTime);
            statusTransform = Ball.transform.position;
            statusTransform.y = transform.position.y+.1f;
            Ball.transform.position = statusTransform;
            time -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
            
        }

        springJoint.spring = 10;
        trail.enabled = false;

        moveSpeed -= gameManager.bonus.moveSpeed;
        turnSpeed -= gameManager.bonus.turnSpeed;
      

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute : DriftGame
{
    public Transform bottomRaycast;
    float timeOfDownParachute;
    float downSpeed;
    float downLocationY;
    public Transform visibleWhenOkey;
    Vector3 downLocation; //y değerine indirgemek için oluşturuldu(raycast veya boxcollider kullanmak istemedim.)
   
    private void Start()
    {
        timeOfDownParachute = gameManager.timeOfDownParachute;
        downSpeed = gameManager.downSpeed;
        downLocationY = gameManager.downLocationY;
        StartCoroutine(DownParachute());
    }
    IEnumerator DownParachute()
    {
        yield return new WaitForSeconds(timeOfDownParachute);
        
        while (transform.position.y > (downLocationY+.1f))
        {
            transform.position += Vector3.down * downSpeed * Time.deltaTime;
            downLocation = transform.position;
            downLocation.y = downLocationY;
            yield return new WaitForFixedUpdate();
        }
        transform.position = downLocation;
        visibleWhenOkey.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}

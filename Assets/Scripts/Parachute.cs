using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute : MonoBehaviour
{
    public float downSpeed;
    public Transform visibleWhenOkey;
    Vector3 downLocation;

    private void Start()
    {
        StartCoroutine(DownParachute());
    }
    IEnumerator DownParachute()
    {
        
        while (transform.position.y > .5f)
        {
            transform.position += Vector3.down * downSpeed * Time.deltaTime;
            downLocation = transform.position;
            downLocation.y = .4f;
            transform.position = downLocation;
           
            yield return new WaitForFixedUpdate();
        }
        visibleWhenOkey.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastStatus : DriftGame
{
    public Transform foward;
    public Transform right;
    public Transform left;
    public Transform top;
    string tagOfPlayers;
    [HideInInspector]public float range;
    RaycastHit hit;
    RaycastHit leftOrRight;
    public bool can;

    private void Start()
    {
        tagOfPlayers = gameManager.tagOfPlayers;
    }
    /// <summary>
    /// Karakter'e yerleştirilen pointler zemini algılamadıklarında true değeri döndürür.
    /// (Arena dışına çıkmasını engellemek amaçlı oluşturuldu)
    /// </summary>
    /// <returns></returns>
    public int ForcedReturn()
    {
        if (Physics.Raycast(foward.position,transform.TransformDirection(Vector3.forward),out hit, .5f))
        {
            return 0;
            
        }
        else 
        {
            if(Physics.Raycast(right.position,transform.TransformDirection(Vector3.forward),out leftOrRight, .5f))
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        
    }

    
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(top.position, range);
    //    Gizmos.DrawWireSphere(top.position, range * 2);
    //}
    
    /// <summary>
    /// Atak için düşman menziline girdiğinde true değerini döndürür.
    /// </summary>
    /// <returns></returns>
    public bool AttackEnemy()
    {
        RaycastHit hit;
        if(Physics.SphereCast(top.position, range,top.forward,out hit))
        {
           
            if (hit.transform.tag.Equals(tagOfPlayers))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    
}

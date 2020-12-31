using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PartOfArea
{
    public Transform radialPart;
    public List<GameObject> members;
    public void CorrectParts()
    {
        Debug.Log("Area Üyeleri eklendi");
        for (int i = 0; i < radialPart.childCount; i++)
        {
            members.Add(radialPart.GetChild(i).gameObject);
        }
        
    }

   
    public IEnumerator NonActive(int amount)
    {
        Vector3 firstPosition = members[amount].transform.position;
        float time = 0;
        while (time<1f)
        {
            members[amount].transform.position += Vector3.down*.05f;
            time += Time.deltaTime;
            
            yield return new WaitForFixedUpdate();
            Debug.Log(time);
        }
        members[amount].SetActive(false);
        members[amount].transform.position = firstPosition;
    }
    



}
public class Area : MonoBehaviour
{
    public List<PartOfArea> partOfAreas;
    public float destroyTimeOfAreaParts=5;
   [Range(0,1)] public float destroyTimeOfPartsMember = 0.1f;
    int counterPart = 0;
    void Awake()
    {
        for (int i = 0; i < partOfAreas.Count; i++)
        {
            partOfAreas[i].CorrectParts();
        }

        StartCoroutine(TimeOfArea());
        
    }

    
    IEnumerator destroyEachPart()
    {
        int amount = partOfAreas[counterPart].members.Count;
        for (int i=0; i< amount;)
        {
            yield return new WaitForSeconds(destroyTimeOfPartsMember);
            StartCoroutine(partOfAreas[counterPart].NonActive(i));
            i++;
        }
        counterPart++;
        StartCoroutine(TimeOfArea());
       
    }

    IEnumerator TimeOfArea()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(destroyTimeOfAreaParts);
            if (counterPart >= partOfAreas.Count)
            {
                break;   
            }
            StartCoroutine(destroyEachPart());
            break;

        }
    }
}

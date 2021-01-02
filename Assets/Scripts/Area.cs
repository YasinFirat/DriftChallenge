using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Area'nın parçalarını düzenli listelemek ve işlemler yapmak için oluşturuldu
/// </summary>
[System.Serializable]
public class PartOfArea
{
    public Transform radialPart;
   [HideInInspector] public List<GameObject> members;

    /// <summary>
    /// Inspector'da bulunacak olan Area'nın her parçasını düzenli olarak listelemek için oluşturuldu ve oyun açılırken çağrılmalı
    /// </summary>
    public void CorrectParts()
    {
        for (int i = 0; i < radialPart.childCount; i++)
        {
            members.Add(radialPart.GetChild(i).gameObject);
        }
        
    }

   /// <summary>
   /// Yok edilmek istenen parçanın numarasına ulaşılır ve yok edilir.
   /// </summary>
   /// <param name="amount">Parça'nın listedeki numarası</param>
   /// <returns></returns>
    public IEnumerator NonActive(int amount)
    {
        Vector3 firstPosition = members[amount].transform.position; //pasif edildikten hemen sonra eski konumuna getirilir.
        
        float time = 0;
        while (time<1f)
        {
            members[amount].transform.position += Vector3.down*.05f; //parçacıklar aşağı doğru düşer
            time += Time.deltaTime;
            
            yield return new WaitForFixedUpdate();
            
        }
        members[amount].SetActive(false);
        members[amount].transform.position = firstPosition; //eski konumuna geri getirilir.
    }
    



}
/// <summary>
/// Area ile ilgili mekanikleri içerir. (Area'nın parent objesine yerleştirin)
/// </summary>
public class Area : MonoBehaviour
{
    public List<PartOfArea> partOfAreas;
    [Tooltip("Çemberin daralma süresi")] 
    public float TimeOfShrinkage =5;
    [Tooltip("Parçalanma esnasında her bir parçanın ne kadar sürede yok olacağını belirtir.")]
   [Range(0,1)] public float destroyTimeOfPartsMember = 0.1f;
    int counterPart = 0; //partOfArea listesinin aşımını önlemek ve işlem yapmak için kullanılır
    void Awake()
    {
        for (int i = 0; i < partOfAreas.Count; i++)
        {
            partOfAreas[i].CorrectParts();
        }

        StartCoroutine(TimeOfArea()); //oyun başlar başlamaz süre başlatılır.
        
    }

    /// <summary>
    /// Parçalanma başladığında ilgili parçacıklar rastgele şeklinde dökülür
    /// </summary>
    /// <returns></returns>
    IEnumerator destroyEachPart()
    {
        int amount = partOfAreas[counterPart].members.Count; //döngüde birden fazla istekte bulunacağımızdan dolayı değişkene atadım.
        for (int i=0; i< amount;)
        {
            yield return new WaitForSeconds(destroyTimeOfPartsMember);
            StartCoroutine(partOfAreas[counterPart].NonActive(i)); //ilgili parçaya ulaşılır ve zamana göre yok edilir.
            i++;
        }
        counterPart++;
        StartCoroutine(TimeOfArea());
       
    }

    /// <summary>
    /// Çemberin daralma süresi bu işlemden sonra hemen parçalanma başlar.
    /// </summary>
    /// <returns></returns>
    IEnumerator TimeOfArea()
    {
        while (true)
        {//parçalanmanın aktif olacağı zaman için işlem yapar
            
            yield return new WaitForSeconds(TimeOfShrinkage);
            if (counterPart >= partOfAreas.Count)
            {
                break;   
            }
            StartCoroutine(destroyEachPart()); //parçalanma başladı. Bundan sonra bu döngüden çıkıyor başka bir döngüye giriyoruz.
            break;

        }
    }
}

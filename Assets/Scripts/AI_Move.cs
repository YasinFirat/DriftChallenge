using System.Collections;
using UnityEngine;

/// <summary>
/// Karakterin AI işlemlerinin çoğu burada işlenecek
/// </summary>
public class AI_Move : Car
{
    [Tooltip("Karakter'in düşmanı algılama menzili(yarıçap)")]
   [Range(0,1)] public float targetRange=.5f;
    
    public RaycastStatus raycastStatus;
    
     float upGrade;
     int keepRaycastValue;

    private void Start()
    {
        raycastStatus.range = targetRange; //menzil raycast sınıfına atanır.
       
    }
    // Update is called once per frame
    void Update()
    {
        FixRotate();
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.Self);

        transform.Rotate(Vector3.up * turnSpeed * upGrade, Space.World);

        if (upGrade == 0&&raycastStatus.AttackEnemy())
        {//Düşman algılandığında rastgele saldırır.(upGrade, 0 değilse dönmek için işlem yapıyor demektir. Bitmesini beklemeli)
            StartCoroutine(TurnArea(1,1, Random.Range(100, 120)));
            return; //upGrade, 0 olmayacağında  derleyicinin aşağıdaki kod satırını okumak için çaba sarf etmesini engelliyoruz.
        }

        keepRaycastValue = raycastStatus.ForcedReturn();
        if (upGrade==0&&keepRaycastValue!=0)
        {//arena dışına çıkması engellenir.
            StartCoroutine(TurnArea(keepRaycastValue,.5f, Random.Range(150, 180)));
            return;
        }

        if (upGrade ==0&& Random.Range(0, 100) < 5)
        {
            Debug.Log("Rastgele döner");
            StartCoroutine(TurnArea(Random.Range(0,100)<30?1:-1, .2f, Random.Range(10,30)));
        }
      
        
    }

    
   /// <summary>
   ///  Obje'nin döndürme scriptidir.
   /// </summary>
   /// <param name="posOrNegative">Dönme yönü verilir.</param>
   /// <param name="maxUpGarade">dönme hızı 0'dan başlar zamana göre maximum değere kadar artar(en fazla 1 olması önerilir.)</param>
   /// <param name="maximumTurnAngle"></param>
   /// <returns></returns>
    IEnumerator TurnArea(int posOrNegative,float maxUpGarade,float maximumTurnAngle)
    {
        float maxTargetAngle = (transform.rotation.eulerAngles.y + maximumTurnAngle) % 360;
       
        upGrade = 0;
        
        while (Mathf.Abs(upGrade )< maxUpGarade && Mathf.Abs(transform.rotation.eulerAngles.y - maxTargetAngle) > 5)
        {
            upGrade += posOrNegative * Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        upGrade = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inspector'da random değerler eklemek için oluşturuldu.
/// </summary>
/// <typeparam name="T"></typeparam>
[System.Serializable]
public struct RandomValue<T>
{
    public T first;
    public T last;
}
[System.Serializable]
public class TurnCar
{
    public RandomValue<float> maxAngle;
    public float maxUpGrade = 1;
    public float MaxAngle { get { return Random.Range(maxAngle.first, maxAngle.last); } }
}
[System.Serializable]
public struct Bonus
{
    [Tooltip("Önceki speed hızına + olarak eklenecektir.")]
    public float moveSpeed;
    [Tooltip("Önceki dönme hızına + olarak eklenecektir.")]
    public float turnSpeed;
    [Tooltip("Topun hızı")]
    public float ballSpeed;
    [Tooltip("Bonus süresi")]
    public float time;
}

public class GameManager : MonoBehaviour
{
   
    #region player
    [Header("Players")]
    [Tooltip("Enemy'lerin ve player'in etiketi aynı olmalı")]
    public string tagOfPlayers = "Car";
    public Bonus bonus;

    [Header("AI Player")]
    public TurnCar whenAttackTurn; //1,100-120
    public TurnCar whenOutAreaTurn; //.5 , 160-180
    public TurnCar randomTurn;//.2,10-30
    #endregion

    #region Area
    [Header("Area")]
    [Tooltip("Çemberin daralma süresi")]
    public float timeOfShrinkage=20;
    [Tooltip("Parçalanma esnasında her bir parçanın ne kadar sürede yok olacağını belirtir.")]
    [Range(0, 1)] public float destroyTimeOfPartsMember = 0.1f;

    #endregion

    #region parachute
    [Header("Parachute")]
    [Tooltip("Paraşüt'ün düşmeye başlayacağı zaman(Random şeklinde ayarlandı)")]
    public RandomValue<float> timeOfDownStart;
    
    [Tooltip("Paraşüt'ün düşme hızı")]
    [Range(0,1)]public float downSpeed=0.9f;
    public float downLocationY=0.4f;
    
    public float timeOfDownParachute
    {
        get
        {
            return Random.Range(timeOfDownStart.first, timeOfDownStart.last);
        }
    }
    #endregion

   

}

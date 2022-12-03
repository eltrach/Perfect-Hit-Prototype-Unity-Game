using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DynamicObstacle : MonoBehaviour
{
   
   public float duration = 1.5f;
   public Transform PlaceToMoveTo;

   void Start() {

      transform.DOMove(PlaceToMoveTo.transform.position ,duration).SetEase(Ease.InOutSine).SetLoops(-1 , LoopType.Yoyo);

   }

}

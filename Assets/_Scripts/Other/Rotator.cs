using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Rotator : MonoBehaviour
{
    // rotate the coins or pretty much anything 

    [SerializeField] float duration = 2;
    [SerializeField] float moveUpBy = 0.5f;

    void Start()
    {
        transform.DOLocalRotate( new Vector3(0, 180.0f ,0 ) , duration , RotateMode.LocalAxisAdd ).SetEase(Ease.Linear).SetLoops (-1 , LoopType.Incremental);
        transform.DOLocalMove(new Vector3( transform.localPosition.x, transform.localPosition.y + moveUpBy ,transform.localPosition.z ) , duration ).SetEase(Ease.Linear).SetLoops (-1 , LoopType.Yoyo);
    }

  
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class kethop : MonoBehaviour
{
    public Vector3 newTarget;
    public Vector3 newScale;
    public Vector3 newRotation;
    public Ease typeEase;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(newTarget, 2).SetEase(typeEase).SetLoops(-1,LoopType.Yoyo);
        transform.DOScale(newScale, 2).SetEase(typeEase).SetLoops(-1,LoopType.Yoyo);
        transform.DORotate(newRotation, 2,RotateMode.FastBeyond360).SetEase(typeEase).SetLoops(-1,LoopType.Yoyo);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale_tank : MonoBehaviour
{
    public bool huy_cach3 = true;
    [Header("n = (1, 2, 3)")]
    public int n;
    public Ease typeEase;    
    public Transform myTransform;
    public Vector2 endd;

    private Vector3 start ,tmp_v3;
    private Tweener scaleTweener;
    private float get_time;

    // Start is called before the first frame update
    void Start()
    {
       start = transform.localScale;
       tmp_v3 = transform.localScale;
        huy_cach3 = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (n == 1)
        {
            cach1();
        }
        else if (n == 2)
        {
            
            cach2();
        }
        else if (n == 3)
        {
            cach3();
            n++;
        }
        if (huy_cach3==true)
        {
            scaleTweener.Kill();
            huy_cach3 = false;
        }
    }
    void cach1()
    {
        tmp_v3 = myTransform.localScale;
        myTransform.localScale = endd;
        endd = tmp_v3;

       /* if (Time.time - get_time > 1)
        {
            get_time = Time.time;
            myTransform.localScale = endd;
            endd = tmp_v3;
        }
        else
        {
           tmp_v3 = myTransform.localScale;
        }*/
    }
    void cach2()
    {
        float t = Mathf.PingPong(Time.time , 1.0f); // Sử dụng PingPong để tạo hiệu ứng lặp lại
        transform.localScale = Vector3.Lerp(start, endd, t) ;
    }
    void cach3()
    {
      scaleTweener=  myTransform.DOScale(endd, 1f).SetLoops(-1,LoopType.Yoyo).SetEase(typeEase);
    }

}

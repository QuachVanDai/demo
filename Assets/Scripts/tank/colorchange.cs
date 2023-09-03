using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class colorchange : MonoBehaviour
{
    public  SpriteRenderer spriteRenderer;
    public Color targetColor2 = Color.red;
    public Color changeColor;
    Color targetColor1;
    [Header("n = (1, 2, 3)")]
    public int n = 1;
    private float  get_time;
    // Start is called before the first frame update
    void Start()
    {
     
    }
    private void Update()
    {
        if(n==1)
        {
           cach_1();
        }
        else if (n == 2)
        {
             cach_2();
          
        }
        else if (n == 3) { cach_3();n++; }
    }

    void cach_1()
    {
        changeColor = spriteRenderer.color;
        spriteRenderer.color = targetColor1;
        targetColor1 = changeColor;
    }
      void cach_2()
    {  
        
        if(Time.time- get_time > 1)
        {
            get_time = Time.time;
            changeColor = spriteRenderer.color;
            spriteRenderer.color = targetColor1;
        }
        else
        {
            targetColor1 = changeColor;
        }
    }
    void cach_3()
    {
        spriteRenderer.DOColor(targetColor2, 1).SetLoops(-1,LoopType.Restart);

    }
}

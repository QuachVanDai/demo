using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class move_tank : MonoBehaviour
{
   
    public float maxSpeed = 5.0f; // Tốc độ tối đa
    public Rigidbody2D rb;

    private Vector3 targetPosition;
    public int n = 0;
    void Start()
    {
        // Lấy tham chiếu đến thành phần Rigidbody2D của đối tượng
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Kiểm tra xem người dùng có nhấp chuột trái không (0 là chuột trái)
        {
            // Lấy tọa độ chuột trong không gian thế giới
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;
        }
    }

    void FixedUpdate()
    {
      
        float angle = Mathf.Atan2(targetPosition.y - transform.localPosition.y, targetPosition.x - transform.localPosition.x) * Mathf.Rad2Deg -90;
        gameObject.transform.DORotate(new Vector3(0, 0, angle), 1f);
        
      if(n==1)
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
        }
    }
    public void cach3()
    {

        transform.position = targetPosition ;
    }
    private void cach2()
    {
        Vector2 direction = (targetPosition - transform.localPosition).normalized;
        rb.velocity = direction * maxSpeed;
    }
    public void cach1()
    {
        transform.DOMove(targetPosition, 2);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class bullet : MonoBehaviour
{
    public float bulletSpeed;
    private Rigidbody2D rb;
    tasks mytask;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("enemy");
        if (target != null)
        {
            Vector2 direction = (target.transform.position - transform.position).normalized;
            rb.velocity = direction * bulletSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1f);
    }
}

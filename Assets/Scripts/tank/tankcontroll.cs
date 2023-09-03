using System;
using UnityEngine;
using DG.Tweening;
public class tankcontroll : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    [SerializeField] private Transform tankRotaionPoint; // 
    [SerializeField] private float rotationSpeed = 0;
    public float radius = 1.0f;
    public float maxDistance = 10.0f;
    public LayerMask layerMask;
    RaycastHit2D[] hits;
    public Transform tranForm_enemy;
    [Header("n = (1, 2, 3)")]
    public int n = 1;
    void Start()
    {
        InvokeRepeating(nameof(random_vitri), 0, 2);
    }
    void Update()
    {
        findTarget();
    }
    public void findTarget()
    {
        float numDirections = 90; // Số hướng
        float angleIncrement = 360f / numDirections; // Góc giữa các hướng

        for (int i = 0; i < numDirections; i++)
        {
            float angle = i * angleIncrement;
            Vector2 startPosition = transform.position;
            Vector3 direction = Quaternion.Euler(0f, 0f, angle) * transform.right; // Xoay hướng theo góc
           hits = Physics2D.CircleCastAll(startPosition, radius, direction, maxDistance, layerMask);
        }
        if (hits.Length > 0)
        {
            target = hits[0].transform;
           if(n==1)
            {
                xoay_1();

            }
            else if(n==2)
            {
                xoay_2();

            }
            else
            {
                xoay_3();

            }
            return;
        }
    }
    
    void random_vitri()
    {
        Vector2 enemyPosition = new Vector2(UnityEngine.Random.Range(-9, 9), UnityEngine.Random.Range(-4, 4));
        tranForm_enemy.position = enemyPosition;
    }
    public void xoay_1()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90;
        tankRotaionPoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    public void xoay_2()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        tankRotaionPoint.rotation = Quaternion.RotateTowards(tankRotaionPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    public void xoay_3()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90;
        tankRotaionPoint.DORotate(new Vector3(0, 0, angle), 1f);
    }
}

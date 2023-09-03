using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tasks : MonoBehaviour
{
    public bool flat;
    public Transform shoot_point;
    public GameObject bullet;
    private bool isShoot;
    // Start is called before the first frame update
    void Start()
    {
        isShoot = true;
    }

    // Update is called once per frame
    void Update()
    { if(flat)
        {
            if (isShoot)
            {
                StartCoroutine(mytaks());
            }
        }

    }

    IEnumerator mytaks()
    {
        isShoot=!isShoot;
        Instantiate(bullet,shoot_point.position,Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        isShoot = !isShoot;
    }
}

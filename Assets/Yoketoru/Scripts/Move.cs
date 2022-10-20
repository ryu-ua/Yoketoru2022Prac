using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    float speedMin = 1;
    [SerializeField]
    float speedMax = 5;

    float speed;
    Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        speed = Random.Range(speedMin, speedMax);
        rb = GetComponent<Rigidbody>();
        SetRandomVelocity();
    }

    void SetRandomVelocity()
    {
  
        var th = Random.Range(0, 360);
        var dir = new Vector3(
        Mathf.Cos(th * Mathf.Deg2Rad), 
        Mathf.Sin(th * Mathf.Deg2Rad), 0);
        rb.velocity = speed * dir;

    }

    // ThresholdÅ@Ëáíl(ÇµÇ´Ç¢Çø)
   
     void FixedUpdate()
    {
        if(Mathf.Approximately(rb.velocity.magnitude,0f))
        {
            SetRandomVelocity();
        }
        else
        {
            rb.velocity = speed * rb.velocity.normalized;
        }
    }

}

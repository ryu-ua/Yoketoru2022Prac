using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falls : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(Vector3.one);
        transform.Translate(Vector3.down * speed, Space.World);
    }
}

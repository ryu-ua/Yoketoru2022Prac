using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float cameraDistance;

    // Start is called before the first frame update
    void Start()
    {
        cameraDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        var mpos = Input.mousePosition;
        //Debug.Log(mpos);
        mpos.z = cameraDistance;
        var wp = Camera.main.ScreenToWorldPoint(mpos);
        transform.position = wp;
    }
}

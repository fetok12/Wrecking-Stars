using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform ballTransform;
    private Transform backgroundTransform;


    // Start is called before the first frame update
    void Start()
    {
        ballTransform = GameObject.FindGameObjectWithTag("ball").transform;
        backgroundTransform = GameObject.FindGameObjectWithTag("background").transform;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = ballTransform.position.x;
        temp.y = ballTransform.position.y;

        backgroundTransform.position = ballTransform.position;

        transform.position = temp;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform mTarget;

    float mSpeed = 190.0f;
    Vector2 mLookDirection;

    const float EPSILON = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mLookDirection = (mTarget.position - transform.position).normalized;
        if((transform.position - mTarget.position).magnitude > EPSILON)
        {
            transform.Translate(mLookDirection * Time.deltaTime * mSpeed);

        }
        // transform.LookAt(mTarget.position);
        //transform.Translate(0.0f, 0.0f, mSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forthebacket : MonoBehaviour
{
    [SerializeField] float multiplier;
    Vector3 initPos;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //get the initial positon of the holder before the drag starts
    void OnMouseDown()
    {
        Debug.Log("GELDINMI");
        initPos = rb.position;
    }
    void OnMouseDrag()
    {
        Debug.Log("Drag");
       // transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }

    //add force to the disc in the direction of the line between
    //the current position of the holder and its initial position
    void OnMouseUp()
    {
        rb.isKinematic = false;
        Debug.Log("Up");
        rb.AddForce((initPos - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10))) * Vector3.Distance(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), initPos) * multiplier);
    }

}

using UnityEngine;
using System.Collections;

public class dragtorelease : MonoBehaviour
{

    [SerializeField] GameObject Disc;
    [SerializeField] float multiplier;
    Vector3 initPos;


    //get the initial positon of the holder before the drag starts
    void OnMouseDown()
    {
        Debug.Log("GELDINMI");
        initPos = Disc.GetComponent<Rigidbody2D>().position;
    }

    //move the holder according to the drag
    void OnMouseDrag()
    {
        Debug.Log("Drag");
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }

    //add force to the disc in the direction of the line between
    //the current position of the holder and its initial position
    void OnMouseUp()
    {
        Debug.Log("Up");
        Disc.GetComponent<Rigidbody2D>().AddForce((initPos - transform.position) * Vector3.Distance(transform.position, initPos) * multiplier);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boost : MonoBehaviour
{
    private Transform backgroundTransform;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        backgroundTransform = GameObject.FindGameObjectWithTag("background").transform;
        ball = GameObject.FindGameObjectWithTag("ball");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    public void Move()
    {
        //rb.isKinematic = false;
        Vector2 temp = transform.position;
        // transform.position = temp;
        if (temp.y <= backgroundTransform.position.y - 200f)
        {
            gameObject.SetActive(false);
        }

        if (temp.x <= backgroundTransform.position.x - 170f)
        {
            gameObject.SetActive(false);
        }
     

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "platform")
        {
           // gameObject.SetActive(false);
         //   ball.GetComponent<Ball>().addCounter();
        }
        // gameObject.SetActive(false);

    }

}

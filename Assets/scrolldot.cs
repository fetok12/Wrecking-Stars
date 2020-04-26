using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolldot : MonoBehaviour
{
    static public float move_Speed = 2f;
    static bool yes = false;
    private Transform backgroundTransform;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        backgroundTransform = GameObject.FindGameObjectWithTag("background").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (yes)
        {
            //transform.position = new Vector2(Mathf.Clamp(transform.position.x, backgroundTransform.position.x-174f, 174f), 
            // Mathf.Clamp(transform.position.y, -200f, 200f));
            Move();
        }

    }

    static public void activateFall()
    {

        yes = true;

    }


    static public void changeMoveSpeed()
    {
        move_Speed = 0.1f;
    }
    static public void changeMoveSpeed2()
    {
        move_Speed = 2.2f;
    }

    public void Move()
    {
        //rb.isKinematic = false;
        Vector2 temp = transform.position;
        temp.y -= move_Speed;
       // transform.position = temp;
        if (temp.y <= backgroundTransform.position.y - 200f)
        {
            gameObject.SetActive(false);
        }

    }
}

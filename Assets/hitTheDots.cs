using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitTheDots : MonoBehaviour
{
    public ParticleSystem Particle;
    private Collider cl;
    public GameObject platform;

    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        cl = GetComponent<Collider>();
        ball = GameObject.FindGameObjectWithTag("ball");

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "platform")
        {
            Physics.IgnoreCollision(platform.GetComponent<Collider>(), GetComponent<Collider>());
        }
        if (col.gameObject.tag == "dot")
        {
            Physics.IgnoreCollision(cl, GetComponent<Collider>());
        }
        if (col.gameObject.tag == "tail" || col.gameObject.tag == "ball")
        {
        Instantiate(Particle, transform.position, transform.rotation);
        gameObject.SetActive(false);
            if(col.gameObject.tag == "tail"){
             col.gameObject.SetActive(false);
            }
               if(col.gameObject.tag == "ball"){
             col.gameObject.SetActive(false);
            }
        }
      

    }

    
}

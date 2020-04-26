using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitThePlats : MonoBehaviour
{
    public GameObject ball;
    public ParticleSystem Particle;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("ball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ball") {
            Instantiate(Particle, transform.position, transform.rotation);
            gameObject.SetActive(false);
            ball.GetComponent<Ball>().addCounter();

        }

        if (col.gameObject.tag == "tail")
        {
            Instantiate(Particle, transform.position, transform.rotation);
            gameObject.SetActive(false);
            col.gameObject.SetActive(false);

        }


    }
}

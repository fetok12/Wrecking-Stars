using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizeDots : MonoBehaviour
{
    public GameObject dot;
    public GameObject platform;
    // Start is called before the first frame update
    void Awake()
    {

        for(int i=0; i<5; i++)
        {
            Vector2 position = new Vector2(Random.Range(-374.0f, 374.0f), Random.Range(-249.0f, 249.0f));
          Instantiate(dot, position, Quaternion.identity);
        }

        for (int i = 0; i < 50; i++)
        {
            Vector2 position = new Vector2(Random.Range(-374.0f, 374.0f), Random.Range(-249.0f, 249.0f));
            Instantiate(platform, position, Quaternion.identity);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

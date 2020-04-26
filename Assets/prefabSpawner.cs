using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabSpawner : MonoBehaviour
{

    public GameObject prefabDot;
    public GameObject prefabPlatform;
    static bool activate = false;

    private Transform backgroundTransform;

    private static bool alreadyInvoked = false;
    public float platform_Spawn_Timer = 2f;
    private float current_Platform_Spawn_Timer;

    static float spawnTimer = 0.05f;

    public float min_X = -130f, max_X = 130f;
    public float min_Y = -230f, max_Y = 290f;
    // Start is called before the first frame update
    void Start()
    {
        backgroundTransform = GameObject.FindGameObjectWithTag("background").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (activate)
        {
                InvokeRepeating("spawn", 0.0f, spawnTimer);
                activate = false;
            

        }

    }

    void spawn()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector2 temp = transform.position;
            temp.x = Random.Range(min_X + backgroundTransform.position.x, max_X + backgroundTransform.position.x);
            Instantiate(prefabDot, temp, Quaternion.identity);

     //       temp.y = Random.Range(min_Y + backgroundTransform.position.y, max_Y + backgroundTransform.position.y);
       //     Instantiate(prefabDot, temp, Quaternion.identity);
        }




        Vector2 temp2 = transform.position;
        temp2.x = Random.Range(min_X + backgroundTransform.position.x, max_X + backgroundTransform.position.x);
        Instantiate(prefabPlatform, temp2, Quaternion.identity);

        Vector3 temp3 = transform.position;
        temp3.y = backgroundTransform.position.y + 290f;
        temp3.x = backgroundTransform.position.x + 130f;

        transform.position = temp3;

    }
    static public void slowDownSpawn()
    {
        spawnTimer = 20f;
    }
    static public void speedUpSpawn()
    {
        spawnTimer = 0.05f;
    }

    
     public void activateSpawn()
    {
        InvokeRepeating("spawn", 0.0f, 0.2f);
        // activate = true;
        // alreadyInvoked = true;
    }

     public void deactivateSpawn()
    {
        CancelInvoke();
    }

}

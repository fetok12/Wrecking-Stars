using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool isPressed;

    public float scroll_Speed = 0.3f;
    public MeshRenderer mesh_Renderer;

    private bool gg = false;


    [SerializeField] float multiplier;
    Vector3 initPos;
    Vector3 tempInitPos;


    private bool done = false;
    private bool lower = false;
    private bool firstTime = true;

    public int projectileCount = 0;

    private bool hold = false;

    private float releaseDelay;
    private float maxDragDistance = 1.8f;
    private float currentPosition;
    private float lastPosition;
    private int isFalling = 0;

    private Rigidbody2D rb;
    private SpringJoint2D sj;
    private Rigidbody2D slingRb;
    private LineRenderer lr;
    private TrailRenderer tr;

    public GameObject prefabDot;
    public GameObject prefabPlatform;
    public GameObject Spawner;
    public GameObject tailPrefab;
    private GameObject Background;



    // private Transform slingTransform;

    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        // sj = GetComponent<SpringJoint2D>();
        //  slingRb = sj.connectedBody;
        lr = GetComponent<LineRenderer>();
        tr = GetComponent<TrailRenderer>();
        lastPosition = transform.position.y;
        Background = GameObject.FindGameObjectWithTag("background");

        //slingTransform = GameObject.FindGameObjectWithTag("sling").transform;
        //slingRb.position = transform.position;



        tr.enabled = false;

        releaseDelay = 1 / (2000 * 4);
    }

    // Update is called once per frame
    void Update()
    {
       
        //zoom(Input.GetAxis("Mouse ScrollWheel"));
        if (isPressed)
        {
            // DragBall();


        }

        if (gg)
        {
            currentPosition = transform.position.y + 5f;
            if (currentPosition < lastPosition)
            {
                scrolldot.changeMoveSpeed();
                scrollPlat.changeMoveSpeed();
                if (!lower)
                {
                   
                    isFalling = 1;
                    Background.GetComponent<Scroll>().NotFalling();
                    lower = true;
                }



            }

            lastPosition = currentPosition;

            Vector2 offset = mesh_Renderer.sharedMaterial.GetTextureOffset("_MainTex");
            offset.y += Time.deltaTime * scroll_Speed;

            mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);


        }
        if (isFalling == 1)
        {
            if (!done)
            {
                 rb.bodyType = RigidbodyType2D.Static;
                StartCoroutine(zoomIn());
            }
             Spawner.GetComponent<prefabSpawner>().deactivateSpawn();
            // prefabSpawner.deactivateSpawn();
            Time.timeScale = 0.25f;
            Time.fixedDeltaTime = Time.timeScale * 0.01f;
        }
        if (isFalling == 2)
        {
     
            StartCoroutine(DelayInstantiate());
            Time.timeScale = 1f;
            // Time.fixedDeltaTime = Time.timeScale * 0.0f;
        }
    }

    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, 1f, 20f);
    }

    // private void DragBall()
    // {
    //     SetLinerRenderePositions();
    //
    //     Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     float distance = Vector2.Distance(mousePosition, slingTransform.position);
    //
    //     if(distance > maxDragDistance)
    //     {
    //       
    //
    //         Vector2 direction = (mousePosition - slingRb.position).normalized;
    //         rb.position = slingRb.position + direction * maxDragDistance;
    //     }
    //     else
    //     {
    //     rb.position = mousePosition;
    //     }
    //
    //    
    // }
    private void SetLinerRenderePositions()
    {
        Vector3[] positions = new Vector3[2];
        positions[0] = rb.position;
        //positions[1] = slingTransform.position;
        // positions[1] = slingRb.position;
        lr.SetPositions(positions);
    }

    private void OnMouseDown()
    {
        isPressed = true;
        // rb.isKinematic = true;
        initPos = rb.position;
    }


    private void OnMouseUp()
    {
        scrolldot.changeMoveSpeed2();
        scrollPlat.changeMoveSpeed2();

        isFalling = 2;
        Background.GetComponent<Scroll>().Falling();
        done = false;
        isPressed = false;
        rb.isKinematic = false;


        //  prefabDot.GetComponent<scrolldot>().activateFall();
   
            scrolldot.activateFall();
            scrollPlat.activateFall();
            Spawner.GetComponent<prefabSpawner>().activateSpawn();
            //prefabSpawner.activateSpawn();

        StartCoroutine(DelayInstantiate());
        StartCoroutine(DelayDeactivateSpawn());
        Vector3 cameraPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
     
        tempInitPos = (initPos - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10))) * Vector3.Distance(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), initPos) * multiplier;
         
         if(tempInitPos.y < 100000f && !firstTime){
             tempInitPos.y = 150000f;
            rb.AddForce(tempInitPos);
         }
         else if(tempInitPos.y < 200000f && firstTime){
             firstTime = false;
            rb.AddForce(tempInitPos);
         }else{
             tempInitPos.y = 200000f;
            rb.AddForce(tempInitPos);
         }
        //  else{
        // tempInitPos.y = 15000f;
        // rb.AddForce(tempInitPos);
        // }
        //  zoom(Input.GetAxis("Mouse ScrollWheel"));
     //   StartCoroutine(waitForPrefab(cameraPos));
        StartCoroutine(Release());
        lr.enabled = false;
        gg = true;

   


    }

    public void throwProjectile()
    {
        Vector3 cameraPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        StartCoroutine(waitForPrefab(cameraPos));
    }

    public void addCounter()
    {
        projectileCount += 200;
    }

    public void holding()
    {
        hold = true;
    }

    public void notHolding()
    {
        hold = false;
    }

    private IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);
      //  sj.enabled = false;
        tr.enabled = true;
    }

    public IEnumerator DelayInstantiate()
    {

        for (int i = 1; i < 5; i++)
        {
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize + i, 1f, 200f);
            yield return new WaitForSeconds(0.02f);
        }

        lower = false;
    }

  public IEnumerator DelayDeactivateSpawn()
    {
        yield return new WaitForSeconds(3);
        Spawner.GetComponent<prefabSpawner>().deactivateSpawn();
    }

    public IEnumerator zoomIn()
    {

        for (int i = 1; i < 5; i++)
        {
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - i, 20f, 200f);
            yield return new WaitForSeconds(0.02f);
        }

        done = true;
    }

    IEnumerator waitForPrefab(Vector3 cameraPos)
    {
        //for(int i = 0; i< projectileCount; i++)
        //{
        while (projectileCount > 0 && hold)
        {
        
            // if (hold)
            // {
                GameObject tail = Instantiate(tailPrefab, rb.position, Quaternion.identity);
                //  tail.transform.localScale += new Vector3(0.55f,0.55f,0);
                tail.GetComponent<Rigidbody2D>().isKinematic = false;
                tail.GetComponent<Rigidbody2D>().AddForce((tail.transform.position - transform.position).normalized * 250000f);
                //  tail.GetComponent<Rigidbody2D>().AddForce(-(tail.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10))) * Vector3.Distance(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), tail.transform.position) * 5f);
                projectileCount--;
                Debug.Log(projectileCount);
            // }

            yield return new WaitForSeconds(0.20f);
        }

        //Debug.Log((new Vector3(transform.position.x, transform.position.y) - Camera.main.ScreenToWorldPoint(new Vector3(transform.position.x, transform.position.y, 10))) * Vector3.Distance(Camera.main.ScreenToWorldPoint(new Vector3(transform.position.x, transform.position.y, 10)), new Vector3(transform.position.x, transform.position.y)));
        // }





    }

}

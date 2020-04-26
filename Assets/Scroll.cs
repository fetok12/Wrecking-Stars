using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
      public float scroll_Speed = 0.3f;
    private bool isFalling = false;
    public GameObject ball;
    private MeshRenderer mesh_Renderer;

    // Start is called before the first frame update
    void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
        ball = GameObject.FindGameObjectWithTag("ball");
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnMouseDown()
    {

        if (isFalling)
        {
        ball.GetComponent<Ball>().holding();
        ball.GetComponent<Ball>().throwProjectile();
        }
       
    }
    private void OnMouseUp()
    {
        ball.GetComponent<Ball>().notHolding();
    }

    public void Falling()
    {
        isFalling = true;
    }
    public void NotFalling()
    {
        isFalling = false;
    }
    void scroll()
    {
        Vector2 offset = mesh_Renderer.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y += Time.deltaTime * scroll_Speed;

        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);

      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hgdkhgfgplayercontrollers : MonoBehaviour
{
    public List<GameObject> nearby;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = GameObject.Find("checkpoint").GetComponent<checkpoint>().lastCheckPointPos;
    }
    public Rigidbody2D rb;
    public LayerMask ground;
    public ParticleSystem particles;
    public bool isplaying;
    void Update()
    {
        if(Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.BackQuote)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        rb.velocity += Input.GetAxisRaw("Horizontal") * Vector2.right * Time.deltaTime * 10;
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.velocity += Input.GetAxisRaw("Horizontal") * Vector2.right * 25;
        }

        if(Input.GetKey(KeyCode.LeftAlt)) 
        {
            rb.gravityScale = 10;
        } 
        else if(Input.GetKey(KeyCode.LeftControl))
        {
            rb.gravityScale = -10;
        } else {
            rb.gravityScale = 1;
        }
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && Physics2D.OverlapCircle(transform.position + Vector3.down, 1f, ground)) {
            rb.velocity = new Vector2(rb.velocity.x, 20);
            Debug.Log("jump");
        }
        if(Input.GetKeyDown(KeyCode.T)){
        Debug.Log("another message");
        foreach(GameObject npc in nearby){
            npc.GetComponent<directions>().StartCoroutine(npc.GetComponent<directions>().Activate());
        }
        }
        if(Input.GetKeyDown(KeyCode.R)){
            Debug.Log("particles");
            if(isplaying){
                particles.Stop();
                isplaying = false;
            } else {
                particles.Play();
                isplaying = true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.layer == 8){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
        void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.layer == 13){
            Debug.Log("aaaa");
            GameObject.Find("checkpoint").GetComponent<checkpoint>().lastCheckPointPos = transform.position;
        }
    }
}
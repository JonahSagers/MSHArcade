using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask ground;
    public int heldItem;
    public List<GameObject> nearby;
    public ParticleSystem particles;
    public Rigidbody2D rb; 
    public int myspeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.LeftShift))
        {
            myspeed = 80;
        }
        else
        {
            myspeed = 30;
        }
        rb.velocity += Input.GetAxisRaw("Horizontal") * Vector2.right * Time.deltaTime * myspeed;
        if(Input.GetKeyDown(KeyCode.F)){
            foreach(GameObject npc in nearby){
                npc.GetComponent<Interact>().StartCoroutine(npc.GetComponent<Interact>().Activate());
            }
        }
    }
}

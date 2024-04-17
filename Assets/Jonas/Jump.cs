using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Jump : MonoBehaviour
{

    public Rigidbody2D rb;
    public int jumpheight = 5;
    public int speed = 10;
    public LayerMask ground;
    public int heldItem;
    public bool OnLadder;
     public List<GameObject> nearby;
     public int key;
     public bool hasSword;
     public GameObject Sword;
     public TextMeshProUGUI CDisplay;

    void Start()
    {
        transform.position = GameObject.Find("Savior").GetComponent<Savior>().lastCheckpoint;
        heldItem = GameObject.Find("Savior").GetComponent<Savior>().heldItem;
        hasSword = GameObject.Find("Savior").GetComponent<Savior>().hasSword;
    }
    void Update()
    {
        rb.velocity += Input.GetAxisRaw ("Horizontal") * Vector2.right * Time.deltaTime * speed;

        if(Input.GetKeyDown (KeyCode.Space) && Physics2D.OverlapCircle(transform.position + Vector3.down, 0.5f, ground) && OnLadder == false) 
        {
            rb.velocity = new Vector2 (rb.velocity.x,jumpheight);
        }
        
        if(Input.GetKey (KeyCode.Space) && OnLadder){
            rb.velocity = new Vector2 (rb.velocity.x, 5);
        }

        if(Input.GetAxisRaw("Horizontal") < 0) {
           transform.rotation = Quaternion.Euler(new Vector3 (0,0,0)); 
        } 
         if(Input.GetAxisRaw("Horizontal") > 0) {
           transform.rotation = Quaternion.Euler(new Vector3 (0,180,0)); 
        }
        if(rb.velocity.y < -0.5f)
        {
            rb.gravityScale = 2;
        }
        if(rb.velocity.y >= -0.5f) 
        {
            rb.gravityScale = 1;
        }
        if(Input.GetKeyDown(KeyCode.T)){
            foreach(GameObject npc in nearby){
                npc.GetComponent<CatInteract>().StartCoroutine(npc.GetComponent<CatInteract>().Activate());
            }
        }
        //Debug.Log(rb.velocity);
        if(hasSword){
            Sword.SetActive (true);

        }

        CDisplay.text = heldItem.ToString()+" Coins";
    }
    
  

    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.layer == 6 || collider.gameObject.layer == 13){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(collider.gameObject.layer == 8){
            heldItem += collider.gameObject.GetComponent<PickupData>().value;
            Destroy(collider.gameObject);
            GameObject.Find("Savior").GetComponent<Savior>().heldItem += 1;
        }
         if(collider.gameObject.layer == 7){
            key += collider.gameObject.GetComponent<PickupData>().value;
            Destroy(collider.gameObject);
        }
        if(collider.gameObject.layer == 11 && key > 0){
            Destroy(collider.gameObject);
            key -= 1;
        }
         if(collider.gameObject.layer == 12 && heldItem >= 3){
            hasSword = true;
            Destroy(collider.gameObject);
            GameObject.Find("Savior").GetComponent<Savior>().hasSword=true;
            heldItem -= 3;
        }
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.layer == 9)
            {
            OnLadder = true;
            Debug.Log ("EnterLadder");
            }
        if(collider.gameObject.layer == 15)
            {
            GameObject.Find("Savior").GetComponent<Savior>().lastCheckpoint = transform.position;
            }
        if(collider.gameObject.layer == 14)
            {
                SceneManager.LoadScene("JonasEnd");
            }
        }
        

    void OnTriggerExit2D(Collider2D collider){
          if(collider.gameObject.layer == 9){
            OnLadder = false;
             Debug.Log ("ExitLadder");
            }
        }

}

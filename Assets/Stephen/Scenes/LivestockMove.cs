using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivestockMove : MonoBehaviour
{
    public float LivestockHealth = 3;
    public Rigidbody2D rb;
    public Transform player;
    public LayerMask Ground;
    public GameObject RawMeat;
    // this is for the livestock. might need to be changed back to transform 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeDirection(Random.Range(5,15)));
    }

    // Update is called once per frame
    void Update()
    {

        // rb.velocity = new Vector2(patrolrandom, rb.velocity.y);
        // if(CanChangeDirection==1){
        //     CanChangeDirection=0;
        //     StartCoroutine(ChangeDirection(Random.Range(2,5)));
        // }
        if(LivestockHealth <0.1){
             Destroy(gameObject);
             Instantiate(RawMeat, transform.position, transform.rotation);
             // this is for the livestock
             // make a new item called food that has the item script
         }
        rb.velocity=transform.right;




    }
    
    public IEnumerator ChangeDirection(float cooldown){
        // yield return new WaitForSeconds(cooldown);
        // CanChangeDirection=1;
        //  transform.rotation=Quaternion.Euler(new Vector3 (0,0,0));
        //  transform.rotation=Quaternion.Euler(new Vector3 (0,180,0));
        // patrolrandom=Random.Range(-1,2);
        while(true){
            transform.rotation=Quaternion.Euler(new Vector3 (0,0,0));
            yield return new WaitForSeconds(cooldown);
            transform.rotation=Quaternion.Euler(new Vector3 (0,180,0));
            yield return new WaitForSeconds(cooldown);
        }
    }
    
}

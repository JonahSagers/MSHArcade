using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float enemyHealth;
    public float patrolrandom;
    public int CanChangeDirection;
    public Rigidbody2D rb;
    public Transform player;
    public LayerMask Ground;
    // for some reason the enemyhealth can't be changed past 3 for whatever reason so I guess I just gotta adapt to it.
    public GameObject Enemy;
    public GameObject Essence;
    void Start()
    {
        player=GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(patrolrandom, rb.velocity.y);
        if(CanChangeDirection==1){
            CanChangeDirection=0;
            StartCoroutine(ChangeDirection(1));
        }
        if(enemyHealth <0.1){
            Destroy(gameObject);
            Instantiate(Essence, transform.position, transform.rotation);
        }


        if(Vector2.Distance(player.position,transform.position)<20){
            // Transform is a set of data containing the position and the rotation.
            if(Physics2D.OverlapCircle(transform.position + Vector3.down, 0.1f, Ground) && (Physics2D.OverlapCircle(transform.position + Vector3.right, 0.1f, Ground)||(Physics2D.OverlapCircle(transform.position + Vector3.left, 0.1f, Ground)))){
                rb.velocity=new Vector2(rb.velocity.x,6);
            }
            if(player.position.x > transform.position.x){
                rb.velocity+= new Vector2(5,0);
            }else{
                rb.velocity+= new Vector2(-5,0);
            }
        }


    }
    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
    }
    
    public IEnumerator ChangeDirection(float cooldown){
        yield return new WaitForSeconds(cooldown);
        CanChangeDirection=1;
        patrolrandom=Random.Range(-1,2);
    }



    
}

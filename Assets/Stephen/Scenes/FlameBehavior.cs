using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBehaviour : MonoBehaviour
{
    public LayerMask Player;
    public float Delete;

    // Start is called before the first frame update
    void Start()
    {
        transform.position += transform.up * Time.deltaTime * 100;
        Delete=300;
    }

    // Update is called once per frame
    private void Update()
    {
        foreach(Collider2D target in Physics2D.OverlapCircleAll(transform.position, 1)){
            if(target.gameObject.layer==19){
                Destroy(target.gameObject);
            }
        }

        if(Delete==0){
            Destroy(gameObject);
        }

    }

    void FixedUpdate()
    {
        Delete-=1;
    }
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if(collision.gameObject.layer==12){
            collision.gameObject.GetComponent<EnemyMove>().enemyHealth-=1.5f;
        }
       

        
        
        

    }
}

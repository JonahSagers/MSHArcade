using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public LayerMask Player;
    public float ProjectileDamage;
    // Start is called before the first frame update
    void Start()
    {
        ProjectileDamage = 2;
    }
    public float speed = 4.5f;
    // Update is called once per frame
    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed * 20;
        ProjectileDamage -= 0.05f;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(ProjectileDamage < 1){
            ProjectileDamage = 1f;
        }
        
        if(collision.gameObject.layer==12){
            collision.gameObject.GetComponent<EnemyMove>().enemyHealth-=ProjectileDamage;
            Destroy(gameObject);
        }
        if(collision.gameObject.layer==16){
            collision.gameObject.GetComponent<LivestockMove>().LivestockHealth-=ProjectileDamage;
            Destroy(gameObject);
        }
        if(collision.gameObject.layer != 8){
            if(collision.gameObject.layer != 17){
                if(collision.gameObject.layer != 14){
                    if(collision.gameObject.layer != 13){
                        Destroy(gameObject);
                    }
                }
            }
        }

    }
}

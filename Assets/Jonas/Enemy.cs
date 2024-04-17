using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody2D rb;
    public LayerMask ground;
    public int steps;
    public int totalsteps;
    public int direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
    }

    void Update()
    {
        if(rb.velocity.x < 0) {
           transform.rotation = Quaternion.Euler(new Vector3 (0,0,0)); 
        } 
         if(rb.velocity.x > 0) {
           transform.rotation = Quaternion.Euler(new Vector3 (0,180,0)); 
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
         rb.velocity = new Vector2(speed * direction, rb.velocity.y);
        if(steps < 1){
            direction *= -1;
            steps = totalsteps; 
        }
        steps -= 1;
    }

}

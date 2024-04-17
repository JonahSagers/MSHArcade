using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WBPatrol : MonoBehaviour
{
    public LayerMask wallLayer;
    bool isFacingRight = true;
    public float speed = 5f;
    public float raylen = 10f;

    public Transform Ltrturner;
    public Transform Rtlturner;
    RaycastHit2D hit;
    public Rigidbody2D rb;
    public Move move;

    // Start is called before the first frame update
    void Start()
    {
        move = GameObject.Find("Virus").GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFacingRight == true)
        {
            hit = Physics2D.Raycast(Rtlturner.position, Vector2.right, raylen, wallLayer);
            rb.velocity = new Vector2(speed, rb.velocity.y);
            Debug.DrawRay(Rtlturner.position, Vector2.right, Color.green, raylen);
        }
        if(isFacingRight == false)
        {
            hit = Physics2D.Raycast(Ltrturner.position, Vector2.left, raylen, wallLayer);
            rb.velocity = new Vector2(speed * -1, rb.velocity.y);
            Debug.DrawRay(Ltrturner.position, Vector2.right, Color.green, raylen);
        }
        if(hit)
        {
            if(isFacingRight == true)
            {
                isFacingRight = false;
            } 
            else 
            {
                isFacingRight = true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D hit) 
    {
        if(hit.gameObject.layer == 7)
        {
            move.TakeDamage(90);
            move.rb.AddForce((transform.position - move.gameObject.transform.position) * -500f);
        }
    }
    void OnCollisionStay2D(Collision2D hit)
    {
        if(hit.gameObject.layer == 7){
            move.TakeDamage(10);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerTCell : MonoBehaviour
{
    public Vector2 noiseOffset;
    public Rigidbody2D rb;
    public Move move;
    private float offsetOffset;
    // Start is called before the first frame update
    void Start()
    {
        move = GameObject.Find("Virus").GetComponent<Move>();
        offsetOffset = Random.Range(5f,10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        noiseOffset = new Vector2(Mathf.PerlinNoise((Time.time + offsetOffset)/(offsetOffset/10),10) -0.45f,Mathf.PerlinNoise(10,(Time.time + offsetOffset)/(offsetOffset/10))-0.45f);
        rb.velocity += noiseOffset/2;
        if(Mathf.Abs(rb.angularVelocity) < 10){
            rb.AddTorque((Mathf.PerlinNoise((Time.time + offsetOffset)/(offsetOffset/10),10) -0.45f),ForceMode2D.Force);
        }
        rb.velocity *= 0.85f;
    }

    void OnCollisionEnter2D(Collision2D hit) 
    {
        if(hit.gameObject.layer == 7){
            Debug.Log("test");
            move.TakeDamage(60);
            move.rb.AddForce((transform.position - move.gameObject.transform.position) * -300f);
            Destroy(gameObject);
        }
    }
}

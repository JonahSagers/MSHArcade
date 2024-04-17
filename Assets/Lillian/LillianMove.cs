using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LillianMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public LayerMask ground;
    public int score;
    public Transform resetposition;
    public Transform teleposition;
    public int targetscore;
    public int bossScore;
    // Start is called before the first frame update
    void Start()
    {
        targetscore = Random.Range(10, 30);
        bossScore = targetscore + Random.Range(10, 30) + 1;
        Debug.Log(targetscore);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
        rb.velocity += Input.GetAxisRaw("Horizontal") * Vector2.right * Time.deltaTime * 20;

        if(Input.GetKeyDown(KeyCode.R))
        {
           transform.position = resetposition.position;
           Debug.Log("reset");
        }

        if(Input.GetKeyDown(KeyCode.Space) && Physics2D.OverlapCircle(transform.position + Vector3.down, 0.5f, ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, 15);
        }

        if(score == targetscore)
        {
           transform.position = teleposition.position;
           Debug.Log("teleport");
            score +=1;
                    if(score >= bossScore){
            Debug.Log("You win!");
        }       else{
            Debug.Log("You really thought I'd let you win. Fool!");
        }
        }

    }

   void OnCollisionEnter2D(Collision2D collider)
   {
        if(collider.gameObject.layer == 9){
            score += 1;
            Destroy(collider.gameObject);
        }
    }
}

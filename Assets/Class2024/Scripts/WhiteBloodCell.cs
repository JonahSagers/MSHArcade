using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBloodCell : MonoBehaviour
{
    public GameObject target;
    public Vector3 rotatePosition;
    public float rotateAngle;
    public float sightRange;
    public LayerMask collidable;
    public bool visible;
    public GameObject hit;
    public Rigidbody2D rb;
    public Move playerMove;
    public GameObject antibodyPrefab;
    public GameObject antibody;
    public float red;
    public SpriteRenderer render;
    public bool infected;
    public Vector2 noiseOffset;
    public int level;
    public LayerMask tLayers;
    // Start is called before the first frame update
    void Awake()
    {
        playerMove = GameObject.Find("Virus").GetComponent<Move>();
        target = playerMove.gameObject;
        infected = false;
        StartCoroutine(AttackCycle());
        sightRange = 10;
    }

    void Update()
    {
        if(visible && playerMove.gameOver == false){
            rotatePosition = target.transform.position - transform.position;
            rotateAngle = Mathf.Atan2(rotatePosition.y, rotatePosition.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(rotateAngle, Vector3.forward), Time.deltaTime * 6);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerMove.gameOver == false){
            hit = Physics2D.Linecast(transform.position, target.transform.position, collidable).transform.gameObject;
            if (hit == target && Vector2.Distance(hit.transform.position, transform.position) < 30){
                visible = true;
            } else {
                visible = false;
                noiseOffset = new Vector2(Mathf.PerlinNoise(Time.time/2,0) -0.45f,Mathf.PerlinNoise(0,Time.time/2)-0.45f);
                rb.velocity += noiseOffset/2;
                rb.AddTorque((Mathf.PerlinNoise(Time.time/2,0) -0.45f),ForceMode2D.Force);
                rb.velocity *= 0.85f;
            }
            if((Vector3.Distance(target.transform.position, transform.position) > 5 || playerMove.weakened == true) && visible){
                rb.AddForce((target.transform.position - transform.position) * level * 1.3f);
                if(playerMove.weakened == true){
                    rb.AddForce((target.transform.position - transform.position) * level * 1.3f);
                }
            }
            if((Vector3.Distance(target.transform.position, transform.position) < 3 && playerMove.weakened == false) && visible){
                rb.AddForce((target.transform.position - transform.position) * level * -2);
            }
        }
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x,-8,8),Mathf.Clamp(rb.velocity.y,-8,8),0);
    }
    IEnumerator Shotgun(){
        for(int i = 0;i < level; i++){
            antibody = Instantiate(antibodyPrefab, transform.position + transform.right , transform.rotation);
            antibody.transform.parent = transform;
            antibody.GetComponent<AntibodyPellet>().Launch();
            yield return new WaitForSeconds(Random.Range(0.01f,0.1f));
        }
    }
    IEnumerator AttackCycle(){
        while(true){
            if(visible && playerMove.gameOver == false){
                StartCoroutine(Shotgun());
                yield return new WaitForSeconds(Random.Range(1.5f,3f));
            } else {
                yield return new WaitForSeconds(Random.Range(0.5f,1f));
            }
        }
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.layer == 7 && playerMove.weakened == true){
            hit.gameObject.GetComponent<Move>().TakeDamage(20);
            rb.AddForce((target.transform.position - transform.position) * -250f);
        }
        if(hit.gameObject.layer == 7 && playerMove.weakened == false){
            if(infected == false){
                StartCoroutine(Infected());
            }
        }
        if(hit.gameObject.layer == 10 && infected == true){
            Destroy(gameObject);
            Destroy(hit.gameObject);
        }
    }
    IEnumerator Infected()
    {
        Collider2D[] tCheck = Physics2D.OverlapCircleAll(transform.position, 20f, tLayers);
        infected = true;
        red = 0;
        while(red < 1){
            if (tCheck != null)
            {
                foreach(Collider2D t in tCheck){
                    t.gameObject.GetComponent<Rigidbody2D>().AddForce((transform.position - t.gameObject.transform.position) * 25);
                }
            } else {
                tCheck = Physics2D.OverlapCircleAll(transform.position, 10f, tLayers);
            }
            red += 0.01f;
            render.color = new Color(1,1 - red,1 - red);
            yield return new WaitForSeconds(0.02f);
        }
        playerMove.swarmCount *= 2;
        transform.GetChild(0).GetComponent<DelayedDelete>().StartCoroutine(transform.GetChild(0).GetComponent<DelayedDelete>().Countdown(3));
        Destroy(gameObject);
    }
}

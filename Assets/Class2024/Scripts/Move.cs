using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public int inMucus = 0;
    public Rigidbody2D rb;
    public float playerRotation;
    public bool weakened;
    public float health;
    public Coroutine currentRegenRoutine;
    public GameObject swarm;
    public ParticleSystem swarmParticles;
    public int swarmCount;
    public Animator anim;
    public bool gameOver;
    public GameObject deathParticleEmitter;
    public bool mouseControl;
    public Vector3 mousePosition;
    public ParticleSystemForceField particleField;
    public float particleFieldRange;
    // Start is called before the first frame update
    void Start()
    {
        mouseControl = false;
        gameOver = false;
        health = 100;
        particleField.startRange = 1;
        //swarmCount = 4;
    }
    void Awake()
    {
        //rb.AddTorque(10,ForceMode2D.Force);
        //rb.velocity += new Vector2(50,250);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            mouseControl = true;
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
            mouseControl = false;
        }
        var swarmParticlesMain = swarmParticles.main;
        swarmParticlesMain.maxParticles = swarmCount - 1; 
        particleFieldRange = particleField.startRange;
        if(((float)swarmCount) > Mathf.Pow(2,particleFieldRange+3)  && particleField.startRange < 8){
            particleField.startRange += 1;
        }

        // if(gameObject == null)
        // {
        //     AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Final Production");
        //     Debug.Log("Ded");

        // }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Mathf.Abs(rb.angularVelocity) < 10){
            rb.AddTorque((Mathf.PerlinNoise(Time.time,0) -0.45f),ForceMode2D.Force);
        }
        if(mouseControl == false){
            if (weakened && inMucus == 1){
                rb.velocity += new Vector2(Input.GetAxisRaw("Horizontal") * 0.1f,Input.GetAxisRaw("Vertical") * 0.1f);
            } else if(weakened){
                rb.velocity += new Vector2(Input.GetAxisRaw("Horizontal") * 0.6f,Input.GetAxisRaw("Vertical") * 0.6f);
            } else if(inMucus == 1) {
                rb.velocity += new Vector2(Input.GetAxisRaw("Horizontal") * 0.2f,Input.GetAxisRaw("Vertical") * 0.2f);
            } else {
                rb.velocity += new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
            }
        } else {
            if(Input.GetMouseButton(0)){
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //rb.AddForce((new Vector3(Mathf.Clamp(((Input.mousePosition.x/Screen.width)- 0.5f)*2,-1,1)*10,Mathf.Clamp(((Input.mousePosition.y/Screen.height)- 0.5f)*2,-1,1)*10,0) - transform.position));
                rb.AddForce(new Vector3(Mathf.Clamp(mousePosition.x - transform.position.x,-6.35f,6.35f),Mathf.Clamp(mousePosition.y - transform.position.y,-6.35f,6.35f),0)*7.2f);
            }
        }
        rb.velocity *= 0.91f;
        //playerRotation = Mathf.Atan((rb.velocity.x + rb.velocity.y)/2);
        //transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x,transform.rotation.y,playerRotation));
    }
    public void TakeDamage(float amount)
    {
        if(currentRegenRoutine != null){
            StopCoroutine(currentRegenRoutine);
        }
        if(weakened == true){
            if(amount > swarmCount){
                if(gameOver == false){
                    StartCoroutine(Die());
                }
            } else {
                swarmCount -= (int)amount;
                currentRegenRoutine = StartCoroutine(Heal(5));
            }
        } else {
            if(amount >= health){
                health = 0;
                weakened = true;
                currentRegenRoutine = StartCoroutine(Heal(5));
            } else {
                health -= amount;
                currentRegenRoutine = StartCoroutine(Heal(2));
            }
        }
        
    }
    IEnumerator Heal(float delay)
    {
        yield return new WaitForSeconds(delay);
        weakened = false;
        while(health < 100){
            health += 1f;
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator Die()
    {
        swarmCount = 0;
        Debug.Log("Game Over");
        gameOver = true;
        anim.Play("Death");
        yield return new WaitForSeconds(1);
        GameObject.Find("Death Particles").GetComponent<DelayedDelete>().StartCoroutine(GameObject.Find("Death Particles").GetComponent<DelayedDelete>().Countdown(3));
        rb.velocity *= 0;
        Destroy(gameObject);
        SceneManager.LoadScene("FinalProduction");

    }



}

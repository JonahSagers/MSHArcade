using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntibodyPellet : MonoBehaviour
{
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    public void Launch()
    {
        Physics.IgnoreLayerCollision(8, 8);
        transform.parent = null;
        transform.rotation = Quaternion.Euler(transform.eulerAngles + (Vector3.forward * Random.Range(-25,25)));
        rb.AddForce(transform.right * 300);
        rb.AddTorque(Random.Range(-100,100),ForceMode2D.Force);
        StartCoroutine(Lifespan());
    }
    IEnumerator Lifespan()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.layer == 7){
            hit.gameObject.GetComponent<Move>().TakeDamage(20);
            Destroy(gameObject);
        }
    }
}

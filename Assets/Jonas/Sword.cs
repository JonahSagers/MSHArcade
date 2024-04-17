using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Animator anim;
    public bool Active;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G) && Active == false){
            StartCoroutine(Attack());
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 13 && Active){
            Destroy (collider.gameObject);
        }
    }
    public IEnumerator Attack(){
        anim.Play("Swingsword");
        Active = true;
        yield return new WaitForSeconds (1f);
        Active = false;
    }
}

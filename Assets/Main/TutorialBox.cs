using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBox : MonoBehaviour
{
    public bool triggered;
    public bool activated;
    public Animator anim;
    public bool hovered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(triggered == true){
            anim.Play("Appear");
            triggered = false;
            activated = true;
        }
        if(activated && Input.GetMouseButtonDown(0)){
            if(hovered){
                Debug.Log("Game Start");
            } else {
                anim.Play("Disappear");
            }
        }
    }
    void OnMouseEnter()
    {
        hovered = true;
    }
    void OnMouseExit()
    {
        hovered = false;
    }
}

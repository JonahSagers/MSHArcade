using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInteract : MonoBehaviour
{
    bool hovered;
    public TutorialBox tutorial;
    public string targetScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!hovered){
            transform.localScale += new Vector3((1-transform.localScale.x)/10,(1-transform.localScale.y)/10,0);
        }
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButton(0)){
            hovered = false;
        } else {
            hovered = true;
            transform.localScale += new Vector3((1.15f-transform.localScale.x)/10,(1.15f-transform.localScale.y)/10,0);
        }
    }
    void OnMouseExit()
    {
        hovered = false;
    }
    void OnMouseDown()
    {
        tutorial.StartCoroutine(tutorial.Appear());
    }
}

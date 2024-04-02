using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInteract : MonoBehaviour
{
    bool hovered;
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
        if(!Input.GetMouseButton(0)){
            hovered = true;
            transform.localScale += new Vector3((1.2f-transform.localScale.x)/10,(1.2f-transform.localScale.y)/10,0);
        } else {
            hovered = false;
        }
    }
    void OnMouseExit()
    {
        hovered = false;
    }
    void OnMouseDown()
    {
        Debug.Log("PING");
    }
}

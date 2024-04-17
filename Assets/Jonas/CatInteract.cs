using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CatInteract : MonoBehaviour
{
    public List<string> dialogue;
    public TextMeshPro message;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 3){
            collider.gameObject.GetComponent<Jump>().nearby.Add(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 3){
            collider.gameObject.GetComponent<Jump>().nearby.Remove(gameObject);
        }
    }
    public IEnumerator Activate(){
        message.text = "";
        foreach(string line in dialogue)
        {
            for(int i = 0; i < line.Length; i++)
            {
                message.text += line[i];
                yield return new WaitForSeconds(0.01f);
            }
           yield return new WaitForSeconds(2f);
           message.text = "";
        }
    }
}

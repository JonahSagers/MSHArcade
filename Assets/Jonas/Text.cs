using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Text : MonoBehaviour
{
    public TextMeshPro message;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Display("You need a key to open the door"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Display(string text){
        for(int i = 0; i < text.Length; i++){
            message.text += text[i];
            yield return new WaitForSeconds(0.01f);
        }
    }
}

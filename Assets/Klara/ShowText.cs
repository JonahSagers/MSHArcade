using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowText : MonoBehaviour
{
    public TextMeshPro message;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Display(string text){
        for(int i = 0; i < text.Length; i++)
        {
            message.text += text[i];
            yield return new WaitForSeconds(0.1f);
        }
    }
}

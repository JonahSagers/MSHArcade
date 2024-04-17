using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) 
        {
            if(col.tag == ("Player"))
            {
                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("VictoryScene");
            }
            
        }
}

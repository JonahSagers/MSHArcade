using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.gameObject.GetComponent<Move>().gameOver == false){
            transform.position = player.position / 1.1f;
        }
    }
}

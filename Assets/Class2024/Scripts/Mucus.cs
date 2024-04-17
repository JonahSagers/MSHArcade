using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]


public class Mucus : MonoBehaviour
{
    public Move move;

    void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.layer == 7) {
            move.inMucus = 1;
        }
    }
    void OnTriggerExit2D (Collider2D other){
        if (other.gameObject.layer == 7) {
            move.inMucus = 0;
        }   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject Item;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ItemSpawn());
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator ItemSpawn(){
        while(true){
        Instantiate(Item, transform.position + new Vector3(Random.Range(-75, 50), Random.Range(-75, 50), 0), transform.rotation, null);
        yield return new WaitForSeconds(5);
    }
    }

}

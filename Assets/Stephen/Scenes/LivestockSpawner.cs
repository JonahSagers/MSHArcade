using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivestockSpawner : MonoBehaviour
{
    public GameObject Livestock;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LivestockSpawn());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator LivestockSpawn(){
        while(true){
            Instantiate(Livestock, transform.position + new Vector3(Random.Range(0,120),0,0), transform.rotation, null);
            // The first randomrange is for the x position and the second is for the y position. there is only zero for the z position because this is a 2d game
            yield return new WaitForSeconds(15);
        }
    }
}

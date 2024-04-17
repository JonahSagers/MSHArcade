using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public GameObject AmmoBox;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AmmoSpawn());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator AmmoSpawn(){
        while(true){
            Instantiate(AmmoBox, transform.position + new Vector3(Random.Range(-100,200),50,0), transform.rotation, null);
            // The first randomrange is for the x position and the second is for the y position. there is only zero for the z position because this is a 2d game
            yield return new WaitForSeconds(20);
            }
        }
}

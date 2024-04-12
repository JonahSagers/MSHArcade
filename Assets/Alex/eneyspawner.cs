using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eneyspawner : MonoBehaviour
{
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.R)){
        Instantiate(Enemy, transform.position + new Vector3(Random.Range(-1,1),Random.Range(-1,1),0), transform.rotation, null);
       } 
    }
    // public IEnumerator EnemySpawn(){
    //     while(true){
    //         Instantiate(Enemy, transform.position + new Vector3(Random.Range(-1,1),Random.Range(-1,1),0), transform.rotation, null);
    //         yield return new WaitForSeconds(1);
    //     }
    // }
}

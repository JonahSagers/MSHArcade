using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.RightShift)){
        //     Instantiate(Enemy, transform.position + new Vector3(Random.Range(-5,20),Random.Range(-5,5),0), transform.rotation, null);
        //     // The first randomrange is for the x position and the second is for the y position. there is only zero for the z position because this is a 2d game
        // }
    }

    public IEnumerator EnemySpawn(){
        while(true){
            Instantiate(Enemy, transform.position + new Vector3(Random.Range(-100,100),0,0), transform.rotation, null);
            // The first randomrange is for the x position and the second is for the y position. there is only zero for the z position because this is a 2d game
            
            // need to make the enemies spawn in those exact coordinates and not offset
            yield return new WaitForSeconds(15);
        }
    }
}

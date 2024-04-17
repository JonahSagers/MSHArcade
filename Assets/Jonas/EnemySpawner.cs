// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class NewBehaviourScript : MonoBehaviour
// {
//     public GameObject enemy;
//     // Start is called before the first frame update
//     void Start()
//     {
//         StartCoroutine(enemyspawn(1));
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(Input.GetKeyDown(KeyCode.RightShift)){
//             Instantiate(enemy, transform.position + new Vector3(Random.Range(-1,1), Random.Range (-1,1),0), transform.rotation, null);
//         }

//     }
//     public IEnumerator enemyspawn(float cooldown){
//         while(true){
//              Instantiate(enemy, transform.position + new Vector3(Random.Range(-1,1), Random.Range (-1,1),0), transform.rotation, null);
//              yield return new WaitForSeconds(cooldown);
//         }
//     }


// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
   void Start()
   {
        StartCoroutine(NextScene());
   }

   void update()
   {

   }

   IEnumerator NextScene()
   {
    yield return new WaitForSeconds(19.3f);
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
}

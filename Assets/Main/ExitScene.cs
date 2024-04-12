using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ExitScene : MonoBehaviour
{
    public int quit;
    public TextMeshProUGUI text;
    public SpriteRenderer blackOut;
    // Start is called before the first frame update
    void Start()
    {
        text.color = new Color32(255,255,255,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            quit += 1;
            StartCoroutine(QuitCooldown());
        }
        if(quit >= 2){
            StartCoroutine(LoadScene());
            quit = -9999;
        }
    }

    IEnumerator QuitCooldown()
    {
        text.color = new Color32(255,255,255,255);
        yield return new WaitForSeconds(0.5f);
        float i = 0;
        while(i < 1){
            text.color = Color.Lerp(new Color32(255,255,255,255), new Color32(255,255,255,0), i);
            i += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
        text.color = new Color32(255,255,255,0);
        quit -= 1;
    }

    public IEnumerator LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Home");
        asyncLoad.allowSceneActivation = false;
        StartCoroutine(BlackOut());
        yield return new WaitForSeconds(2);
        asyncLoad.allowSceneActivation = true;
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public IEnumerator BlackOut()
    {
        while(blackOut.color.a < 1){
            blackOut.color += new Color(0, 0, 0, 1f * Time.deltaTime);
            yield return 0;
        }
    }
}

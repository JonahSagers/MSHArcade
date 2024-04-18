using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialBox : MonoBehaviour
{
    public bool triggered;
    public bool activated;
    public Animator anim;
    public bool hovered;
    public string targetScene;
    public SpriteRenderer blackOut;
    public SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activated && Input.GetMouseButtonDown(0)){
            if(hovered){
                Debug.Log("Game Start");
            } else {
                activated = false;
                anim.Play("Disappear");
            }
        }
        if(activated && Input.GetKeyDown(KeyCode.Escape)){
            activated = false;
            anim.Play("Disappear");
        }
        if(!hovered && !Input.GetMouseButton(0)){
            transform.localScale += new Vector3((1f-transform.localScale.x)/10,(1f-transform.localScale.y)/10,0);
        }
    }
    void OnMouseEnter()
    {
        hovered = true;
    }
    void OnMouseExit()
    {
        hovered = false;
    }
    void OnMouseOver()
    {
        if(Input.GetMouseButton(0)){
            transform.localScale += new Vector3((0.9f-transform.localScale.x)/10,(0.9f-transform.localScale.y)/10,0);
        } else {
            transform.localScale += new Vector3((1f-transform.localScale.x)/10,(1f-transform.localScale.y)/10,0);
        }
        if(Input.GetMouseButtonUp(0) && activated == true){
            StartCoroutine(LoadScene());
            activated = false;
            anim.Play("Disappear");
        }
    }

    public IEnumerator Appear(string target, Sprite image)
    {
        if(!activated){
            targetScene = target;
            render.sprite = image;
            anim.Play("Appear");
            yield return new WaitForSeconds(0.2f);
            activated = true;
        }
        yield return 0;
    }
    public IEnumerator LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetScene);
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

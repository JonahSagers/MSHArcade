using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class InnocentCell : MonoBehaviour
{
    public Move playerMove;
    public float red;
    public SpriteRenderer render;
    public bool infected;
    public VideoPlayer video;
    // Start is called before the first frame update
    void Start()
    {
        video = GameObject.Find("Video Player").GetComponent<VideoPlayer>();
        playerMove = GameObject.Find("Virus").GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.layer == 7 && playerMove.weakened == false){
            if(infected == false){
                StartCoroutine(Infected());
            }
        }
    }
    IEnumerator Infected()
    {
        StartCoroutine(PlayVideo());
        infected = true;
        red = 0;
        while(red < 1){
            red += 0.02f;
            render.color = new Color(1,1 - red,1 - red);
            yield return new WaitForSeconds(0.02f);
        }
        //playerMove.swarmCount *= 2;
        //transform.GetChild(0).GetComponent<DelayedDelete>().StartCoroutine(transform.GetChild(0).GetComponent<DelayedDelete>().Countdown(3));
        //Destroy(gameObject);
    }
    IEnumerator PlayVideo()
    {
        while(Time.timeScale > 0.1f){
            Time.timeScale /= 1.1f;
            yield return new WaitForSecondsRealtime(0.05f);
        }
        Time.timeScale = 0;
        video.targetCameraAlpha = 0;
        video.Play();
        while(video.targetCameraAlpha < 1f){
            //video.targetCameraAlpha += (1 - video.targetCameraAlpha)/10;
            video.targetCameraAlpha += 0.01f;
            yield return new WaitForSecondsRealtime(0.02f);
        }
        yield return new WaitForSecondsRealtime(3f);
        while(video.targetCameraAlpha > 0f){
            //video.targetCameraAlpha += (1 - video.targetCameraAlpha)/10;
            video.targetCameraAlpha -= 0.02f;
            yield return new WaitForSecondsRealtime(0.02f);
        }
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
        video.gameObject.transform.parent.GetChild(0).gameObject.GetComponent<Animator>().Play("ScreenShake");
        transform.GetChild(0).GetComponent<DelayedDelete>().StartCoroutine(transform.GetChild(0).GetComponent<DelayedDelete>().Countdown(10f));
        playerMove.swarmCount *= 8;
        while(transform.localScale.x > 0){
            transform.localScale /= 1.05f;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        Destroy(gameObject);
    }
    /*IEnumerator CameraShake(int amount){
        
    }*/
}

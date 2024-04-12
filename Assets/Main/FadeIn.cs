using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public SpriteRenderer blackOut;
    public float delay;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        while(blackOut.color.a > 0){
            blackOut.color -= new Color(0, 0, 0, 1f * Time.deltaTime);
            yield return 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

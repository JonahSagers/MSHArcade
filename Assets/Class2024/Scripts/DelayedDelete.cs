using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDelete : MonoBehaviour
{
    public ParticleSystem particles;
    public bool isPrime;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    public IEnumerator Countdown(float duration)
    {
        transform.parent = null;
        if(particles != null){
            if(isPrime){
                var particlesMain = particles.main;
                particlesMain.maxParticles = GameObject.Find("Virus").GetComponent<Move>().swarmCount;
            }
            particles.Play();
        }
        yield return new WaitForSeconds(duration);
        
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDelete : MonoBehaviour
{
    public ParticleSystem particles;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    public IEnumerator Countdown(float duration)
    {
        
        transform.parent = null;
        if(particles != null){
            if(gameObject.name == "Outbreak Particles"){
                var particlesMain = particles.main;
                particlesMain.maxParticles = GameObject.Find("Virus").GetComponent<Move>().swarmCount;
            }
            particles.Play();
        }
        yield return new WaitForSeconds(duration);
        
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeleteAfter1 : MonoBehaviour
{
    // Start is called before the first frame update
    public int Delete;
    void Start()
    {
        Delete=10;
    }

    // Update is called once per frame
    void Update()
    {
        if(Delete==0){
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        Delete-=1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPage : MonoBehaviour
{
    public bool inverse;
    public int page;
    public int maxPage;
    public List<MainInteract> buttons;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FlipPage());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        StartCoroutine(FlipPage());
    }

    public IEnumerator FlipPage()
    {
        page += 1;
        if(page > maxPage){
            page = 0;
        }
        buttons.Clear();
        foreach(GameObject button in GameObject.FindGameObjectsWithTag("MenuItem")){
            buttons.Add(button.GetComponent<MainInteract>());
        }
        foreach(MainInteract button in buttons){
            if(button.page == page){
                button.StartCoroutine(button.Appear());
            } else {
                button.StartCoroutine(button.Disappear());
            }
        }
        yield return 0;
    }
}

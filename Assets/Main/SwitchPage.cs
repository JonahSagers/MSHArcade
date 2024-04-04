using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPage : MonoBehaviour
{
    public bool inverse;
    public int page;
    public int maxPage;
    public List<Animator> buttons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        StartCoroutine(NextPage());
    }

    public IEnumerator FlipPage()
    {
        page += 1;
        if(page < maxPage){
            for(int i = 0; i < 6; i++)
            {
                buttons[i+(page-1)].Play("LeftOut");
                buttons[(i+(page))].Play("LeftIn");
            }
        } else {
            page = 0;
            for(int i = 0; i < 6; i++)
            {
                buttons[i].Play("LeftOut");
                buttons[(i+(page))].Play("LeftIn");
            }
        }
        yield return 0;
    }






    public IEnumerator NextPage()
    {
        if(page >= maxPage){
            for(int i = 0; i < 6; i++)
            {
                buttons[page].Play("LeftOut");
                buttons[0].Play("LeftIn");
            }
            page = 0;
        } else {
            page += 1;
            for(int i = 0; i < 6; i++)
            {
                buttons[page].Play("LeftOut");
                buttons[page+1].Play("LeftIn");
            }
        }
        yield return 0;
    }
    public IEnumerator LastPage()
    {
        yield return 0;
    }
}

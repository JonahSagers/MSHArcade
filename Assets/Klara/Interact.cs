using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Interact : MonoBehaviour
{
    public List<string> dialogue;
    public TextMeshPro message;
    public GameObject Child;
    public bool istriggered;
    public bool isnear;
    // public int child_near_player = GameObject.Find("Player").GetComponent<PlayerMovement>().nearby.IndexOf(Child);
    public IEnumerator Display(string text){
        message.text = "";
        for(int i = 0; i < text.Length; i++)
        {
            message.text += text[i];
            yield return new WaitForSeconds(0.1f);
        }
    }
    public int child_dialogue = 0;
    // Dialogue:
    // 0: asks player for help
    // 1: says she wishes she could walk in the woods (to hint to player that woods are nice and they should go there)
    // 2: no dialogue, she's not in this scene
    // 3: keeps saying that she doesn't see them at each visited location
    // 4: says she's hungry and is excited when fed, then suggests player searches shed and woods
    // 5: hopes you hurry since she's hungry
    // 6: says parents said they were going there and they may be behind the walk
    // 7: says parents walk in woods a lot so they may be in here once they answer fox
    // 8: says that they should check shed since they didn't find parents in woods
    // 9: says they should check woods since they weren't in shed
    // 10: says they should just go back to town where they started
    public int story_point = 0;
    // Story Point Definitions:
    // 0: player must make choice to help child, either from game opening or after saying no
    // 1: player said no to child and sequence with fox is going
    // 2: player has gone bankrupt from fox and bad ending is triggered
    // 3: player said yes, is walking around town, and will get to feeding child
    // 4: player is feeding child and can afford it
    // 5: player is doing dishes for money to feed child
    // 6: player is doing shed puzzle without having done woods puzzle
    // 7: player is doing woods puzzle without having done shed puzzle
    // 8: player is doing shed puzzle having done woods puzzle
    // 9: player is doing woods puzzle having done shed puzzle
    // 10: both puzzles have been solved and the game ends when you talk to child's parents

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J) && Input.GetKeyDown(KeyCode.K)){
            story_point = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(Input.GetKeyDown(KeyCode.F) && istriggered == false && isnear == true){
            StartCoroutine(Dialogue());
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 8){
            collider.gameObject.GetComponent<PlayerMovement>().nearby.Add(gameObject);
        }
        isnear = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 8){
            collider.gameObject.GetComponent<PlayerMovement>().nearby.Remove(gameObject);
        }
        isnear = false;
    }
    
    public IEnumerator Activate(){
        message.text = "";
        foreach(string line in dialogue){
            for(int i = 0; i < line.Length; i++)
            {
                message.text += line[i];
                yield return new WaitForSeconds(0.1f);
            }
        }
            yield return 0;
    }
    public IEnumerator Dialogue(){
        Debug.Log("Hello");
        // need to tell it that the player needs to be near the NPC and pressing f for it to talk
    
        // different dialogue for each situation and what happens when you answer
        istriggered = true;
        if(child_dialogue == 0){
            StartCoroutine(Display("Child: Um... excuse me... can you help me find my parents...? (1: yes, 2: no)"));
            while(story_point == 0){
                if(Input.GetKey(KeyCode.Alpha1)){
                    story_point = 3;
                    child_dialogue = 3;
                }
                if(Input.GetKey(KeyCode.Alpha2)){
                    story_point = 1;
                    child_dialogue = 1;
                }
                yield return 0;
            }
        }
        if(child_dialogue == 1){
            StartCoroutine(Display("Child: Hmm... the woods are really nice today... I wish more people went there and appreciated them..."));
            
        }
        if(child_dialogue == 2){
            
        }
        if(child_dialogue == 3){
            StartCoroutine(Display("Child: I guess we should walk around town to look for them... but I'm hungry, we need to get food after..."));
            
        }
        if(child_dialogue == 4){
            StartCoroutine(Display("Child: Yay, thank you for the food! As for where we should look... my parents said they were going to the shed... but they walk in the woods a lot too... where should we check? (1: shed, 2: woods)"));
            while(story_point == 4)
            {
                if(Input.GetKey(KeyCode.Alpha1)){
                    story_point = 6;
                    child_dialogue = 6;
                }
                if(Input.GetKey(KeyCode.Alpha2)){
                    story_point = 7;
                    child_dialogue = 7;
                }
                yield return 0;
            }
        }
        if(child_dialogue == 5){
            StartCoroutine(Display("Child: Thank you for making money to feed me... *stomach growls* I'm super hungry..."));
            
        }
        if(child_dialogue == 6){
            StartCoroutine(Display("Child: Hmm... how will we get in the shed..."));
            
        }
        if(child_dialogue == 7){
            StartCoroutine(Display("Child: The fox in the woods makes such weird noises... I wonder what he's saying..."));
            
        }
        if(child_dialogue == 8){
            StartCoroutine(Display("Child: I guess they weren't in the woods... hopefully they're in the shed..."));
            
        }
        if(child_dialogue == 9){
            StartCoroutine(Display("Child: That was a scary shed... I hope we find them in the woods..."));
            
        }
        if(child_dialogue == 10){
            StartCoroutine(Display("Child: I don't know what to do anymore... maybe we should go back through the town..."));
            
        }
    }
}

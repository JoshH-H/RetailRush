using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public NPC npc;

    bool isTalking = false;
    float distance;
    float currentResponseTrack = 0;

    public GameObject player;
    public GameObject dialogueUI;

    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;

   


    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive (false);

    }

    void OnMouseOver() //Experiment with collision enter for main
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 2.5f)
        {
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentResponseTrack++;

                if(currentResponseTrack>=npc.playerDialogue.Length - 1)
                {
                    currentResponseTrack = npc.playerDialogue.Length - 1;
                }
            }
            else if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentResponseTrack--;
                if(currentResponseTrack < 0)
                {
                    currentResponseTrack = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.E)&&isTalking == false)
            {
                StartConversation();

            }
            else if(Input.GetKeyDown(KeyCode.E)&&isTalking == true)
            {
                EndDialogue();
            }

            if(currentResponseTrack == 0 && npc.playerDialogue.Length >= 0)
            {
                playerResponse.text = npc.playerDialogue[0];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogueBox.text = npc.dialogue[1];
                }
            }
            else if(currentResponseTrack == 1 && npc.playerDialogue.Length >= 1)
            {
                playerResponse.text = npc.playerDialogue[1];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogueBox.text = npc.dialogue[2];
                }
            }
            else if (currentResponseTrack == 2 && npc.playerDialogue.Length >= 2)
            {
                playerResponse.text = npc.playerDialogue[2];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogueBox.text = npc.dialogue[3];
                }
            }
        }
    }

    void StartConversation()
    {
        isTalking = true;
        currentResponseTrack = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        npcDialogueBox.text = npc.dialogue[0];
    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
    }
}

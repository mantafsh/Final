using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using Unity.VisualScripting;

public class NPC : MonoBehaviour
{
    //npc conversation -- assigned in the inspector
    private GameObject npc;
    public NPCConversation conversation;
    public bool playerInBounds;
    public bool convoActive;
    // Start is called before the first frame update
    private void Start()
    {
        playerInBounds = false;
        convoActive = false;
        npc = GetComponent<GameObject>();
    }
    private void Update()
    {
        //start conversation if the player is inside the trigger area and e is pressed
        if (playerInBounds && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("DialogueCalled");
            convoActive = true;
            ConvoStart();

        }
        if (!playerInBounds && convoActive) 
        {
            ConvoEnd();
            convoActive=false;
        }
        //ConversationManager.OnConversationEnded += ConvoDisabled;
    }
   
    private void ConvoStart() 
    {
        ConversationManager.Instance.StartConversation(conversation); 
    }
    private void ConvoEnd() 
    {
        ConversationManager.Instance.EndConversation();
    }
    //private void ConvoDisabled() 
    //{ 
    //    Destroy(gameObject.GetComponent<SphereCollider>());
    //}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("Player here"); 
            playerInBounds = true;
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) 
        {
            playerInBounds = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteClick : MonoBehaviour
{
    GameObject triggerLine;
    public bool noteInbounds;
    public bool noteClicked;
    // Start is called before the first frame update
    void Start()
    {
        triggerLine = GetComponent<GameObject>();
    }

    private void Update()
    {
        //check if the notes is tapped
        if (noteInbounds && Input.GetKeyDown(KeyCode.Space)) 
        {
            noteClicked = true;
            Debug.Log("Clicked");
        }
        if(noteClicked && Input.GetKeyUp(KeyCode.Space)) 
        { 
            noteClicked = false;    
            Debug.Log("Released");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //check if teh note is within the bounds of the trigger
        if (other.CompareTag("Note"))
        {
            noteInbounds = true;
            //Debug.Log("Note In");
        }
    }
    private void OnTriggerExit(Collider other) 
    { 
        //check if the note has left the bounds
        if (other.CompareTag("Note")) 
        {
            noteInbounds = false;          
        }
        
    }
}

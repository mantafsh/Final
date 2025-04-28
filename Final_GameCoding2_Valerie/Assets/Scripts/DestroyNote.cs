using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyNote : MonoBehaviour
{
    GameObject note;
    public bool noteInBounds;
    public bool noteClicked;
    
    // Start is called before the first frame update
    void Start()
    {
        note = GetComponent<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if the notes is tapped
        if (noteInBounds && Input.GetKeyDown(KeyCode.Space))
        {
            noteClicked = true;
            
            Debug.Log("Clicked");
        }
        if (noteClicked && Input.GetKeyUp(KeyCode.Space))
        {
            //if note was tapped, destroy it
            noteClicked = false;
            Destroy(gameObject);
            ComboCounter.ComboUpdate();
            //register to combo
            Debug.Log("Released");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //check if teh note is within the bounds of the trigger
        if (other.CompareTag("TriggerLine"))
        {
            noteInBounds = true;
            //Debug.Log("Note In");
        }

        //if the note is too far, destroy it

        if (other.CompareTag("Out")) 
        { 
            Destroy(gameObject);
            ComboCounter.ResetCombo();
            //reset combo
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //check if the note has left the bounds
        if (other.CompareTag("TriggerLine"))
        {
            noteInBounds = false;
        }

    }

    
}


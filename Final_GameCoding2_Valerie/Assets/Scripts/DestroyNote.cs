using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyNote : MonoBehaviour
{
    GameObject note;
    public bool noteInBounds;
    public bool noteClicked;
    //sprites
    //SpriteRenderer idle;
    //SpriteRenderer failure;
    //SpriteRenderer success;
    
    
    // Start is called before the first frame update
    void Start()
    {
        note = GetComponent<GameObject>();
        //idle = GameObject.FindGameObjectWithTag("Idle").GetComponent<SpriteRenderer>();
        //failure = GameObject.FindGameObjectWithTag("Failure").GetComponent<SpriteRenderer>();
        //success = GameObject.FindGameObjectWithTag("Success").GetComponent<SpriteRenderer>();
        //idle.enabled = true;
        //failure.enabled = false;
        //success.enabled = false;
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
            //failure.enabled = false;
            //idle.enabled = false;
            //success.enabled = true;
            //StartCoroutine(Wait());
            ComboCounter.ComboUpdate();
            Destroy(gameObject);
            //switch sprites

            // success.enabled = false;
            // idle.enabled = true;
            Debug.Log("Changed");


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

            //success.enabled = false;
            //idle.enabled = false;
            //failure.enabled = true;
            //StartCoroutine(Wait());
            ComboCounter.ResetCombo();
            Destroy(gameObject);
            //switch sprites

            Debug.Log("Changed");
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
    //IEnumerator Wait() 
    //{
    //    yield return new WaitForSeconds(.1f);
    //    failure.enabled = false;
    //    idle.enabled = idle;
    //    success.enabled = false;
    //    Destroy(gameObject);


    //}

    
}


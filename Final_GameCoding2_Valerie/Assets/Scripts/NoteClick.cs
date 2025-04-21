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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Note"))
        { 
            noteInbounds = true;
        }
        if (noteInbounds = true && Input.GetMouseButtonDown(0)) 
        { 
            noteClicked = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
    private GameObject interactableThing;
    private bool IsInteractable = false;
    public UnityEvent OnInteract;
    // Start is called before the first frame update
    private void Start()
    {
        interactableThing = GetComponent<GameObject>();
    }
    private void Update()
    {
        if (IsInteractable && Input.GetKeyDown(KeyCode.E))
        {
            Interaction();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if(other.CompareTag("Player") )
        {
            IsInteractable = true;
            
        }

    }

    private void Interaction() 
    { 
        OnInteract.Invoke();
    }
}

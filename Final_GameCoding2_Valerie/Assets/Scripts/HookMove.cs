using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMove : MonoBehaviour
{
    //this scripts is self explanatory i think
    private GameObject hook;
    // Start is called before the first frame update
    void Start()
    {
        hook = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            transform.position = new Vector3(-44.4f, -45.1f, 90.2f);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = new Vector3(-44.4f, -25f, 90.2f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;

public class NoteScroller : MonoBehaviour
{
    public float noteSpeed;
    public bool hasStarted;
    // Start is called before the first frame update
    void Start()
    {
        noteSpeed = Conductor.bpm / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
            }
        }
        else 
        {
            transform.position -= new Vector3(noteSpeed * Time.deltaTime, 0, 0); 
        }
    }
}

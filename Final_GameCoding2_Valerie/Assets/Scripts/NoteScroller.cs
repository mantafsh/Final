using System.Collections;
using System.Collections.Generic;
//using UnityEditor.TerrainTools;
using UnityEngine;

public class NoteScroller : MonoBehaviour
{
    public float noteSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        noteSpeed = Conductor.bpm * Conductor.secPerBeat;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= new Vector3(noteSpeed * Time.deltaTime, 0, 0);
        
    }
    
}

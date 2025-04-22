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
        noteSpeed = Conductor.bpm * Conductor.secPerBeat;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(noteSpeed * Time.deltaTime, 0, 0);
        hasStarted = true;
    }
    
}

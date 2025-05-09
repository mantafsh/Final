using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Conductor : MonoBehaviour
{
    //bpm of the song
    public static int bpm = 114;
    //beats per second, to know how long each beat (basic note) last
    public static float secPerBeat;
    //current SONG POSITION in seconds
    public float songPosSec;
    //song position in beats
    public float songPosBeat;
    //how much of the song has passed, in seconds
    public float dspSongTime;
    //the audio source -- what actually emits the song
    public AudioSource musicSource;
    //fadeout bool
    private bool musicFadeOutEnable = false;
    

    // Start is called before the first frame update
    void Awake()
    {
        //assign the music source in the empty game object
        musicSource = GetComponent<AudioSource>();
        //calculate the number of seconds in each beat
        secPerBeat = 60f / bpm;
        //record the time when the song starts
        dspSongTime = (float)AudioSettings.dspTime;
        //Start the music
        musicSource.Play();
        musicSource.volume = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        //how many seconds since the song started
        songPosSec = (float)(AudioSettings.dspTime -  dspSongTime); 
        //how many beats since the song started
        songPosBeat = songPosSec / secPerBeat;
        //note that the beats normally go 1-2-3-4; but here it is 0-1-2-3 -- the third beat will be equal to 2.0, not 3.0

        //testing out note spawning to the beat 
        //if (songPosBeat == 2f) 
        //{ 
        //   Vector3 notePos = new Vector3(1f, 1f, 1f);
        //   notePrefab = Instantiate(notePrefab, notePos, Quaternion.identity);
        //    Debug.Log("note appeared");
        //}
        if(songPosSec == 71.95728f) 
        {
            SceneManager.LoadScene(2);
        }
    }
}

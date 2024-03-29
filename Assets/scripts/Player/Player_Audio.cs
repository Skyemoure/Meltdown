using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Audio : MonoBehaviour
{
    AudioSource a_Source;
    Animator anim;

    //Play the music
    bool Play;
    //Detect when you use the toggle, ensures music isn’t played multiple times
    bool Change;

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        a_Source = GetComponent<AudioSource>();
        //Ensure the toggle is set to true for the music to play at start-up
        Play = false;

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Play && Change) 
        {
            a_Source.Play();
            Change = false;
        }

        if (!Play && Change)
        { 
            a_Source.Stop();
            Change = false;
        }
    }
}

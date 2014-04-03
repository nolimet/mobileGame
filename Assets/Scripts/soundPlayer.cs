using UnityEngine;
using System.Collections;

public class soundPlayer : MonoBehaviour {

    bool playing = false;
    AudioSource sound;
    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.mute = true;
    }
    public void Play()
    {
        playing = true;
        sound.mute = false;
    }

    public void Stop()
    {
        if (sound.isPlaying)
        {
            sound.mute = true;
        }
    }
}

using UnityEngine;
using System.Collections;

public class soundPlayer : MonoBehaviour {

    bool playing = false;
    AudioSource sound;
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    public void Play()
    {
        sound.Play();
    }

    public void Stop()
    {
        if (sound.isPlaying)
        {
            sound.Stop();
        }
    }
}

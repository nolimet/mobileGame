using UnityEngine;
using System.Collections;

public class AudioControler : MonoBehaviour {

    private Managers.AudioManager AudioManager;
    public Player.PlayerControler parentControler;
    public AudioClip walkSound;
    public AudioClip jumpSound;
    public AudioClip idleSound;
    public AudioClip dieSound;

	// Use this for initialization
	void Start () {
        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            if (go.name == GlobalStatics.audioManager)
            {
                AudioManager = go.GetComponent<Managers.AudioManager>();
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!AudioManager.FSXIsMuted)
        {
            if (parentControler.RightButton.state || parentControler.LeftButton.state)
            {
                playSound(walkSound);
            }
            if (parentControler.rigidbody2D.velocity.x == 0f && parentControler.rigidbody2D.velocity.y==0f)
            {

            }
        }
	}

    void playSound(AudioClip sound)
    {
        audio.PlayOneShot(sound);
    }
}

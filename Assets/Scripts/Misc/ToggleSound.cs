using UnityEngine;
using System.Collections;

public class ToggleSound : MonoBehaviour {

    public Sprite[] faces;
    private Managers.AudioManager AudioManager;
    private SpriteRenderer sprenderer;

    void Start()
    {
        sprenderer = GetComponent<SpriteRenderer>();
        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            if (go.name == GlobalStatics.audioManager)
            {
                AudioManager = go.GetComponent<Managers.AudioManager>();
            }
        }
        if (AudioManager.FSXIsMuted)
        {
            sprenderer.sprite = faces[1];
        }
    }

    public void IWillDo()
    {
        AudioManager.ToggleFSX();
        if (AudioManager.FSXIsMuted)
        {
            sprenderer.sprite = faces[1];
        }
        else
        {
            sprenderer.sprite = faces[0];
        }
    }
}

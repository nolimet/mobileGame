using UnityEngine;
using System.Collections;

public class ToggleSound : MonoBehaviour {

    public Sprite[] faces;
    private Managers.AudioManager AudioManager;

    void Start()
    {
        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            if (go.name == GlobalStatics.audioManager)
            {
                AudioManager = go.GetComponent<Managers.AudioManager>();
            }
        }
    }

    public void IWillDo()
    {
        AudioManager.ToggleFSX();
    }
}

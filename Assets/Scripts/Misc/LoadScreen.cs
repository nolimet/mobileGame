using UnityEngine;
using System.Collections;

public class LoadScreen : MonoBehaviour {

    GUIText textgui;
    float count = 0;
	// Use this for initialization
	void Start () {
       Application.LoadLevel(GlobalStatics.levelToLoad);
        textgui = GetComponent<GUIText>();
	}

    void Update()
    {
        if (count > 1)
        {
            textgui.text = "Loading Level . . .";
            count = 0;
        }
        else if (count > 0.75)
        {
            textgui.text = "Loading Level . .";
        }
        else if (count > 0.5)
        {
            textgui.text = "Loading Level .";
        }
        else if (count > 0.25)
        {
            textgui.text = "Loading Level";
        }
        count += Time.deltaTime/2;
    }
}

using UnityEngine;
using System.Collections;

public class LoadScreen : MonoBehaviour {

    GUIText textgui;
    float count = 0;
   public
 float speed = 1;
	// Use this for initialization
    void Start()
    {
        textgui = GetComponent<GUIText>();
    }

    void Update()
    {
        if (count > speed * 1)
        {
            textgui.text = ". . . Loading Level . . .";
            count = 0;
        }
        else if (count > speed*0.75)
        {
            textgui.text = ". . Loading Level . .";
        }
        else if (count > speed * 0.5)
        {
            textgui.text = ". Loading Level .";
        }
        else if (count > speed * 0.25)
        {
            textgui.text = "Loading Level";
        }
        if (count > speed * 2)
        {
            Application.LoadLevel(GlobalStatics.levelToLoad);
        }
        count += Time.deltaTime/2;
    }
}

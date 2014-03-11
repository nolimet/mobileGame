using UnityEngine;
using System.Collections;

public class ChangeGuiText : MonoBehaviour {

    public void changeText(string newText)
    {
        guiText.text = newText;
    }
}

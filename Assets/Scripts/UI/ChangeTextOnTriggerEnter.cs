using UnityEngine;
using System.Collections;

public class ChangeTextOnTriggerEnter : MonoBehaviour {

    public ChangeGuiText GuiText;
    public string Text;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == TagManager.player)
        {
            GuiText.changeText(Text);
        }
    }
}

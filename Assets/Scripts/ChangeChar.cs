using UnityEngine;
using System.Collections;

public class ChangeChar : MonoBehaviour {

    public Button buttonUp;
    public Button buttonDown;
    public Sprite[] Characters;

    private SpriteRenderer spriteRender;

    void Start()
    {
        spriteRender=GetComponent<SpriteRenderer>();
        spriteRender.sprite = Characters[GlobalStatics.currentType];
    }
	// Update is called once per frame
	void Update () {
        if (buttonUp.state && GlobalStatics.currentType<Characters.Length-1)
        {
            buttonUp.state=false;
            GlobalStatics.currentType++;
            spriteRender.sprite = Characters[GlobalStatics.currentType];
        }
        if (buttonDown.state && GlobalStatics.currentType > 0)
        {
            GlobalStatics.currentType--;
            buttonDown.state = false;
            spriteRender.sprite = Characters[GlobalStatics.currentType];
        }
	}
}

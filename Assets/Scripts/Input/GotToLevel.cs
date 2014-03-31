using UnityEngine;
using System.Collections;

public class GotToLevel : MonoBehaviour {

    public int GoToLevel = -1;
    public bool Disabled = false;
    void Start()
    {
        if (Disabled||GoToLevel == -1)
        {
         //   Destroy(this.gameObject);
            SpriteRenderer spr = GetComponent<SpriteRenderer>();
            spr.color = Color.gray;
            Disabled = true;
        }
    }
    public void IWillDo()
    {
        if (!Disabled||GoToLevel != -1)
        {
            GlobalStatics.load(GoToLevel);
        }
    }
}

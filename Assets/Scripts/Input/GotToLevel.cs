using UnityEngine;
using System.Collections;

public class GotToLevel : MonoBehaviour {

    public int GoToLevel = -1;
    void Start()
    {
        if (GoToLevel == -1)
        {
         //   Destroy(this.gameObject);
            SpriteRenderer spr = GetComponent<SpriteRenderer>();
            spr.color = Color.gray;
        }
    }
    public void IWillDo()
    {
        if (GoToLevel != -1)
        {
            GlobalStatics.load(GoToLevel);
        }
    }
}

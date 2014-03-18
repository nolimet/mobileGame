using UnityEngine;
using System.Collections;

public class GotToLevel : MonoBehaviour {

    public int GoToLevel = -1;
    void Start()
    {
        if (GoToLevel == -1)
        {
            Destroy(this.gameObject);
        }
    }
    public void IWillDo()
    {
        GlobalStatics.load(GoToLevel);
    }
}

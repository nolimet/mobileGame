using UnityEngine;
using System.Collections;

public class TriggerV2 : MonoBehaviour {
    public int OpenMenuID;
    public bool Disabled;
    public bool State = false;
    public bool triggered = false;

    public void IWillDo()
    {
        if (Disabled)
        {
            State = true;
        }
    }
    void OnClick()
    {
        if (Disabled)
        {
            State = true;
        }
    }
}

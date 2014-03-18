using UnityEngine;
using System.Collections;

public class TriggerV2 : MonoBehaviour {
    public int OpenMenuID;
    public bool State = false;
    public bool triggered = false;

    public void IWillDo()
    {
        State = true;
    }
}

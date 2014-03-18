using UnityEngine;
using System.Collections;

public class TriggerV2 : MonoBehaviour {

    public bool State = false;
    public bool triggered = false;

    public void IWillDo()
    {
        State = true;
    }
    void LateUpdate()
    {
        if (triggered)
        {
            State = false;
            triggered = false;
        }
        
    }
}

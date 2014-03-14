using UnityEngine;
using System.Collections;

public class moveObjectOnTrigger : MonoBehaviour {

    public Trigger activator;
   // private float checkInterval;
   // public float addRot;
   // private float origen;
 
	
	// Update is called once per frame
	void Update () {
        if (activator.Actived)
        {
            collider2D.enabled = false;
        }
        else if (!activator.Actived)
        {
            collider2D.enabled = true;
        }
	}
}

﻿using UnityEngine;
using System.Collections;

public class ChangePhysicsOnTrigger : MonoBehaviour {

    public Trigger trigger;
    public bool onlyOnce;
    public bool changeMass;
    public float newMass;
   // private float checkInterval;
   // public float addRot;
   // private float origen;
 
	
	// Update is called once per frame
	void Update () {
        if (trigger.Actived)
        {
            if (changeMass)
            {
                rigidbody2D.mass = newMass;
            }
            rigidbody2D.isKinematic = false;
        }
        else if (!trigger.Actived&&!onlyOnce)
        {
            rigidbody2D.isKinematic = true;
        }
	}
}
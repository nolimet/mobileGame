﻿using UnityEngine;
using System.Collections;
namespace Movement
{
    public class GravityControler : MonoBehaviour
    {

        //private float Timeline = 0f;
       // private bool timelineDone;
        protected bool GraviSwitchEnabled = false;

        protected virtual void Start()
        {

        }

        public virtual void GraviSwitch()
        {
            if (GraviSwitchEnabled)
            {
                rigidbody2D.gravityScale = 1;
            }
            else
            {
                rigidbody2D.gravityScale = 0;
                //Timeline = 0;
                //timelineDone = false;
            }
            GraviSwitchEnabled = !GraviSwitchEnabled;
        }
        
        /* protected virtual void Update()
        {
            if (GraviSwitchEnabled)
            {
                if (!timelineDone && Timeline < 0.3f)
                {
                    rigidbody2D.AddForce(new Vector2(0, 10));
                }
                else if (!timelineDone && Timeline < 0.4f)
                {
                    rigidbody2D.velocity = Vector2.zero;
                }
                else if (!timelineDone)
                {
                    timelineDone = true;
                }
                Timeline += Time.deltaTime;
            }
        }*/
    }
}

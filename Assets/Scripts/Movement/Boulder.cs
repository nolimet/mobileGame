using UnityEngine;
using System.Collections;

namespace Movement
{
    public class Boulder : TouchMove
    {
        float mass = 0;
        protected override void Start()
        {
            base.Start();
            rigidbody2D.isKinematic = true;
            mass = rigidbody2D.mass;

        }
        public override void Select()
        {
            base.Select();
            if (Selected)
            {
                rigidbody2D.isKinematic = false;
                rigidbody2D.mass = 9;

            }
            else
            {
                rigidbody2D.isKinematic = true;
                rigidbody2D.mass = mass;
            }
        }
        public override void GraviSwitch()
        {
            base.GraviSwitch();
            Debug.Log("GraviSwitch: " + GraviSwitchEnabled);
            if (!GraviSwitchEnabled)
            {
                Sparkels.enableEmission = false;
                rigidbody2D.isKinematic = false;
            }
            else
            {
                Sparkels.enableEmission = true;
                rigidbody2D.isKinematic = true;
            }
        }

    }
}
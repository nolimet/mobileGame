using UnityEngine;
using System.Collections;
namespace Movement
{
    public class TouchMove : GravityControler
    {

        public bool Selected = false;
        public float speed = 0.1F;
        public ParticleSystem Sparkels;
        public void Select()
        {
            if (GlobalStatics.SelectedAObject == Selected)
            {
                Selected = !Selected;
                GlobalStatics.SelectedAObject = !GlobalStatics.SelectedAObject;
                Sparkels.enableEmission = !Selected;
                rigidbody2D.velocity = Vector2.zero;
                rigidbody2D.isKinematic = !rigidbody2D.isKinematic;
            }
            Debug.Log(Selected);
            Debug.Log(GlobalStatics.SelectedAObject);
        }


        public override void GraviSwitch()
        {
            base.GraviSwitch();
            Selected = false;
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.isKinematic = true;
            GlobalStatics.SelectedAObject = false;
            Sparkels.enableEmission = true;

        }

        void Update()
        {
            if (Selected)
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    rigidbody2D.AddForce(new Vector2(touchDeltaPosition.x * speed, touchDeltaPosition.y * speed));
                    //rigidbody2D.AddForce(new Vector2(0, touchDeltaPosition.y * speed));
                }
                if (Input.touchCount == 2)
                {
                    rigidbody2D.velocity = new Vector2();
                }
            }
        }
    }
}
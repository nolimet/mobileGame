using UnityEngine;
using System.Collections;

public class TouchMove : MonoBehaviour {

    public bool Selected=false;
    public float speed = 0.1F;
    public void Select()
    {
        Selected = !Selected;
        Debug.Log(Selected);
    }

    public void GraviSwitch()
    {
        Selected = false;
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

using UnityEngine;
using System.Collections;

public class TouchMove : MonoBehaviour {

    public float speed = 0.1F;
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            rigidbody2D.AddForce(new Vector2(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed));
        }
        if (Input.touchCount == 2)
        {
            rigidbody2D.velocity = new Vector2();
        }
    }
}

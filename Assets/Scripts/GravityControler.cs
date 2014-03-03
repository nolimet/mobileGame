using UnityEngine;
using System.Collections;

public class GravityControler : MonoBehaviour {

    private float Timeline = 0f;
    public bool GraviSwitchEnabled = false;
	// Use this for initialization
   public void GraviSwitch()
    {
        if (GraviSwitchEnabled)
        {
            rigidbody2D.gravityScale = 1;
        }
        else
        {
            rigidbody2D.gravityScale = 0;
            Timeline = 0;
        }
        GraviSwitchEnabled = !GraviSwitchEnabled;
    }
	
	// Update is called once per frame
	void Update () {
        if (GraviSwitchEnabled)
        {
            if (Timeline < 0.2f)
            {
                rigidbody2D.AddForce(new Vector2(0, 20));
                rigidbody2D.AddTorque(1f);
            }

            Timeline += Time.deltaTime;
        }
	}
}

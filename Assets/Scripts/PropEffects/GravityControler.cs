using UnityEngine;
using System.Collections;

public class GravityControler : MonoBehaviour {

    private float Timeline = 0f;
    private bool timelineDone;
    private bool GraviSwitchEnabled = false;

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
            timelineDone = false;
        }
        GraviSwitchEnabled = !GraviSwitchEnabled;
    }
	
	void Update () {
        if (GraviSwitchEnabled)
        {
            if (!timelineDone&&Timeline < 0.2f)
            {
                rigidbody2D.AddForce(new Vector2(0, 10));
            }
            else if (!timelineDone && Timeline < 0.3f)
            {
                rigidbody.velocity = Vector3.zero;
            }
            else if(!timelineDone)
            {
                timelineDone = true;
            }
            Timeline += Time.deltaTime;
        }
	}
}

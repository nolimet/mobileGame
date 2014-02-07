using UnityEngine;
using System.Collections;

public class MoveGUIObject : MonoBehaviour {

    private int lastFingerId;
    public Joystick movedObject;
    public int tapCount;	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount != 0)
        {
            int count = Input.touchCount;

            for(int i = 0;i < count; i++)
		{
			Touch touch = Input.GetTouch(i);			
			Vector2 guiTouchPos  = touch.position;
	
			// Latch the finger if this is a new touch
			if (( movedObject.released) && ( lastFingerId == -1 || lastFingerId != touch.fingerId ) )
			{
				lastFingerId = touch.fingerId;				
			}				
	
			if ( lastFingerId == touch.fingerId )
			{	
				// Override the tap count with what the iPhone SDK reports if it is greater
				// This is a workaround, since the iPhone SDK does not currently track taps
				// for multiple touches
				if ( touch.tapCount > tapCount )
					tapCount = touch.tapCount;
					
				// Change the location of the joystick graphic to match where the touch is
			    movedObject.guiCenter.x = guiTouchPos.x;
			    movedObject.guiCenter.y = guiTouchPos.y;
                movedObject.released = false;
				
				if ( touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled ){
                    movedObject.Reset();				
              }		
            }
        }
        }
	}
}

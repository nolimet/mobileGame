using UnityEngine;
using System.Collections;
namespace menu
{
    public class MoveGUIObject : MonoBehaviour
    {
        /*
            private int lastFingerId;
            //public Joystick movedObject;
            public int tapCount;	
            // Use this for initialization
            void Start () {
            }
	
            // Update is called once per frame
            void LateUpdate () {
                if (Input.touchCount != 0)
                {
                    int count = Input.touchCount;

                    for(int i = 0;i < count; i++)
                {
                    Touch touch = Input.GetTouch(i);			
                    Vector2 guiTouchPos  = touch.position;
                  //  Debug.Log(guiTouchPos);
	
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
                        if (!movedObject.released)
                        {
                            // Change the location of the joystick graphic to match where the touch is
                            movedObject.defaultRect.x = guiTouchPos.x;
                            movedObject.defaultRect.y = guiTouchPos.y;
                            movedObject.guiCenter.x = guiTouchPos.x ;//+ 50;
                            movedObject.guiCenter.y = guiTouchPos.y ;//+ 50;
                            // Debug.Log(guiTouchPos);
                            movedObject.released = true;
                        }
				
                        if ( touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled ){
                            movedObject.Reset();				
                      }		
                    }
                }
                }
            }
         * */
    }
}
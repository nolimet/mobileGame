using UnityEngine;
using System.Collections;

public class ButtonRestonrelease : MonoBehaviour
{
    //something old
    /* private GUITexture img;
     public bool state;
     // Use this for initialization
     void Start () {
         img = GetComponent<GUITexture>();
     }
	
     // Update is called once per frame
     void Update () {
         int touchCount = Input.touchCount;
         if (touchCount > 0)
         {
             Debug.Log(touchCount);
             for (int i = 0; i > touchCount; i++)
             {
               
                 if (img.HitTest(Input.GetTouch(i).position))
                 {
                     if (Input.GetTouch(i).phase == TouchPhase.Began)
                     {
                         state = true;
                     }
                    /* if (Input.GetTouch(i).phase == TouchPhase.Stationary)
                     {
                         print("Touch is on image");
                     }
                     if (Input.GetTouch(i).phase == TouchPhase.Moved)
                     {
                         print("Touch is moving on image");
                     }                   
     * if (Input.GetTouch(i).phase == TouchPhase.Ended)
                     {
                         state = false;
                     }
                 }
             }
         }
     }*/
    public bool state = false;
    void Start()
    {

    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {

                Touch touch = Input.GetTouch(i);

                if (touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position))
                {

                    state = true;

                }
            }
        }
        else
        {

            state = false;

        }
        //Debug.Log(state);
        if(Input.touchCount==0){
            state = false;
        }
    }
    void _OnTouchDown()
    {
        state = true;
    }

    void _OnTouchUp()
    {
        state = false;
    }
}

//WIP!
   /* private GUITexture img;
    public bool state;
	// Use this for initialization
	void Start () {
        img = GetComponent<GUITexture>();
	}
	
	// Update is called once per frame
	void Update () {
        int touchCount = Input.touchCount;
        if (touchCount > 0)
        {
            Debug.Log(touchCount);
            for (int i = 0; i > touchCount; i++)
            {
               
                if (img.HitTest(Input.GetTouch(i).position))
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        state = true;
                    }
                   /* if (Input.GetTouch(i).phase == TouchPhase.Stationary)
                    {
                        print("Touch is on image");
                    }
                    if (Input.GetTouch(i).phase == TouchPhase.Moved)
                    {
                        print("Touch is moving on image");
                    }                   
    * if (Input.GetTouch(i).phase == TouchPhase.Ended)
                    {
                        state = false;
                    }
                }
            }
        }
	}*/
    /*public bool state = false;
    private int TouchingID = -1;
    void  Start (){
     
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {

                Touch touch = Input.GetTouch(i);

                if (touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position) && TouchingID==-1)
                {

                    state = true;
                    TouchingID = i;

                }
                else if (i == TouchingID && !guiTexture.HitTest(touch.position))
                {
                    state = false;
                    TouchingID = -1;
                }
            }
        }
        else
        {
            if (Input.touchCount - 1 < TouchingID || Input.touchCount == 0)
            {
                //if( Input.touchCount>0&&TouchingID!=-1&&guiTexture.HitTest(Input.GetTouch(TouchingID).position)||Input.touchCount==0||Input.touchCount<=TouchingID)
                state = false;
                TouchingID = -1;
            }

        }
        
    }
    void _OnTouchDown()
    {
        state = true;
    }

    void _OnTouchUp()
    {
        state = false;
    }
}
    */
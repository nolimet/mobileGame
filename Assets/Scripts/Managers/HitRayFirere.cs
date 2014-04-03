using UnityEngine;
using System.Collections;

public class HitRayFirere : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = new RaycastHit2D();
        Touch touch;
        if (Application.platform == RuntimePlatform.Android)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
                {
                    touch = Input.GetTouch(i);
                    //Ray ray = SecondaryCamera.ViewportPointToRay(new Vector3(touch.position.x, touch.position.y, 0));
                    hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                    //Debug.Log("test");
                    //Debug.Log(hit.collider.name);
                    if (hit.collider != null)
                    {
                        //Debug.Log("STEVE!!");
                        hit.transform.gameObject.SendMessage("IWillDo", SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                //Debug.Log("test");
                //Debug.Log(hit.collider.name);
                if (hit.collider != null)
                {
                    //Debug.Log("STEVE!!");
                    hit.transform.gameObject.SendMessage("IWillDo", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
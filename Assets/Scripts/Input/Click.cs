using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {
    public int LoadLevel;
    public bool ExitGame;

    void Update()
    {
        // Code for OnMouseDown in the iPhone. Unquote to test.
        RaycastHit hit = new RaycastHit();
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, out hit))
                {
                    hit.transform.gameObject.SendMessage("OnMouseDown");
                }
            }
        }
    }
    void OnMouseDown()
    {
        if (ExitGame&&!Application.isWebPlayer&&!Application.isEditor)
        {
            Application.Quit();
        }
        Application.LoadLevel(LoadLevel);
        Debug.Log("clicked");
    }
}

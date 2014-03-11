using UnityEngine;
using System.Collections;

public class GraviManager : MonoBehaviour {

    public Button ButtonC;
    public GameObject Controles;
    public GameObject ButtonCG;

    private bool GraviSwitchEnabled = false;

    public void GraviSwitch()
    {
        GraviSwitchEnabled = !GraviSwitchEnabled;
        Controles.SetActive(!GraviSwitchEnabled);
        
    }
	// Update is called once per frame
    void Update()
    {
        if (GraviSwitchEnabled)
        {
            RaycastHit hit = new RaycastHit();
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                    if (Physics.Raycast(ray, out hit))
                    {
                        hit.transform.gameObject.SendMessage("Selected");
                    }
                }
            }
        }
    }
}

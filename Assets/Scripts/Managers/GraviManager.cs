using UnityEngine;
using System.Collections;

public class GraviManager : MonoBehaviour {

    public Button ButtonC;
    public GameObject Controles;
    public GameObject ButtonCG;
    public Camera MainCamera;
    public Camera SecondaryCamera;
    public BetaCharControler player;

    public bool GraviSwitchEnabled = false;
    void Start()
    {
        Controles.SetActive(!GraviSwitchEnabled);
        ButtonCG.SetActive(GraviSwitchEnabled);
        MainCamera.enabled = !GraviSwitchEnabled;
        SecondaryCamera.enabled = GraviSwitchEnabled;
        player.enabled = !GraviSwitchEnabled;
    }

    public void GraviSwitch()
    {
        GraviSwitchEnabled = !GraviSwitchEnabled;
        Controles.SetActive(!GraviSwitchEnabled);
        ButtonCG.SetActive(GraviSwitchEnabled);
        MainCamera.enabled = !GraviSwitchEnabled;
        SecondaryCamera.enabled = GraviSwitchEnabled;
        player.enabled = !GraviSwitchEnabled;
        //Debug.Log(GraviSwitchEnabled);
        
    }
	// Update is called once per frame
    void Update()
    {
        if (GraviSwitchEnabled)
        {
            if (ButtonC.state)
            {
                ButtonC.state = false;
                GlobalStatics.GraviChange();
            }
            RaycastHit hit = new RaycastHit();
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
                {
                    int l = Camera.allCameras.Length;
                    for (int j = 0; j > l; j++)
                    {
                        Ray ray = SecondaryCamera.ScreenPointToRay(Input.GetTouch(i).position);
                        if (Physics.Raycast(ray, out hit))
                        {
                            hit.transform.gameObject.SendMessage("Selected");
                        }
                    }
                }
            }
        }
    }
}

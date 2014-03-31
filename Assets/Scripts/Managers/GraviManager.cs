using UnityEngine;
using System.Collections;
using Player;

namespace Managers
{
    public class GraviManager : MonoBehaviour
    {

        public Button ButtonC;
        public GameObject Controles;
        public GameObject ButtonCG;
        public Camera MainCamera;
        public Camera SecondaryCamera;
        public PlayerControler player;

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
                RaycastHit2D hit = new RaycastHit2D();
                Touch touch;
                for (int i = 0; i < Input.touchCount; ++i)
                {
                    if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
                    {
                        touch = Input.GetTouch(i);
                        //Ray ray = SecondaryCamera.ViewportPointToRay(new Vector3(touch.position.x, touch.position.y, 0));
                        hit = Physics2D.Raycast(SecondaryCamera.ScreenToWorldPoint(touch.position), Vector2.zero);
                        //Debug.Log("test");
                        //Debug.Log(hit.collider.name);
                        if (hit.collider != null)
                        {
                            //Debug.Log("STEVE!!");
                            hit.transform.gameObject.SendMessage("Select", SendMessageOptions.DontRequireReceiver);
                        }
                    }
                }
            }
        }
    }
}

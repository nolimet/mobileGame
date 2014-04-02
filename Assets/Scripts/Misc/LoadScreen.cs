using UnityEngine;
using System.Collections;
namespace misc
{
    public class LoadScreen : MonoBehaviour
    {

        GUIText textgui;
        float count = 0f;
        float loadCount = 0f;
        public
      float speed = 1;
        // Use this for initialization
        void Start()
        {
            textgui = GetComponent<GUIText>();
        }

        void Update()
        {
            if (count > speed * 1)
            {
                textgui.text = ". . . Loading Level . . .";
                count = 0f;

            }
            else if (count > speed * 0.75)
            {
                textgui.text = ". . Loading Level . .";
            }
            else if (count > speed * 0.5)
            {
                textgui.text = ". Loading Level .";
                Application.LoadLevel(GlobalStatics.levelToLoad);
            }
            else if (count > speed * 0.25)
            {
                textgui.text = "Loading Level";

                
            }
            if (loadCount > speed * 2)
            {
                Application.LoadLevel(GlobalStatics.levelToLoad);
            }
            count += Time.deltaTime;
            loadCount += Time.deltaTime;
        }
    }
}

using UnityEngine;
using System.Collections;

public class OpenURL : MonoBehaviour
{

    public string url = "fb://page/459833187476932";
    public string Alt = "https://www.facebook.com/pages/The-Moonrabbit/459833187476932?ref=ts&fref=ts";

    void IWillDo()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Application.OpenURL(url);
            float timeAfter = Time.timeSinceLevelLoad;
            if (Time.timeSinceLevelLoad - timeAfter >= 1)
            {
                Application.OpenURL(Alt);
            }
        }
        else
        {
            Application.OpenURL(Alt);
        }
    }
}

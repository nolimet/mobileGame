using UnityEngine;
using System.Collections;

public class OpenURL : MonoBehaviour
{

    public string url = "fb://page/459833187476932";

    void IWillDo()
    {
        Application.OpenURL(url);
        float timeAfter = Time.timeSinceLevelLoad;
        if (Time.timeSinceLevelLoad - timeAfter >= 1)
        {

        }
    }

    /*void OpenFacebookPage()
    {
        ww
        WWW www = new WWW("fb://page/xxxxx");
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("Sucess!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error + " Opening Safari...");
            //error. Open normal address
            Application.OpenURL("http://www.facebook.com/xxxxxx");

        }
    }*/
}

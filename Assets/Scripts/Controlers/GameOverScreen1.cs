using UnityEngine;
using System.Collections;
public class GameOverScreen1 : MonoBehaviour {

    private float waitTime = 2F;

	void Update () {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0 || Input.touchCount>0)
        {
            GlobalStatics.loadedLevel = false;
            Application.LoadLevel(GlobalStatics.levelToLoad);
        }
	}
}
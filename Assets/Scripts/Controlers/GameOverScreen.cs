using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

    private float waitTime = 15;

	void Update () {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            Application.LoadLevel(GlobalStatics.levelToLoad);
        }
	}
}

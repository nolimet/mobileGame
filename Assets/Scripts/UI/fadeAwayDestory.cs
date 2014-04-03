using UnityEngine;
using System.Collections;

public class fadeAwayDestory : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        Color temp = new Color(1,1,1,guiTexture.color.a-Time.deltaTime / 25);
        guiTexture.color = temp;
        if (guiTexture.color.a <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}

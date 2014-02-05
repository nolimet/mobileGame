using UnityEngine;
using System.Collections;

public class BackToRoom : MonoBehaviour {

    public int LoadLevel;
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(LoadLevel);
        }
    }
}

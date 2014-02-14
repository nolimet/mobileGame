using UnityEngine;
using System.Collections;

public class GoToLevel : MonoBehaviour {

    public int goToLevel;
    public float WaitTime;

	// Use this for initialization
	void Start () {
        if (WaitTime <= 0)
        {
            Application.LoadLevel(goToLevel);
        }
	}
    void Update()
    {
        if (WaitTime <= 0)
        {
            Application.LoadLevel(goToLevel);
        }
        WaitTime -= Time.deltaTime;
    }
}

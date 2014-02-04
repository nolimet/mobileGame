using UnityEngine;
using System.Collections;

public class GoToLevel : MonoBehaviour {

    public int goToLevel;

	// Use this for initialization
	void Start () {
        Application.LoadLevel(goToLevel);
	}
}

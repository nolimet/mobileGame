using UnityEngine;
using System.Collections;

public class ArtControler : MonoBehaviour {

    public int typeIndex = 0;
    public GameObject parent;
	// Use this for initialization
	void Start () {
        if (GlobalStatics.currentType != typeIndex)
        {
            Destroy(this.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}

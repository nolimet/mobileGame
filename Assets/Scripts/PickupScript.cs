using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag==TagManager.player){
		Destroy(this.gameObject,0.5f);
		}
	}
}

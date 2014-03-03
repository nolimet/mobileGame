using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {
    private Vector2 origen;

	// Use this for initialization
	void Start () {
	    origen = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 temp;
        temp = origen;
        temp.y += Mathf.PingPong(Time.time/2, 0.5f) - 0.25f;
        transform.position = temp;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag==TagManager.player){
		Destroy(this.gameObject,0.5f);
		}
	}
}

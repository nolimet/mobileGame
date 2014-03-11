using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {
    public bool changeRoom;
    public int NextRoom;
    private bool loadNextRoom;
    private Vector2 origen;
    private float wait = 2F;
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

        if (loadNextRoom)
        {
            wait -= Time.deltaTime;
            if (wait < 0)
            {
                GlobalStatics.load(NextRoom);
            }
        }
	}

	void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == TagManager.player)
        {
            if (changeRoom)
            {
                loadNextRoom = true;
            }
            else
            {
                Destroy(this.gameObject, 0.5f);
            }
        }
	}
}

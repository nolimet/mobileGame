using UnityEngine;
using System.Collections;

public class ArtControler : MonoBehaviour {

    public int typeIndex = 0;
    private Animator ani;
    public GameObject parent;
	// Use this for initialization
	void Start () {
        if (GlobalStatics.currentType != typeIndex)
        {
            Destroy(this.gameObject);
            return;
        }
        ani = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (parent.rigidbody2D.velocity.x > 0)
        {
            Quaternion temprot = transform.rotation;

            temprot.y = 180;
            transform.rotation = temprot;
        }
        if (parent.rigidbody2D.velocity.x < 0)
        {
            Quaternion temprot = transform.rotation;

            temprot.y = 0;
            transform.rotation = temprot;
        }
        ///if(
	}
}

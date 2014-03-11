using UnityEngine;
using System.Collections;

public class ArtControler : MonoBehaviour {

    public int typeIndex = 0;
    private Animator ani;
   // public GameObject parent;
    public BetaCharControler parentControler;
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
        if (parentControler.rigidbody2D.velocity.x > 0.1f)
        {
            Quaternion temprot = transform.rotation;
            temprot.y = 180;
            transform.rotation = temprot;
        }
        if (parentControler.rigidbody2D.velocity.x < -0.1f)
        {
            Quaternion temprot = transform.rotation;

            temprot.y = 0;
            transform.rotation = temprot;
        }
        if (parentControler.anlogmove.x > 0.1f || parentControler.anlogmove.x < -0.1f)
        {
            ani.SetBool("walking", true);
        }
        else
        {
            ani.SetBool("walking", false);
        }
         ani.SetFloat("speed", parentControler.rigidbody2D.velocity.x);
         ani.SetBool("ground", parentControler.g);
         ani.SetBool("WalkJump", parentControler.ButtonB.state);
	}
}

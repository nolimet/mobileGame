using UnityEngine;
using System.Collections;

public class BetaCharControler : MonoBehaviour {

    //scriptlinks
    public Joystick AnologeStick;
    public Button ButtonA;
    public Button ButtonB;

    //others
    public PhysicsMaterial2D airPhyMat;
    private bool g = false;
    private PhysicsMaterial2D orPhyMat;
    private BoxCollider2D coll;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();;
        orPhyMat = coll.sharedMaterial;
    }
	// Update is called once per frame
	void Update () {
        Vector2 move = new Vector2();
        if(rigidbody2D.velocity.x < 20 && g)
        {
            move.x =  AnologeStick.position.x * 25;
            Debug.Log(AnologeStick.position);
        }
        if (ButtonB.state&&g)
        {
           // g = false;
            coll.sharedMaterial = airPhyMat;
            Debug.Log("jump");
            ButtonB.state = false;
            move.y = 500;
        }
        rigidbody2D.AddForce(move);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == TagManager.floor)
        {
            g = true;
            coll.sharedMaterial = orPhyMat;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == TagManager.floor)
        {
            g = false;
            coll.sharedMaterial = airPhyMat;
        }
    }
}

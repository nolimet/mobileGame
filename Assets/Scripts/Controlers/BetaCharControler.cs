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
    private bool isLight = true;
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();;
        orPhyMat = coll.sharedMaterial;
    }
	// Update is called once per frame
	void Update () {
        Vector2 move = new Vector2();
        Vector2 anlogmove = AnologeStick.position+new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        if (isLight)
        {
            if (rigidbody2D.velocity.x < 10 && rigidbody2D.velocity.x>-10)
            {
                if (g)
                {
                    move.x = anlogmove.x * 17;
                    // Debug.Log(AnologeStick.position);
                }
                else
                {
                    move.x = anlogmove.x * 2;
                }
            }
            if (ButtonB.state && g)
            {
                // g = false;
                coll.sharedMaterial = airPhyMat;
                ButtonB.state = false;
                move.y = 500;
            }
        }
        else
        {
            if (rigidbody2D.velocity.x < 2 && rigidbody2D.velocity.x>2)
            {
                if (g)
                {
                    move.x = anlogmove.x * 3;
                    // Debug.Log(AnologeStick.position);
                }
                else
                {
                    move.x = anlogmove.x * 2;
                }
            }
            if (ButtonB.state && g)
            {
                // g = false;
                coll.sharedMaterial = airPhyMat;
                ButtonB.state = false;
                move.y = 100;
            }
        }
        rigidbody2D.AddForce(move);
        Debug.Log(move);
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

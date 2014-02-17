using UnityEngine;
using System.Collections;

public class BetaCharControler : MonoBehaviour {

    //scriptlinks
    public Joystick AnologeStick;
    public Button ButtonA;
    public Button ButtonB;
	private GravityScript gravityScr;
	
    //others
    public PhysicsMaterial2D airPhyMat;
    public bool g = false;
    private PhysicsMaterial2D orPhyMat;
    private BoxCollider2D coll;
    private bool isLight = true;
	private float addGravity = 2f;
	//private bool flying = false;
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();;
        orPhyMat = coll.sharedMaterial;
		gravityScr = GetComponent<GravityScript>();
    }
	// Update is called once per frame
	void Update () 
	{
		if(ButtonA.state && GlobalStatics.gravityOff == false && g)
		{
			Vector3 fly = new Vector3(transform.position.x,transform.position.y + addGravity,transform.position.z);
			transform.position = fly;
			rigidbody2D.gravityScale = 0;
			//flying = true;
			Vector2 tempvel = rigidbody2D.velocity;
			tempvel.x = 0;
			rigidbody2D.velocity = tempvel;
			GlobalStatics.gravityOff = true;
		}
		else if(ButtonA.state && GlobalStatics.gravityOff)
		{
			GlobalStatics.gravityOff = false;
			rigidbody2D.gravityScale = 1;
			//flying = false;
		}

        Vector2 move = new Vector2();
        Vector2 anlogmove = AnologeStick.position+new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
		if(gravityScr.gravityOff == false)
		{
	        if (anlogmove.x == 0)
	        {
	            Vector2 tempvel = rigidbody2D.velocity;
	            tempvel.x = 0;
	          //  rigidbody2D.velocity = tempvel;
	        }
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
		}
        //Debug.Log(move);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == TagManager.floor)
        {
            g = true;
			GlobalStatics.playerOnGround = g;
            coll.sharedMaterial = orPhyMat;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == TagManager.floor)
        {
            g = false;
			GlobalStatics.playerOnGround = g;
            coll.sharedMaterial = airPhyMat;
        }
    }
}

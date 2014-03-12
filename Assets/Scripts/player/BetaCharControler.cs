using UnityEngine;
using System.Collections;

public class BetaCharControler : MonoBehaviour {

    //scriptlinks
    //public Joystick AnologeStick;
    public Button ButtonA;
    public Button ButtonB;
    public GameObject ButtonC;
    public ButtonRestonrelease RightButton;
    public ButtonRestonrelease LeftButton;
	//private GravityScript gravityScr;
	
    //materials
    public PhysicsMaterial2D airPhyMat;
    private PhysicsMaterial2D orPhyMat;
    private CircleCollider2D coll;

    //bools
    public bool g = false;

    //vectors
    public Vector2 anlogmove = new Vector2();

    //floats and ints
    private int health = 100; //player health 
   // private float addGravity = 2f;  //what was that for again?
    private float graviCoolDown = 0f; //
    private int currentTouchingObjects = 0;
    public float deathHeight = -20f;
    private bool Awoken = false;
    private float waitAfterAwake = 1f;

    void Awake()
    {
        waitAfterAwake = 1f;
        Awoken = false;
    }
    void Start()
    {
        coll = GetComponent<CircleCollider2D>();;
        orPhyMat = coll.sharedMaterial;
		//gravityScr = GetComponent<GravityScript>();
    }
	// Update is called once per frame
	void Update () 
	{
        if (Awoken)
        {
            Vector2 move = new Vector2();
            float ButtonMove = 0;
            if (LeftButton.state)
            {
                ButtonMove -= 1;
            }
            if (RightButton.state)
            {
                ButtonMove += 1;
            }

            anlogmove = new Vector2(Input.GetAxis("Horizontal") + ButtonMove, 0);

            //Debug.Log(anlogmove);
            if (rigidbody2D.velocity.x < 10 && rigidbody2D.velocity.x > -10)
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
            if (ButtonB.state && g && graviCoolDown < 0f || Input.GetKeyDown(KeyCode.Space)&& g && graviCoolDown < 0f)
            {
                currentTouchingObjects = 0;
                coll.sharedMaterial = airPhyMat;
                ButtonB.state = false;
                move.y = 500;
                graviCoolDown = 0.1f;
            }
           /* else if (Input.GetKeyDown(KeyCode.Space) && g)
            {
                currentTouchingObjects = 0;
                coll.sharedMaterial = airPhyMat;
                ButtonB.state = false;
                move.y = 500;
            }*/
            else
            {
                if (rigidbody2D.velocity.x < 2 && rigidbody2D.velocity.x > 2)
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

            }
            if (ButtonA.state && g || Input.GetKeyDown(KeyCode.LeftShift) && g)
            {
                ButtonA.state = false;
                //graviCoolDown = 1f;
                // ButtonC.SetActive(false);
                GlobalStatics.GraviChange();
            }
            graviCoolDown -= Time.deltaTime;
            rigidbody2D.AddForce(move);

            if (transform.position.y < deathHeight)
            {
                GlobalStatics.GameOver();
            }
        }
        else
        {
            waitAfterAwake -= Time.deltaTime;
            if (waitAfterAwake <= 0f)
            {
                Awoken = true;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        currentTouchingObjects += 1;
        if (other.gameObject.tag == TagManager.floor)
        {
            g = true;
			GlobalStatics.playerOnGround = g;
            coll.sharedMaterial = orPhyMat;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        currentTouchingObjects -= 1;
        if (other.gameObject.tag == TagManager.floor && currentTouchingObjects <=0)
        {
            currentTouchingObjects = 0;
            g = false;
			GlobalStatics.playerOnGround = g;
            coll.sharedMaterial = airPhyMat;
        }
    }

    //alt Collions
    void OnCollisionEnter2D(Collision2D other)
    {
        currentTouchingObjects += 1;
        if (other.gameObject.tag == TagManager.floor)
        {
            g = true;
            GlobalStatics.playerOnGround = g;
            coll.sharedMaterial = orPhyMat;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        currentTouchingObjects -= 1;
        if (other.gameObject.tag == TagManager.floor && currentTouchingObjects <= 0)
        {
            currentTouchingObjects = 0;
            g = false;
            GlobalStatics.playerOnGround = g;
            coll.sharedMaterial = airPhyMat;
        }
    }

    public void GetHit(int Damage)
    {
        health -= Damage;
        if (health <= 0)
        {
            GlobalStatics.GameOver();
        }
    }  
}

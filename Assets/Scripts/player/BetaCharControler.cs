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

    private float graviCoolDown = 0f; // against dubble presses
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
    }

    void FixedUpdate()
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

        //speed limiter;
        if (rigidbody2D.velocity.x < 10 && rigidbody2D.velocity.x > -10)
        {
            if (g)
            {
                move.x = anlogmove.x * 14;
            }
            else
            {
                move.x = anlogmove.x * 2;
            }
        }
        //Jump
        if (ButtonB.state && g && graviCoolDown < 0f || Input.GetKeyDown(KeyCode.Space) && g && graviCoolDown < 0f)
        {
            coll.sharedMaterial = airPhyMat;
            ButtonB.state = false;
            g = false;
            GlobalStatics.playerOnGround = g;
            move.y = 500;
            graviCoolDown = 0.1f;
        }
        else
        {
            /*if (rigidbody2D.velocity.x < 2 && rigidbody2D.velocity.x > 2)
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
            }*/
            if (rigidbody2D.velocity.y < -0.5f || rigidbody2D.velocity.y > 1f)
            {
                g = false;
                GlobalStatics.playerOnGround = g;
                coll.sharedMaterial = airPhyMat;
            }
        }
        if (ButtonA.state && g || Input.GetKeyDown(KeyCode.LeftShift) && g)
        {
            ButtonA.state = false;
            GlobalStatics.GraviChange();
        }

        graviCoolDown -= Time.fixedDeltaTime;
        rigidbody2D.AddForce(move);
        Debug.Log(Time.fixedDeltaTime);
    }

	void Update () 
	{
        if (transform.position.y < deathHeight)
        {
            GlobalStatics.GameOver();
        }
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

    //alt Collions
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == TagManager.floor)
        {
            g = true;
            GlobalStatics.playerOnGround = g;
            coll.sharedMaterial = orPhyMat;
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

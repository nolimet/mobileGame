﻿using UnityEngine;
using System.Collections;

public class BetaCharControler : MonoBehaviour {

    //scriptlinks
    public Joystick AnologeStick;
    public Button ButtonA;
    public Button ButtonB;
    public ButtonRestonrelease RightButton;
    public ButtonRestonrelease LeftButton;
	//private GravityScript gravityScr;
	
    //materials
    public PhysicsMaterial2D airPhyMat;
    private PhysicsMaterial2D orPhyMat;
    private BoxCollider2D coll;

    //bools
    public bool g = false;

    //vectors
    public Vector2 anlogmove = new Vector2();

    //floats and ints
    private int health = 100; //player health 
   // private float addGravity = 2f;  //what was that for again?
    private float graviCoolDown = 0f; //
    private int currentTouchingObjects = 0;


    void Start()
    {
        coll = GetComponent<BoxCollider2D>();;
        orPhyMat = coll.sharedMaterial;
		//gravityScr = GetComponent<GravityScript>();
    }
	// Update is called once per frame
	void Update () 
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

        anlogmove = new Vector2(Input.GetAxis("Horizontal")+ButtonMove,0);

		//Debug.Log(anlogmove);
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
			else if (Input.GetKeyDown(KeyCode.Space)&& g)
			{
				// g = false;
				coll.sharedMaterial = airPhyMat;
				ButtonB.state = false;
				move.y = 500;
			}
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
        if (ButtonA.state && g && graviCoolDown <= 0 || Input.GetKeyDown(KeyCode.LeftShift) && g && graviCoolDown <= 0)
        {
            graviCoolDown = 0.2f;
            Object[] objects = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in objects)
            {
                go.SendMessage("GraviSwitch", SendMessageOptions.DontRequireReceiver);
            }
        }
        graviCoolDown -= Time.deltaTime;
        rigidbody2D.AddForce(move);
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

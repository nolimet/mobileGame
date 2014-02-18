using UnityEngine;
using System.Collections;

public class ObjectScript : MonoBehaviour 
{
	public Button ButtonA;
	private float addGravity = 2f;
	//private bool gravityOff = false;
	//private bool flying = false;
	private bool g;

	// Use this for initialization
	void Start () 
	{
        g = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(ButtonA.state && GlobalStatics.gravityOff == false && GlobalStatics.playerOnGround)
		{
			Vector3 fly = new Vector3(transform.position.x,transform.position.y + addGravity,transform.position.z);
			transform.position = fly;
			//gravityOff = true;
			rigidbody2D.gravityScale = 0;
			Vector2 tempvel = rigidbody2D.velocity;
			tempvel.x = 0;
			rigidbody2D.velocity = tempvel;
		}
		else if(ButtonA.state && GlobalStatics.gravityOff)
		{
			rigidbody2D.gravityScale = 1;
			//gravityOff = false;	
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == TagManager.floor)
		{
			g = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == TagManager.floor)
		{
			g = false;
		}
	}
}

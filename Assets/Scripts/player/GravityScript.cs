using UnityEngine;
using System.Collections;

public class GravityScript : MonoBehaviour {
	public BetaCharControler playerScr;
	public Button ButtonA;
	public bool gravityOff = false;
	// Use this for initialization
	void Start () 
	{
		playerScr = GetComponent<BetaCharControler>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(ButtonA.state && playerScr.g)
		{
			gravityOff = true;
		}

		if(ButtonA.state && playerScr.g == false)
		{
			gravityOff = false;
		}

	}
}
